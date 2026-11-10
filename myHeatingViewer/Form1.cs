using System;
using System.Reflection;
using System.Windows.Forms;

namespace myHeatingViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " : v" + Assembly.GetExecutingAssembly().GetName().Version; // put in the version number

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {

        }

        private void btnDrawChart_Click(object sender, EventArgs e)
        {

        }
    }
}
