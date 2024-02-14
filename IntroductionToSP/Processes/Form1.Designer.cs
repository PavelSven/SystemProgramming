namespace Processes
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.richTextBoxProcessName = new System.Windows.Forms.RichTextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelProcessInfo = new System.Windows.Forms.Label();
            this.myProcess = new System.Diagnostics.Process();
            this.lvProcesses = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 45);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // richTextBoxProcessName
            // 
            this.richTextBoxProcessName.Location = new System.Drawing.Point(12, 13);
            this.richTextBoxProcessName.Name = "richTextBoxProcessName";
            this.richTextBoxProcessName.Size = new System.Drawing.Size(375, 26);
            this.richTextBoxProcessName.TabIndex = 1;
            this.richTextBoxProcessName.Text = "notepad";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(312, 45);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 0;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // labelProcessInfo
            // 
            this.labelProcessInfo.AutoSize = true;
            this.labelProcessInfo.Location = new System.Drawing.Point(407, 13);
            this.labelProcessInfo.Name = "labelProcessInfo";
            this.labelProcessInfo.Size = new System.Drawing.Size(68, 13);
            this.labelProcessInfo.TabIndex = 2;
            this.labelProcessInfo.Text = "Process info:";
            // 
            // myProcess
            // 
            this.myProcess.StartInfo.Domain = "";
            this.myProcess.StartInfo.LoadUserProfile = false;
            this.myProcess.StartInfo.Password = null;
            this.myProcess.StartInfo.StandardErrorEncoding = null;
            this.myProcess.StartInfo.StandardOutputEncoding = null;
            this.myProcess.StartInfo.UserName = "";
            this.myProcess.SynchronizingObject = this;
            // 
            // lvProcesses
            // 
            this.lvProcesses.FullRowSelect = true;
            this.lvProcesses.HideSelection = false;
            this.lvProcesses.Location = new System.Drawing.Point(12, 74);
            this.lvProcesses.MultiSelect = false;
            this.lvProcesses.Name = "lvProcesses";
            this.lvProcesses.Size = new System.Drawing.Size(375, 206);
            this.lvProcesses.TabIndex = 3;
            this.lvProcesses.UseCompatibleStateImageBehavior = false;
            this.lvProcesses.View = System.Windows.Forms.View.Details;
            this.lvProcesses.SelectedIndexChanged += new System.EventHandler(this.lvProcesses_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 292);
            this.Controls.Add(this.lvProcesses);
            this.Controls.Add(this.labelProcessInfo);
            this.Controls.Add(this.richTextBoxProcessName);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.RichTextBox richTextBoxProcessName;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelProcessInfo;
        private System.Diagnostics.Process myProcess;
        private System.Windows.Forms.ListView lvProcesses;
    }
}

