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
            bool isWorking = dataBaseConnector.Instance.connect();
            if (isWorking) { this.Close(); } else { MessageBox.Show("Please try again"); }
        }

        private void button3_Click(object sender, EventArgs e) //Koster
        {
            ConnetionInfo.database = "cps301_ckost598";
            ConnetionInfo.username = "ckost598";
            ConnetionInfo.pass = "ckost598";
            ConnetionInfo.option = 1;
            bool isWorking = dataBaseConnector.Instance.connect();
          //  ConnetionInfo.database = ConnetionInfo.username = ConnetionInfo.pass = "";
          //  ConnetionInfo.option = 2;
             if (isWorking) { this.Close(); } else { MessageBox.Show("Please try again"); }
        }

        private void button2_Click(object sender, EventArgs e) //Recker
        {
            ConnetionInfo.database = "cps301_dreck410";
            ConnetionInfo.username = "dreck410";
            ConnetionInfo.pass = "dreck410";
            ConnetionInfo.option = 1;
            bool isWorking = dataBaseConnector.Instance.connect();
            //ConnetionInfo.database = ConnetionInfo.username = ConnetionInfo.pass = "";
           // ConnetionInfo.option = 3;
            if (isWorking) { this.Close(); } else { MessageBox.Show("Please try again"); }
        }
    }
}
