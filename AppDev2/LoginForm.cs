using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDev2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string database = ConnetionInfo.database =textBox1.Text;
            string username = ConnetionInfo.username =textBox2.Text;
            string password = ConnetionInfo.pass =textBox3.Text;
            ConnetionInfo.option = 1;
            bool isWorking = dataBaseConnector.Instance.connect(database,username,password,1);
            if (isWorking) { this.Close(); } else { MessageBox.Show("Please try again"); }
        }

        private void button3_Click(object sender, EventArgs e) //Koster
        {
            bool isWorking = dataBaseConnector.Instance.connect("", "", "", 2);
            ConnetionInfo.database = ConnetionInfo.username = ConnetionInfo.pass = "";
            ConnetionInfo.option = 2;
             if (isWorking) { this.Close(); } else { MessageBox.Show("Please try again"); }
        }

        private void button2_Click(object sender, EventArgs e) //Recker
        {
            bool isWorking = dataBaseConnector.Instance.connect("","","",3);
            ConnetionInfo.database = ConnetionInfo.username = ConnetionInfo.pass = "";
            ConnetionInfo.option = 3;
            if (isWorking) { this.Close(); } else { MessageBox.Show("Please try again"); }
        }
    }
}
