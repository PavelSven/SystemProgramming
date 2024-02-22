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
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Processes
{
    public partial class Form1 : Form
    {
        //List<Process> processList;
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hwnd);

        List<Process> processes;

        public Form1()
        {
            InitializeComponent();

            //InitProcess();
            processes = new List<Process>();
            lvProcesses.Columns.Add("PID");
            lvProcesses.Columns.Add("Name");

            LoadAllProcesses();
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

/*            while (lvProcesses.Items.Count > 0)
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
            }*/
        }

        void InitProcess()
        {
            AlignText();
            Process process = new Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(richTextBoxProcessName.Text);
            process.Start();
            //processList.Add(myProcess);
            processes.Add(process);

            lvProcesses.Items.Add(process.Id.ToString());
            lvProcesses.Items[lvProcesses.Items.Count - 1].SubItems.Add(process.ProcessName);

            process.EnableRaisingEvents = true;
            process.Exited += Proc_Exited;
        }

        private void Proc_Exited(object sender, EventArgs e)
        {
            Process proc = sender as Process;

            //lvProcesses.Items.RemoveAt(lvProcesses.Items.IndexOfKey(proc.Id.ToString()));
            lvProcesses.Items.RemoveByKey(proc.Id.ToString());
            processes.Remove(proc);
        }

        void LoadAllProcesses()
        {
            Process[] processesCurrent = Process.GetProcesses();
            foreach (Process process in processesCurrent) 
            {
                if (processes.Find(p => p.Id == process.Id) != default(Process))
                    continue;

                lvProcesses.Items.Add(process.Id.ToString());
                lvProcesses.Items[lvProcesses.Items.Count - 1].SubItems.Add(process.ProcessName);
                processes.Add(process);

                try
                {
                    process.EnableRaisingEvents = true;
                    process.Exited += Proc_Exited;
                }
                catch (Win32Exception)
                {
                }
            }
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

            /*            try
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
                            if (lvProcesses.Items.Count != 0)
                            {
                                myProcess = Process.GetProcessById(Convert.ToInt32(lvProcesses.Items[lvProcesses.Items.Count - 1].Text));
                                SetForegroundWindow(myProcess.MainWindowHandle);
                            }
                        }*/

            lvProcesses.Items.Remove(lvProcesses.SelectedItems[0]);
            processes.Remove(processes.First(proc => proc.Id == idProcess));

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
            labelCountProcesses.Text = $"Количество процессов: {lvProcesses.Items.Count}";

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
            labelProcessInfo.Text += $"Name:                    {myProcess.ProcessName}\n";
            labelProcessInfo.Text += $"Base priority:           {myProcess.BasePriority}\n";
            labelProcessInfo.Text += $"Session Id:              {myProcess.SessionId}\n";
            labelProcessInfo.Text += $"Threads:                 {myProcess.Threads.Count}\n";
            labelProcessInfo.Text += $"Machine name:            {myProcess.MachineName}\n";
            try
            {
                labelProcessInfo.Text += $"Priority Class:          {myProcess.PriorityClass}\n";
                labelProcessInfo.Text += $"Start time:              {myProcess.StartTime}\n";
                labelProcessInfo.Text += $"Total Processor Time:    {myProcess.TotalProcessorTime}\n";
                labelProcessInfo.Text += $"User Processor Time:     {myProcess.UserProcessorTime}\n";
                labelProcessInfo.Text += $"Processor Affinity:      {myProcess.ProcessorAffinity}\n";
            }
            catch (Exception)
            {
            }

        }

        private void lvProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            Info();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lvProcesses.Items.Clear();
            LoadAllProcesses();
            Info();
        }
    }
}