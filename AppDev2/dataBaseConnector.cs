using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
namespace AppDev2
{

    // singletons
    // manages the connection to the db
    class dataBaseConnector
    {
        int addedServiceID = -1;
        SqlConnection myConnection;
        private dataBaseConnector()
        {
            ;
        }
        private static dataBaseConnector instance;

        public static dataBaseConnector Instance{
            get
            {
                if (instance == null)
                {
                    instance = new dataBaseConnector();
                }
                return instance;
            }
        }

        public bool connect(string database,string user,string pass, int btn)
        {

            //myConnection = new SqlConnection("Server=sparky.bju.edu; Database=cps301_dreck410; Trusted_Connection=True;");
            if (btn == 1)
            {
                myConnection = new SqlConnection("Server=sparky.bju.edu;Database=" + database + ";User Id=" + user + ";Password=" + pass + ";");
            }
            if (btn == 2)
            {
                myConnection = new SqlConnection("Server=sparky.bju.edu;Database=cps301_ckost598;User Id=ckost598;Password=ckost598;");
            }
            
            if (btn == 3)
            {
                myConnection = new SqlConnection("Server=sparky.bju.edu;Database=cps301_dreck410;User Id=dreck410;Password=dreck410;");
            }
            try
            {
                myConnection.Open();
                Console.WriteLine("Connected to database");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Did Not Connect");
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public List<string> getPastSongLeaders()
        {
            List<string> leaders = new List<string>();
            string sql = "select distinct (Person.First_Name + ' ' + Person.Last_Name) as Name from service, Person where Service.Songleader_ID = Person.Person_ID";
            this.connect(ConnetionInfo.database,ConnetionInfo.username,ConnetionInfo.pass,ConnetionInfo.option);
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                leaders.Add(myReader["Name"].ToString());
            }
            return leaders;
        }




        public void createSongView() 
        {
            
            try
            {
                string sql = @"CREATE VIEW SongUsageView AS select 
                Max(Service.Svc_DateTime) as LastUsedDate
                ,Song.Song_ID, Song.Title, Song.Arranger, Song.Hymnbook_Num, Song.Song_Type
                from Song
                Left Join ServiceEvent on Song.Song_ID = ServiceEvent.Song_ID
                Left Join Service on ServiceEvent.Service_ID = Service.Service_ID
                WHERE 
                Song.Song_Type <> 'C'
                GROUP BY 
                Song.Song_ID, Song.Title, Song.Arranger, Song.Hymnbook_Num, Song.Song_Type
                ";

                this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                SqlDataReader myReader = null;
                myReader = cmd.ExecuteReader();
            }
            catch
            {
                string sql = @"ALTER VIEW SongUsageView AS select 
                Max(Service.Svc_DateTime) as LastUsedDate
                ,Song.Song_ID, Song.Title, Song.Arranger, Song.Hymnbook_Num, Song.Song_Type
                from Song
                Left Join ServiceEvent on Song.Song_ID = ServiceEvent.Song_ID
                Left Join Service on ServiceEvent.Service_ID = Service.Service_ID
                WHERE 
                Song.Song_Type <> 'C'
                GROUP BY 
                Song.Song_ID, Song.Title, Song.Arranger, Song.Hymnbook_Num, Song.Song_Type
                ";

                this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                SqlDataReader myReader = null;
                myReader = cmd.ExecuteReader();
            }
            try
            {
                string storeProc = @"CREATE PROC LeastUsedSongs
                AS
                SELECT Top 10
                SongUsageView.Title
                FROM SongUsageView
                ORDER BY LastUsedDate ASC, Title ";
                this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
                SqlCommand cmd = new SqlCommand(storeProc, myConnection);
                SqlDataReader myReader = null;
                myReader = cmd.ExecuteReader();

            }
            catch
            { ;}

            
        }

        public int getServiceID(string templateService){
            int serviceID = -1;

            this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
            string sql = "SELECT Service.Service_ID FROM Service WHERE Service.Svc_DateTime = \'" + templateService + "\'";
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            
            myReader.Read();
            try
            {
                serviceID = Convert.ToInt32(myReader["Service_ID"]);
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
            Console.WriteLine(serviceID);
            return serviceID;
        }


        // inserts data into the table
        //  0 is good
        // -1 songleader issue
        // -2 temp issue
        // -3 time issue
        public int insert(string serviceTime, int templateID, string theme, string title, string songLeader)
        {

            addedServiceID = -1;
            int personID = 0;
            if (songLeader != "")
            {
                personID = getPersonID(songLeader);
                if (0 > personID) { return -1; }
            }
            List<int> Seq_Num = new List<int>();
            List<int> EventType_ID = new List<int>();
            List<string> Notes = new List<string>();

            this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
            string personString = personID.ToString();

            
            if (personID == 0)
            {
                personString = "null";
            }
            string insertService = "";
            if (newTime(serviceTime))
            {
                insertService = "insert into Service values ( \'" + serviceTime + "\', \'" + theme + "\', \'" + title + "\', null, \'N\', \'N\', \'N\', null, " + personString + ", null)";
            }
            else
            {
                /* not a new time. 


            string updateEvent = @"UPDATE Service set ..... where Svc_DateTime = serviceTime
               could do update instead of insert...
                 *  */
                return -3;
            }
            this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
            SqlCommand cmd = new SqlCommand(insertService, myConnection);
            cmd.ExecuteNonQuery();

            // needs to get the ID of the new service after the new service has been created!
            int newServiceID = getServiceID(serviceTime);
            if (newServiceID <= 0) { return -2; }


            string serviceEvents = "select Seq_Num, EventType_ID, Notes from ServiceEvent where ServiceEvent.Service_ID = " + templateID.ToString();

            this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
            cmd = new SqlCommand(serviceEvents, myConnection);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            int size = 0;
            while (myReader.Read())
            {
                Seq_Num.Add(Convert.ToInt32(myReader["Seq_Num"]));
                EventType_ID.Add(Convert.ToInt32(myReader["EventType_ID"]));
                Notes.Add(myReader["Notes"].ToString());
                ++size;
            }
            for (int i = 0; i < size; ++i)
            {
                string insertServiceEvent = "insert into ServiceEvent values ( " + newServiceID.ToString() + ", " + Seq_Num[i].ToString() + ", " + EventType_ID[i] + " , '" + Notes[i] + "', 'N', null, null, null)";

                this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
                cmd = new SqlCommand(insertServiceEvent, myConnection);
                cmd.ExecuteNonQuery();
            }
            addedServiceID = newServiceID;
            return 0;
        }

        private bool newTime(string serviceTime)
        {
            bool output = false;
            string selectService = "select * from Service where Svc_DateTime = '" + serviceTime + "'";
            this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
            SqlCommand cmd = new SqlCommand(selectService, myConnection);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            myReader.Read();
            try
            {
                Convert.ToInt32(myReader["Service_ID"]);
                output = false;
            }
            catch (Exception)
            {
                output = true;
            }
            
            return output;
        }

        private int getPersonID(string songLeader)
        {
            int personID = -1;
            string sql = "";
            try
            {
                personID = Convert.ToInt32(songLeader);
                sql = "select Person.Person_ID from Person where Person.Person_ID = " + personID.ToString();
            }
            catch (Exception e)
            {
                string[] fullName = songLeader.Split(' ');
                this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
                sql = "select Person.Person_ID from Person where\'" + fullName[0] + "\' = Person.First_Name and \'" + fullName[1] + "\' = Person.Last_Name";

            }
            this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            myReader.Read();
            try
            {
                personID = Convert.ToInt32(myReader["Person_ID"]);
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
            Console.WriteLine(personID);
            return personID;
        }
        

        internal IEnumerable<string> getValidDates()
        {
            List<string> Dates = new List<string>();
            string sql = "select distinct Svc_DateTime from service";
            this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                Dates.Add(myReader["Svc_DateTime"].ToString());
                DateTime d = Convert.ToDateTime(myReader["Svc_DateTime"].ToString());
                Console.WriteLine(d);
            }
            return Dates;
        }

        internal IEnumerable<string> getCongSongs()
        {
            List<string> congSongs= new List<string>();
            if (addedServiceID == -1) { return congSongs; }
            string getCongSongsSQL = @"select distinct 
                                        ServiceEvent.Seq_Num
                                        , EventType.Description
                                        , Song.Title
                                        from ServiceEvent
                                        Left Join EventType on ServiceEvent.EventType_ID = EventType.EventType_ID
                                        Left Join Song on ServiceEvent.Song_ID = Song.Song_ID
                                        WHERE
                                        ServiceEvent.Service_ID = " + addedServiceID.ToString() + @" 
                                        and (ServiceEvent.EventType_ID = 5 or ServiceEvent.EventType_ID = 11)
                                        and (ServiceEvent.Song_ID = Song.Song_ID or ServiceEvent.Song_ID is null)";
            this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
            SqlCommand cmd = new SqlCommand(getCongSongsSQL, myConnection);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                string line = myReader["Seq_Num"].ToString() + "  |  " + myReader["Description"].ToString() + "  |  " + myReader["Title"].ToString();
                congSongs.Add(line);
            }
            return congSongs;
        }

        internal IEnumerable<string> getSongView()
        {
            List<string> congSongs = new List<string>();
            string getCongSongsSQL = @"select *
                                        from SongUsageView
                                        order by LastUsedDate, Title";
            this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
            SqlCommand cmd = new SqlCommand(getCongSongsSQL, myConnection);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                string line = myReader["Title"].ToString() + "  |  " + myReader["HymnBook_Num"].ToString();
                congSongs.Add(line);
            }
            return congSongs;
        }

        internal string importSongToEvent(string selectedSong, string selectedEvent)
        {
            //0 = Title
            //1 = Hymn Num
            string[] parsedSong = selectedSong.Split('|');
            //0 = Seq_Num
            //1 = Description
            //2 = Title
            string[] parsedEvent = selectedEvent.Split('|');

            int songID = getSongID(parsedSong[0]);
            int eventID = getEventID(parsedEvent[0], parsedEvent[1]);

            string updateEvent = @"UPDATE ServiceEvent
                                    SET Song_ID= " + songID.ToString() + @" 
                                    where Event_ID = " + eventID.ToString();
            this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
            SqlCommand cmd = new SqlCommand(updateEvent, myConnection);
            cmd.ExecuteNonQuery();

            return addedServiceID.ToString();
        }

        private int getEventID(string Seq_Num, string Descr)
        {
            Seq_Num = Seq_Num.Trim();
            Descr = Descr.Trim();
            string EventID = @"select * from ServiceEvent where Seq_Num = " + Seq_Num.ToString() + " and Service_ID = " + addedServiceID.ToString();
            this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
            SqlCommand cmd = new SqlCommand(EventID, myConnection);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            myReader.Read();
            return Convert.ToInt32(myReader["Event_ID"]);
        }

        private int getSongID(string Title)
        {
            Title = Title.Trim();
            string songID = @"select Song_ID from Song where Title = '" + Title + "'";
            this.connect(ConnetionInfo.database, ConnetionInfo.username, ConnetionInfo.pass, ConnetionInfo.option);
            SqlCommand cmd = new SqlCommand(songID, myConnection);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            myReader.Read();
            return Convert.ToInt32(myReader[myReader.GetName(0)]);
        }

        internal void setServiceID(int p)
        {
            addedServiceID = p;
        }
    }
}
