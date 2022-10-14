using Microsoft.Win32;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace PCControlApp
{
    public partial class MainForm : Form
    {
        private Task MonitorTask;
        public MainForm()
        {
            InitializeComponent();
            SystemEvents.SessionEnding += SessionEndingEvtHandler;
            MonitorTask = Task.Run(new Action(MonitorInternet));
        }

        ~MainForm()
        {
            try
            {
                SaveCurrentLog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void TriggerBtn_Click(object sender, EventArgs e)
        {
            if (MonitorTask != null && MonitorTask.Status == TaskStatus.Running)
            {
                LogText("Error: Already running monitor.");
            }
            else
            {
                MonitorTask = Task.Run(new Action(MonitorInternet));
            }
        }

        private void MonitorInternet()
        {
            LogText("Starting to monitor.");
            this.Invoke(() =>
            {
                StatusLbl.Text = "Active";
            });

            // Bad
            while (true)
            {
                if (!PingHost(@"8.8.8.8", 1000))
                {
                    LogText("Ping failed, trying again..");
                    // Failed ping, try again
                    if (!PingHost(@"8.8.8.8", 1000))
                    {
                        LogText("Ping failed second time, initiating restart..");
                        // Restart
                        SaveCurrentLog();
                        RestartPC(new string[] { "/f", "/t 300" });
                        return;
                    }
                }
                Thread.Sleep(150000);
            }
        }

        private void LogText(string text)
        {
            this.Invoke(() =>
            {
                LogBox.AppendText(DateTime.Now + ": " + text + Environment.NewLine);
            });
        }

        private void SaveCurrentLog()
        {
            try
            {
                File.WriteAllText(@"C:\Users\3D Infotech\Desktop\" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + "_ShutDownLog.txt", LogBox.Text.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RestartPC(string[] additionalActions)
        {
            string restartCmd = "/r ";
            string combinedCmd = restartCmd + string.Join(" ", additionalActions);
            System.Diagnostics.Process.Start("shutdown.exe", combinedCmd);
        }

        private void SessionEndingEvtHandler(object sender, SessionEndingEventArgs e)
        {
            this.InvokeIfRequired(_ =>
            {
                CancelBtn.Enabled = true;
            });
        }

        private void CancelShutdown()
        {
            try
            {
                string cmd = "shutdown /a";
                Process.Start(cmd);// for executing system command.
                this.InvokeIfRequired(_ =>
                {
                    CancelBtn.Enabled = false;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool PingHost(string nameOrAddress, int pingTimeOut)
        {
            bool pingable = false;
            Ping? pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress, pingTimeOut);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveCurrentLog();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            CancelShutdown();
        }
    }

    public static class ExtensionMethods
    {
        public static void Invoke(this Control c, MethodInvoker mi)
        {
            c.Invoke(mi);

            return;
        }

        public static void InvokeIfRequired<T>(this T control, Action<T> action) where T : Control
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => action(control)));
            }
            else
            {
                action(control);
            }
        }
    }
}