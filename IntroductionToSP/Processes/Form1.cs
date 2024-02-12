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
        //List<Process> processList;

        public Form1()
        {
            InitializeComponent();

            //processList = new List<Process>();
            //InitProcess();
            lvProcesses.Columns.Add("PID");
            lvProcesses.Columns.Add("Name");

        }

        void Form1_Closing(object sender, CancelEventArgs e) 
        {
            /*            foreach (Process item in processList)
                        {
                            if (!item.HasExited)
                            { 
                                item.CloseMainWindow();
                                item.Close();
                            }
                        }
                        processList.Clear();*/

            while (lvProcesses.Items.Count > 0)
            {
                try
                {
                    myProcess = Process.GetProcessById(Convert.ToInt32(lvProcesses.Items[0].Text));
                    myProcess.CloseMainWindow();
                    myProcess.Close();
                }
                catch (ArgumentException)
                {
                }
                finally
                {
                    lvProcesses.Items.RemoveAt(0);
                }
            }
        }

        void InitProcess()
        {
            AlignText();
            myProcess = new Process();
            myProcess.StartInfo = new System.Diagnostics.ProcessStartInfo(richTextBoxProcessName.Text);
            myProcess.Start();
            //processList.Add(myProcess);

            lvProcesses.Items.Add(myProcess.Id.ToString());
            lvProcesses.Items[lvProcesses.Items.Count - 1].SubItems.Add(myProcess.ProcessName);
        }

        void AlignText()
        {
            richTextBoxProcessName.SelectAll();
            richTextBoxProcessName.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            InitProcess();
            //myProcess.Start();
            Info();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            /*            if (processList.Count > 0) 
                        {
                            if (!myProcess.HasExited)
                            {

                                myProcess.CloseMainWindow(); //закрывает процесс
                                myProcess.Close();          //освобождает ресурсы, занимаемые процессом
                            }
                            processList.RemoveAt(processList.Count - 1);
                        }

                        if (processList.Count > 0)
                            myProcess = processList[processList.Count - 1];*/
            int idProcess;
            try
            {
                idProcess = Convert.ToInt32(lvProcesses.SelectedItems[0].Text);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Выберите процесс в таблице", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                myProcess = Process.GetProcessById(idProcess);

                myProcess.CloseMainWindow();
                myProcess.Close();
            }
            catch(ArgumentException)
            {
            }
            finally
            {
                lvProcesses.Items.Remove(lvProcesses.SelectedItems[0]);
            }

            Info();
        }

        void Info()
        {
            /*            if (processList.Count > 0)
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
                        }*/

            labelProcessInfo.Text = "";

            int idProcess;
            try
            {
                idProcess = Convert.ToInt32(lvProcesses.SelectedItems[0].Text);
            }
            catch (ArgumentOutOfRangeException)
            {
                labelProcessInfo.Text = "Выберите процесс в таблице";
                return;
            }

            try
            {
                myProcess = Process.GetProcessById(idProcess);

            }
            catch (ArgumentException)
            {
                labelProcessInfo.Text = "Процесс уже закрыт";
                return;
            }

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

        private void lvProcesses_MouseClick(object sender, MouseEventArgs e)
        {
            Info();
        }
    }
}
