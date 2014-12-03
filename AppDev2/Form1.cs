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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GO_Click(object sender, EventArgs e)
        {
            //CHeck for empty/invalid- Curt
            // DataUpdater.EnterData(form1 box 1....)  --make static
            
            // This will be created from text box 1 and 2
            DateTime serviceDateTime;
            serviceDateTime = DateTime.Now;

            // this will be made from boxes 3 and 4
            DateTime templateDateTime;
            templateDateTime = DateTime.Now;

            // Title
            string title = "";

            // theme
            string theme = "";

            //songLeader either ID or 
            // a drop down that has all of the past song leaders from the database
            string SongLeader = "";

            //If all is good, create an update data method -Reckie
            DataUpdater.insertService(serviceDateTime, templateDateTime, title, theme, SongLeader);

        }
    }
}
