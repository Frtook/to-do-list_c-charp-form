using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace my_project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public bool isAdd = false;
        public void button1_Click(object sender, EventArgs e)
        {
            if (txtTask.Text.Trim() == "")
            {
                MessageBox.Show("Enter Task Name");
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Enter priority");
            }
            else
            {
                isAdd = true;
                this.Close();
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            isAdd = false;
        }
    }
}
