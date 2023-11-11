using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace my_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        string task, date, priority;

        void SaveData()
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(save.FileName))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            bool isChecked = Convert.ToBoolean(row.Cells[0].Value);
                            string text1 = row.Cells[1].Value.ToString();
                            string text2 = row.Cells[2].Value.ToString();
                            string rowData = $"{isChecked}\t{text1}\t{text2}";
                            writer.WriteLine(rowData);
                        }
                    }
                }
                MessageBox.Show("Saved");
            }
        }
        void LoadData()
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();

                using (StreamReader reader = new StreamReader(open.FileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] columns = line.Split('\t'); // Change '\t' to your delimiter
                        int rowIndex = dataGridView1.Rows.Add();
                        dataGridView1.Rows[rowIndex].Cells[0].Value = Convert.ToBoolean(columns[0]);
                        dataGridView1.Rows[rowIndex].Cells[1].Value = columns[1];
                        dataGridView1.Rows[rowIndex].Cells[2].Value = columns[2];
                    }
                }
            }
        }

        void EditData()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Form2 f2 = new Form2();
                f2.txtTask.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                f2.dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                f2.comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                f2.ShowDialog();
                if (true)
                {
                    task = f2.txtTask.Text;
                    date = f2.dateTimePicker1.Text;
                    if (f2.comboBox1.SelectedItem != null)
                    {
                        priority = f2.comboBox1.SelectedItem.ToString();
                    }
                    dataGridView1.CurrentRow.Cells[1].Value = date;
                    dataGridView1.CurrentRow.Cells[2].Value = priority;
                    dataGridView1.CurrentRow.Cells[3].Value = task;
                }
            }
        }
        void DeleteData()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
        }
        void AddData()
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if (f2.isAdd)
            {
                task = f2.txtTask.Text;
                date = f2.dateTimePicker1.Text;
                if (f2.comboBox1.SelectedItem != null)
                {
                    priority = f2.comboBox1.SelectedItem.ToString();
                }

                dataGridView1.Rows.Add(false, date, priority, task);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.A)
            {
                AddData();
            }
            if(e.Control && e.KeyCode == Keys.E)
            {
                EditData();
            }
            if (e.Control && e.KeyCode == Keys.D)
            {
                DeleteData();
            }
            if (e.Control && e.KeyCode == Keys.L)
            {
                LoadData();
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveData();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            dataGridView1.Width = this.Width;
            dataGridView1.Height = this.Height;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditData();
        }
    }
}
