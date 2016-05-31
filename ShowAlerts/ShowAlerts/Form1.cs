using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowAlerts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'showDBDataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.showDBDataSet.Table);
            // TODO: This line of code loads data into the 'database1DataSet.Table' table. You can move, or remove it, as needed.


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
