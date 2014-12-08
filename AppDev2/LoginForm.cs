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
            MessageBox.Show("Hello Dr. Knisely, for grading purposes, it is probably best to use Koster's database. Recker's is spammed with tons of random test data. Thanks!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string database = ConnetionInfo.database =textBox1.Text;
            string username = ConnetionInfo.username =textBox2.Text;
            string password = ConnetionInfo.pass =textBox3.Text;
            ConnetionInfo.option = 1;
            bool isWorking = dataBaseConnector.Instance.connect();
            if (isWorking) { ConnetionInfo.success = true; this.Close(); } 
            else { MessageBox.Show("Please try again"); ConnetionInfo.success = false; }
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
            if (isWorking) { ConnetionInfo.success = true; this.Close(); } 
            else { MessageBox.Show("Please try again"); ConnetionInfo.success = false; }
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
            if (isWorking) { ConnetionInfo.success = true; this.Close(); }
            else { ConnetionInfo.success = false;  MessageBox.Show("Please try again"); }
        }
    }
}
