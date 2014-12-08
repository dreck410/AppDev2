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
using System.IO;
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

            foreach (string song in dataBaseConnector.Instance.getSongView())
            {
                this.LastUsedSongsBox.Items.Add(song);
            }
            //Daniel TODO
            /*
             * To help the songleader choose songs for each service, create a view named SongUsageView 
             * that displays all of the colums in the Song table, plus one named LastUsedDate, and one 
             * named Theme. The LastUsedDate column should contain the date of the most recent service 
             * that used that song, and the Theme should be the theme of the service that used it. Include
             * all songs in the SongView, even those which have not been used in a service. However, the 
             * view should not include choral numbers.
             * 
             * Create a stored procedure named LeastUsedSongs that displays the top 10 songs from the 
             * SongUsageView, when ordered in ascending order on LastUsedDate and then Title. Use the SELECT 
             * TOP feature of SQL Server to limit the number of rows to the top 10. 10 points. 
             */

        }
        
        private void GO_Click(object sender, EventArgs e)
        {
            //CHeck for empty/invalid- Curt
            dataBaseConnector.Instance.setServiceID(-1);
            bool invalidEntry = false;
           
            DateTime serviceDateTime= DateTime.Now;
            DateTime templateDateTime= DateTime.Now;

            // This will be created from text box 1 and 2
            string serviceDate = ServiceDateBox.Text;
            string serviceTime = ServiceTimeBox.Text;


            //From boxes 3 and 4
          //  string templateDate = TemplateDateBox.Text;
           // string templateTime = TemplateTimeBox.Text;

            //This method validates all dates/time input
            invalidEntry = DataUpdater.validateDateTime(serviceDate, serviceTime);//, templateDate, templateTime);


            if (invalidEntry || serviceDate == "" || serviceTime == "" ) { invalidEntry = true; }
            else //Aka previous method validated entries
            {
                serviceDateTime = Convert.ToDateTime(serviceDate + " " + serviceTime);
                string tDT = "";
                try
                {
                    tDT = TemplateList.SelectedItem.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Select a Template Date from the List");
                    UpdateFields("-1");
                    return;
                }
                templateDateTime = Convert.ToDateTime(tDT);
                //templateDateTime = Convert.ToDateTime(templateDate + " " + templateTime);
                //MessageBox.Show(serviceDateTime.ToString());//It looks correct-leaving this uncommented, what do you think?
            
            }
            int serviceID = dataBaseConnector.Instance.getServiceID(serviceDateTime.ToString());
            string title = TitleBox.Text;
            string theme = ThemeBox.Text;
            string SongLeader = SongLeaderBox.Text;
            
            
            //songLeader either ID or 
            // a drop down that has all of the past song leaders from the database


            //If all is good, create an update data method -Reckie
            if (invalidEntry || isDirty(title) || isDirty(theme) || isDirty(SongLeader))
            {
                MessageBox.Show("Invalid Entries Detected- Please Re-Enter");
                UpdateFields("-1");
            }
            else
            {
                int result = DataUpdater.insertService(serviceDateTime, templateDateTime, title, theme, SongLeader);
                Console.WriteLine(result);
                generateMessage(result);
                
                UpdateFields(serviceID.ToString());
                

            }

        }

        private bool isDirty(string str)
        {
            if (0 <= str.IndexOf(';')) { return true; }
            if (0 <= str.IndexOf('"')) { return true; }
            if (0 <= str.IndexOf('\'')) { return true; }
            //if (0 >= str.IndexOf())

            return false;
        }

        private void UpdateFields(string servID)
        {
            dataBaseConnector.Instance.createSongView();
            this.SongLeaderBox.Items.Clear();
            foreach (string item in dataBaseConnector.Instance.getPastSongLeaders())
            {
                this.SongLeaderBox.Items.Add(item);
            }

            this.TemplateList.Items.Clear();
            foreach (string date in dataBaseConnector.Instance.getValidDates())
            {
                this.TemplateList.Items.Add(date);
            }

            this.ServiceSongEventBox.Items.Clear();
            foreach (string congSong in dataBaseConnector.Instance.getCongSongs())
            {
                this.ServiceSongEventBox.Items.Add(congSong);
            }

            this.LastUsedSongsBox.Items.Clear();
            foreach (string song in dataBaseConnector.Instance.getSongView())
            {
                this.LastUsedSongsBox.Items.Add(song);
            }

        }

        private void generateMessage(int result)
        {
            List<string> errors = new List<string>();
            errors.Add("Service Added");
            errors.Add("Invalid Song Leader");
            errors.Add("Invalid Template Service Time");
            errors.Add("Service Date and Time already Used");
            MessageBox.Show(errors[(result * -1)]);
          
        }

        private void importSongButton_Click(object sender, EventArgs e)
        {
            string selectedSong = "";
            string selectedEvent = "";
            try
            {
                selectedSong = LastUsedSongsBox.SelectedItem.ToString();
                selectedEvent = ServiceSongEventBox.SelectedItem.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Select a Song and an Event.");
                return;
            }
            string serviceID = dataBaseConnector.Instance.importSongToEvent(selectedSong, selectedEvent);
            UpdateFields(serviceID);
            Console.WriteLine("Button PRess");
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

        private void TemplateList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void funBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                string pathToConsoleApp = Path.Combine(path, "all-4-pong.exe");

                System.Diagnostics.Process.Start(pathToConsoleApp);
            }
            catch
            {
                Console.WriteLine("Oops");
            }
            
        }
    }
}
