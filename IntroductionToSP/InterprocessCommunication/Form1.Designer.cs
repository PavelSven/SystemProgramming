namespace InterprocessCommunication
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
            this.listBoxProcesses = new System.Windows.Forms.ListBox();
            this.listBoxAssemblies = new System.Windows.Forms.ListBox();
            this.labelProcesses = new System.Windows.Forms.Label();
            this.labelAssemblies = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonCloseWindow = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonChooseDirectory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxProcesses
            // 
            this.listBoxProcesses.FormattingEnabled = true;
            this.listBoxProcesses.Location = new System.Drawing.Point(12, 33);
            this.listBoxProcesses.Name = "listBoxProcesses";
            this.listBoxProcesses.Size = new System.Drawing.Size(222, 238);
            this.listBoxProcesses.TabIndex = 0;
            this.listBoxProcesses.SelectedIndexChanged += new System.EventHandler(this.listBoxProcesses_SelectedIndexChanged);
            // 
            // listBoxAssemblies
            // 
            this.listBoxAssemblies.FormattingEnabled = true;
            this.listBoxAssemblies.Location = new System.Drawing.Point(341, 33);
            this.listBoxAssemblies.Name = "listBoxAssemblies";
            this.listBoxAssemblies.Size = new System.Drawing.Size(222, 238);
            this.listBoxAssemblies.TabIndex = 0;
            this.listBoxAssemblies.SelectedIndexChanged += new System.EventHandler(this.listBoxAssemblies_SelectedIndexChanged);
            // 
            // labelProcesses
            // 
            this.labelProcesses.AutoSize = true;
            this.labelProcesses.Location = new System.Drawing.Point(13, 14);
            this.labelProcesses.Name = "labelProcesses";
            this.labelProcesses.Size = new System.Drawing.Size(125, 13);
            this.labelProcesses.TabIndex = 1;
            this.labelProcesses.Text = "Запущенные процессы";
            // 
            // labelAssemblies
            // 
            this.labelAssemblies.AutoSize = true;
            this.labelAssemblies.Location = new System.Drawing.Point(405, 14);
            this.labelAssemblies.Name = "labelAssemblies";
            this.labelAssemblies.Size = new System.Drawing.Size(103, 13);
            this.labelAssemblies.TabIndex = 1;
            this.labelAssemblies.Text = "Доступные сборки";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(250, 33);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(250, 62);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonCloseWindow
            // 
            this.buttonCloseWindow.Location = new System.Drawing.Point(240, 91);
            this.buttonCloseWindow.Name = "buttonCloseWindow";
            this.buttonCloseWindow.Size = new System.Drawing.Size(95, 23);
            this.buttonCloseWindow.TabIndex = 2;
            this.buttonCloseWindow.Text = "Close Window";
            this.buttonCloseWindow.UseVisualStyleBackColor = true;
            this.buttonCloseWindow.Click += new System.EventHandler(this.buttonCloseWindow_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(250, 120);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonChooseDirectory
            // 
            this.buttonChooseDirectory.Location = new System.Drawing.Point(250, 248);
            this.buttonChooseDirectory.Name = "buttonChooseDirectory";
            this.buttonChooseDirectory.Size = new System.Drawing.Size(75, 23);
            this.buttonChooseDirectory.TabIndex = 3;
            this.buttonChooseDirectory.Text = "Directory";
            this.buttonChooseDirectory.UseVisualStyleBackColor = true;
            this.buttonChooseDirectory.Click += new System.EventHandler(this.buttonChooseDirectory_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 284);
            this.Controls.Add(this.buttonChooseDirectory);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonCloseWindow);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelAssemblies);
            this.Controls.Add(this.labelProcesses);
            this.Controls.Add(this.listBoxAssemblies);
            this.Controls.Add(this.listBoxProcesses);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxProcesses;
        private System.Windows.Forms.ListBox listBoxAssemblies;
        private System.Windows.Forms.Label labelProcesses;
        private System.Windows.Forms.Label labelAssemblies;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonCloseWindow;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonChooseDirectory;
    }
}

