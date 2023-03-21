using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void Choose_Click(object sender, EventArgs e)
        {

        }

        private void BFS_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void DFS_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void startButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
