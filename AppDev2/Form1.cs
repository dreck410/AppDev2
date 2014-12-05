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
using System.Text.RegularExpressions;

namespace AppDev2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (string item in dataBaseConnector.Instance.getPastSongLeaders())
            {
                this.SongLeaderBox.Items.Add(item);
            }
            foreach (string date in dataBaseConnector.Instance.getValidDates())
            {
                this.TemplateList.Items.Add(date);
            }
            dataBaseConnector.Instance.createSongView();
            
        }
        
        private void GO_Click(object sender, EventArgs e)
        {
            //CHeck for empty/invalid- Curt
            bool invalidEntry = false;
           
            DateTime serviceDateTime= DateTime.Now;
            DateTime templateDateTime= DateTime.Now;

            // This will be created from text box 1 and 2
            string serviceDate = ServiceDateBox.Text;
            string serviceTime = ServiceTimeBox.Text;


            //From boxes 3 and 4
            string templateDate = TemplateDateBox.Text;
            string templateTime = TemplateTimeBox.Text;

            //This method validates all dates/time input
            invalidEntry = DataUpdater.validateDateTime(serviceDate, serviceTime, templateDate, templateTime);


            if (invalidEntry || serviceDate == "" || serviceTime == "" || templateDate == "" || templateTime == "") { invalidEntry = true; }
            else //Aka previous method validated entries
            {
                //serviceDateTime = DateTime.ParseExact(serviceDate + " " + serviceTime, "MM/dd/yyyy hh:mm:ss ", CultureInfo.InvariantCulture);
                //templateDateTime = DateTime.ParseExact(templateDate + " " + templateTime, "MM/dd/yyyy hh:mm:ss ", CultureInfo.InvariantCulture);
                serviceDateTime = Convert.ToDateTime(serviceDate + " " + serviceTime);
                templateDateTime = Convert.ToDateTime(templateDate + " " + templateTime);
                //MessageBox.Show(serviceDateTime.ToString());//It looks correct-leaving this uncommented, what do you think?
            
            }
            string title = TitleBox.Text;
            string theme = ThemeBox.Text;

            //songLeader either ID or 
            // a drop down that has all of the past song leaders from the database
            string SongLeader = SongLeaderBox.Text;
            Console.WriteLine(SongLeader);

            //If all is good, create an update data method -Reckie
            if (invalidEntry)
            {
                MessageBox.Show("Invalid Entries Detected- Please Re-Enter");
            }
            else
            {
                int result = DataUpdater.insertService(serviceDateTime, templateDateTime, title, theme, SongLeader);
                Console.WriteLine(result);
                generateMessage(result);
                //update the song leader combo box to have that new guys name in it. 
                this.SongLeaderBox.Items.Clear();
                foreach (string item in dataBaseConnector.Instance.getPastSongLeaders())
                 {
                    this.SongLeaderBox.Items.Add(item);
                 }
            }

        }

        private void generateMessage(int result)
        {
            List<string> errors = new List<string>();
            errors.Add("Service Added");
            errors.Add("Invalid Song Leader");
            errors.Add("Invalid Template Service Time");
            
            MessageBox.Show(errors[(result * -1)]);
          
        }

        private void ServiceDateBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ServiceTimeBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
