using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
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
            
            /*DateTime User Entry Format is:
             * string one = "02/13/09";
               string two = "2:35:10 PM"
             * */
            // This will be created from text box 1 and 2
            DateTime serviceDateTime;
            serviceDateTime = DateTime.Now;
            string serviceDate = ServiceDateBox.Text;
            string serviceTime = ServiceTimeBox.Text;
            
            serviceDateTime = DateTime.ParseExact(serviceDate + " " + serviceTime, "MM/dd/yy h:mm:ss tt", CultureInfo.InvariantCulture);
            MessageBox.Show(serviceDateTime.ToString());//It looks correct-leaving this uncommented, what do you think?
            //^This works-maybe? 

            //serviceDateTime = DateTime.Now;
            // this will be made from boxes 3 and 4
            DateTime templateDateTime;
            templateDateTime = DateTime.Now;
            //templateDateTime = DateTime.ParseExact("2010-10-03 10:30:00", "yyyy-mm-dd hh:mm:ss", CultureInfo.InvariantCulture);

            // Title
            string title = TitleBox.Text;

            // theme
            string theme = ThemeBox.Text;

            //songLeader either ID or 
            // a drop down that has all of the past song leaders from the database
            string SongLeader = SongleaderBox.Text;

            //If all is good, create an update data method -Reckie
            DataUpdater.insertService(serviceDateTime, templateDateTime, title, theme, SongLeader);

        }

        private void ServiceDateBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
