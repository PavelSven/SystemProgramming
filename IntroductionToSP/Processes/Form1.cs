using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Processes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitProcess();
        }

        void Form1_Closing(object sender, CancelEventArgs e) 
        {
            myProcess.CloseMainWindow();
            myProcess.Close();
        }

        void InitProcess()
        {
            AlignText();
            myProcess.StartInfo = new System.Diagnostics.ProcessStartInfo(richTextBoxProcessName.Text);
        }

        void AlignText()
        {
            richTextBoxProcessName.SelectAll();
            richTextBoxProcessName.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            InitProcess();
            myProcess.Start();
            Info();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            myProcess.CloseMainWindow(); //закрывает процесс
            myProcess.Close();          //освобождает ресурсы, занимаемые процессом
        }

        void Info()
        {
            labelProcessInfo.Text = "Process info:\n";
            labelProcessInfo.Text += $"PID:                     {myProcess.Id}\n";
            labelProcessInfo.Text += $"Base priority:           {myProcess.BasePriority}\n";
            labelProcessInfo.Text += $"Priority Class:          {myProcess.PriorityClass}\n";
            labelProcessInfo.Text += $"Start time:              {myProcess.StartTime}\n";
            labelProcessInfo.Text += $"Total Processor Time:    {myProcess.TotalProcessorTime}\n";
            labelProcessInfo.Text += $"User Processor Time:     {myProcess.UserProcessorTime}\n";
            labelProcessInfo.Text += $"Session Id:              {myProcess.SessionId}\n";
            labelProcessInfo.Text += $"Name:                    {myProcess.ProcessName}\n";
            labelProcessInfo.Text += $"Processor Affinity:      {myProcess.ProcessorAffinity}\n";
            labelProcessInfo.Text += $"Threads:                 {myProcess.Threads.Count}\n";
        }
    }
}
