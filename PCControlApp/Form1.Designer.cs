namespace PCControlApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TriggerBtn = new System.Windows.Forms.Button();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TriggerBtn
            // 
            this.TriggerBtn.Location = new System.Drawing.Point(292, 24);
            this.TriggerBtn.Name = "TriggerBtn";
            this.TriggerBtn.Size = new System.Drawing.Size(150, 46);
            this.TriggerBtn.TabIndex = 0;
            this.TriggerBtn.Text = "Trigger";
            this.TriggerBtn.UseVisualStyleBackColor = true;
            this.TriggerBtn.Click += new System.EventHandler(this.TriggerBtn_Click);
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Location = new System.Drawing.Point(662, 31);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(126, 32);
            this.StatusLbl.TabIndex = 1;
            this.StatusLbl.Text = "Not Active";
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.LogBox.Location = new System.Drawing.Point(12, 88);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogBox.Size = new System.Drawing.Size(776, 350);
            this.LogBox.TabIndex = 2;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(640, 462);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(150, 46);
            this.SaveBtn.TabIndex = 3;
            this.SaveBtn.Text = "Save Log";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(12, 462);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(232, 46);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Cancel Shutdown";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(802, 520);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.StatusLbl);
            this.Controls.Add(this.TriggerBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PC Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button TriggerBtn;
        private Label StatusLbl;
        private TextBox LogBox;
        private Button SaveBtn;
        private Button CancelBtn;
    }
}