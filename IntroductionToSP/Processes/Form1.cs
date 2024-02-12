using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Processes
{
    public partial class Form1 : Form
    {
        List<Process> processList;

        public Form1()
        {
            InitializeComponent();

            processList = new List<Process>();
            //InitProcess();
        }

        void Form1_Closing(object sender, CancelEventArgs e) 
        {
            foreach (Process item in processList)
            {
                if (!item.HasExited)
                {
   
                    item.CloseMainWindow();
                    item.Close();
                }
            }
            processList.Clear();
        }

        void InitProcess()
        {
            AlignText();
            myProcess = new Process();
            myProcess.StartInfo = new System.Diagnostics.ProcessStartInfo(richTextBoxProcessName.Text);

            processList.Add(myProcess);
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
            if (processList.Count > 0) 
            {
                if (!myProcess.HasExited)
                {
                    myProcess.CloseMainWindow(); //закрывает процесс
                    myProcess.Close();          //освобождает ресурсы, занимаемые процессом
                }
                processList.RemoveAt(processList.Count - 1);
            }

            if (processList.Count > 0)
                myProcess = processList[processList.Count - 1];

            Info();
        }

        void Info()
        {
            if (processList.Count > 0)
            {
                labelProcessInfo.Text = $"Total process count: {processList.Count}\n";
                labelProcessInfo.Text += "Process info:\n";
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
            else
            {
                labelProcessInfo.Text = "Нет запущенных процессов";
            }
        }
    }
}
