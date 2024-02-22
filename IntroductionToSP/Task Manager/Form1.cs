using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Task_Manager
{
    public partial class Form1 : Form
    {
        List<Process> processes;

        SortOrder sortOrder = SortOrder.None;
        int columnSort = 0;

        public Form1()
        {
            InitializeComponent();

            processes = new List<Process>();

            listViewProcesses.Columns.Add("PID");
            listViewProcesses.Columns.Add("Name");
            listViewProcesses.Columns.Add("Memory");
            
            InitAllProcesses();
            InitListViewProcesses(processes);

            buttonStop.Enabled = false;
        }

        private void InitAllProcesses()
        {
            processes = Process.GetProcesses().ToList();
        }

        private void InitListViewProcesses(List<Process> processes)
        {
            listViewProcesses.Items.Clear();

            foreach (Process process in processes)
            {

                try
                {
                    //process.EnableRaisingEvents = true;
                    //process.Exited += new EventHandler(Proc_Exited);
                }
                catch (Exception) { }

                ListViewItem item = new ListViewItem(process.Id.ToString());
                item.SubItems.Add(process.ProcessName);
                item.SubItems.Add((process.WorkingSet64 / 1024 / 1024).ToString());

                listViewProcesses.Items.Add(item);
            }

            listViewProcesses.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            labelCountProcesses.Text = $"Количество: {listViewProcesses.Items.Count}";
        }

        void InitProcess(string name)
        {
            Process process = new Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(name);
            process.Start();

            processes.Add(process);

            ListViewItem item = new ListViewItem(process.Id.ToString());
            item.SubItems.Add(process.ProcessName);
            item.SubItems.Add((process.WorkingSet64 / 1024 / 1024).ToString());

            listViewProcesses.Items.Add(item);

            process.EnableRaisingEvents = true;
            process.Exited += Proc_Exited;
        }

        private void Proc_Exited(object sender, EventArgs e)
        {
            
            Process proc = sender as Process;

            //lvProcesses.Items.RemoveAt(lvProcesses.Items.IndexOfKey(proc.Id.ToString()));
            listViewProcesses.Items.Remove(listViewProcesses.Items[proc.Id.ToString()]);
            processes.Remove(proc);
            labelCountProcesses.Text = $"Количество: {listViewProcesses.Items.Count}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //listViewProcesses.Items.Clear();
            //InitProcesses();
        }
        private void listViewProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonStop.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            int idProcess;
            try
            {
                idProcess = Convert.ToInt32(listViewProcesses.SelectedItems[0].Text);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Выберите процесс в таблице", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Process process = Process.GetProcessById(idProcess);

                processes.Remove(processes.First(p => p.Id == process.Id));

                process.CloseMainWindow();
                process.Close();
            }
            catch (ArgumentException) { }
            finally
            {
                listViewProcesses.Items.Remove(listViewProcesses.SelectedItems[0]);
                labelCountProcesses.Text = $"Количество: {listViewProcesses.Items.Count}";

                textBoxSearch_TextChanged(sender, e);
            }

            buttonStop.Enabled = false;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            InitAllProcesses();
            InitListViewProcesses(processes);
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Length == 0)
            {
                InitListViewProcesses(processes);
                return;
            }

            List<Process> searchProcesses = processes.FindAll(
                proc => proc.ProcessName.ToLower().Contains(textBoxSearch.Text.ToLower()));

            InitListViewProcesses(searchProcesses);
        }

        private void listViewProcesses_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == columnSort)
            {
                if (sortOrder == SortOrder.Ascending)
                    sortOrder = SortOrder.Descending;
                else
                    sortOrder = SortOrder.Ascending;
            }
            else
            {
                sortOrder = SortOrder.Ascending;
            }

            columnSort = e.Column;

            switch (e.Column)
            {
                case 0:
                    this.listViewProcesses.ListViewItemSorter = new ListViewItemComparerNumber(e.Column, sortOrder);
                    break;
                case 1:
                    this.listViewProcesses.ListViewItemSorter = new ListViewItemComparerString(e.Column, sortOrder);
                    break;
                case 2:
                    this.listViewProcesses.ListViewItemSorter = new ListViewItemComparerNumber(e.Column, sortOrder);
                    break;
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = "C:\\Windows\\System32";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                InitProcess(openFileDialog.FileName);
                buttonRefresh_Click(sender, e);
            }
        }
    }

    class ListViewItemComparerString : IComparer
    {
        protected int col;
        protected SortOrder sortOrder;

        public ListViewItemComparerString()
        {
            col = 0;
        }
        public ListViewItemComparerString(int column, SortOrder sortOrder)
        {
            col = column;
            this.sortOrder = sortOrder;
        }
        virtual public int Compare(object x, object y)
        {
            if (sortOrder == SortOrder.Ascending)
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            else if (sortOrder == SortOrder.Descending)
                return -String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            else
                return 0;
        }
    }

    class ListViewItemComparerNumber : ListViewItemComparerString
    {
        public ListViewItemComparerNumber() : base() { }
        public ListViewItemComparerNumber(int column, SortOrder sortOrder) : base(column, sortOrder) { }

        override public int Compare(object x, object y) 
        {
            if (sortOrder == SortOrder.Ascending)
                return uint.Parse(((ListViewItem)x).SubItems[col].Text).CompareTo(
                    uint.Parse(((ListViewItem)y).SubItems[col].Text));
            else if (sortOrder == SortOrder.Descending)
                return -uint.Parse(((ListViewItem)x).SubItems[col].Text).CompareTo(
                    uint.Parse(((ListViewItem)y).SubItems[col].Text));
            else
                return 0;
        }
    }
}
