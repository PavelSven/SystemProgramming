﻿using System;
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
using System.IO;
using System.Reflection;
using System.Management;

namespace InterprocessCommunication
{
    public partial class Form1 : Form
    {
        const uint WM_SETTEXT = 0x0C;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(
            IntPtr hwnd, uint uMsg, int wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);

        List<Process> processes = new List<Process>();
        int count = 0;

        string path;
        public string Path
        {
            get { return path; }
            set 
            { 
                path = value;
                listBoxAssemblies.Items.Clear();
                LoadAvailableAssemblies(path); 
            }
        }

        public Form1()
        {
            InitializeComponent();
            Path = Application.StartupPath;
            //LoadAvailableAssemblies(Path);

            buttonStart.Enabled = false;
            buttonStop.Enabled = false;
            buttonCloseWindow.Enabled = false;
        }

        void LoadAvailableAssemblies(string path)
        {
            string except = new FileInfo(Application.ExecutablePath).Name;
            except.Substring(0, except.IndexOf("."));

            LoadFilesByType(path, "*.exe", except);
            LoadFilesByType(path, "*.lnk", except);
        }

        void LoadFilesByType(string path, string format, string except)
        {
            string[] files = Directory.GetFiles(path, format);

            //string[] files = Directory.GetFiles(@"C:\Windows\System32", "*.exe");

            foreach (string file in files)
            {
                string fileName = new FileInfo(file).Name;
                if (fileName.IndexOf(except) == -1)
                    listBoxAssemblies.Items.Add(fileName);
            }
        }

        void RunProcess(string assemblyName)
        {
            if (assemblyName.Length == 0 || assemblyName == null)
                return;

            //Process proc = Process.Start(assemblyName);
            Process proc = Process.Start(assemblyName);

            processes.Add(proc);
            if (Process.GetCurrentProcess().Id == GetParentProcessId(proc.Id))
            {
/*                MessageBox.Show(
                    this,
                    proc.ProcessName + " дочерний процесс текущего процесса.",
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);*/
                proc.EnableRaisingEvents = true;
                proc.Exited += Proc_Exited;
                SendMessage(proc.MainWindowHandle, WM_SETTEXT, 0, $"Child process #{count++}");
                if (!listBoxProcesses.Items.Contains(proc.ProcessName))
                {
                    listBoxProcesses.Items.Add(proc.ProcessName);
                    listBoxAssemblies.Items.Remove(listBoxAssemblies.SelectedItem);
                }
            }
        }

        private void Proc_Exited(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Process proc = sender as Process;

            listBoxProcesses.Items.Remove(proc.ProcessName);
            listBoxAssemblies.Items.Add(proc.ProcessName);
            processes.Remove(proc);
            count--;
            int index = 0;
            foreach (Process process in processes) 
            {
                SendMessage(process.MainWindowHandle, WM_SETTEXT, 0, $"Child process #{++index}");
            }
        }

        int GetParentProcessId(int id)
        {
            int parentId = 0;
            using (ManagementObject obj = new ManagementObject($"win32_process.handle={id}")) 
            {
                obj.Get();
                parentId = Convert.ToInt32(obj["ParentProcessId"]);
            }
            return parentId;
        }

        delegate void ProcessDelegate(Process proc);
        void ExecuteOnProcessByName(string processName,  ProcessDelegate function)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes) 
            {
                if (Process.GetCurrentProcess().Id == GetParentProcessId(process.Id))
                {
                    function(process);
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            RunProcess(listBoxAssemblies.SelectedItem.ToString());
        }

        void Kill(Process proc)
        {
            proc.Kill();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessByName(listBoxProcesses.SelectedItem.ToString(), Kill);
            listBoxProcesses.Items.Remove(listBoxProcesses.SelectedItem);
        }

        void CloseMainWindow(Process proc)
        {
            proc.CloseMainWindow();
        }

        private void buttonCloseWindow_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessByName(listBoxProcesses.SelectedItem.ToString(), CloseMainWindow);
            listBoxProcesses.Items.Remove(listBoxProcesses.SelectedItem);
        }

        void Refresh(Process proc)
        {
            proc.Refresh();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessByName(listBoxProcesses.SelectedItem.ToString(), Refresh);
        }

        private void listBoxAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAssemblies.SelectedItems.Count == 0) buttonStart.Enabled = false;
            else buttonStart.Enabled = true;
        }

        private void listBoxProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxProcesses.SelectedItems.Count == 0)
            {
                buttonStop.Enabled = false;
                buttonCloseWindow.Enabled = false;
            }
            else
            {
                buttonStop.Enabled = true;
                buttonCloseWindow.Enabled = true;
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(Process proc in processes)
            {
                proc.Kill();
            }
        }

        private void buttonChooseDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            Path = dialog.SelectedPath;
        }
    }
}
