using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace AppDev2
{

    // singletons
    // manages the connection to the db
    class dataBaseConnector
    {

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

        public void connect()
        {
            //myConnection = new SqlConnection("Server=sparky.bju.edu; Database=cps301_dreck410; Trusted_Connection=True;");
            myConnection = new SqlConnection("Server=sparky.bju.edu;Database=cps301_dreck410;User Id=dreck410;Password=dreck410;");
            try
            {
                myConnection.Open();
                Console.WriteLine("Connected to database");

            }
            catch (Exception e)
            {
                Console.WriteLine("Did Not Connect");
                Console.WriteLine(e.ToString());
            }
        }

        public List<string> getPastSongLeaders()
        {
            List<string> leaders = new List<string>();
            string sql = "select distinct (Person.First_Name + ' ' + Person.Last_Name) as Name from service, Person where Service.Songleader_ID = Person.Person_ID";
            this.connect();
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                leaders.Add(myReader["Name"].ToString());
            }
            return leaders;
        }
         
        public void createSongView() //SUCESSFULLY CREATES VIEW JUST NEED TO ADJUST LastUsedDate To be linked to most recently used
        {
            /*Create a SQL Server view named SongUsageView that displays all of the colums in the Song table,plus one named LastUsedDate. 
             * The LastUsedDate column should contain the date of the most recent service that used that song. 
             * (Exclude choral songs, but be sure to include songs which have never been used).
             * Using this view, display 20 of the least recently used songs, ordered by LastUsedDate, and then song title. 
             * Allow the user to select songs from this list, and assign them to the congregational song events. (10 points)*/
            try
            {
                string sql = "CREATE VIEW SongUsageView AS SELECT dbo.Song.*,dbo.Service.Svc_DateTime as 'LastUsedDate'FROM Song,Service"; //Still need to add in LastUsedDate into this query
                this.connect();
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                SqlDataReader myReader = null;
                myReader = cmd.ExecuteReader();
            }
            catch
            {
                string sql = "ALTER VIEW SongUsageView AS SELECT dbo.Song.*,dbo.Service.Svc_DateTime as 'LastUsedDate'FROM Song,Service"; //Still need to add in LastUsedDate into this query
                this.connect();
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                SqlDataReader myReader = null;
                myReader = cmd.ExecuteReader();
            }

            
        }

        public int getServiceID(string templateService){
            int serviceID = -1;

            this.connect();
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
        //0 is good
        // -1 songleader issue
        // -2 temp issue
        public int insert(string serviceTime, int templateID, string theme, string title, string songLeader)
        {
            int personID = 0;
            if (songLeader != "")
            {
                personID = getPersonID(songLeader);
                if (0 > personID) { return -1; }
            }
            int newServiceID = getServiceID(serviceTime);
            if (newServiceID <= 0) { return -2; }

            List<int> Seq_Num = new List<int>();
            List<int> EventType_ID = new List<int>();
            List<string> Notes = new List<string>();

            this.connect();
            string personString = personID.ToString();

            
            if (personID == 0)
            {
                personString = "null";
            }
            
            string insertService = "insert into Service values ( \'" + serviceTime + "\', \'" + theme + "\', \'" + title + "\', null, \'N\', \'N\', \'N\', null, " + personString + ", null)";

            SqlCommand cmd = new SqlCommand(insertService, myConnection);
            Console.WriteLine("Rows affected " + cmd.ExecuteNonQuery().ToString());



            string serviceEvents = "select Seq_Num, EventType_ID, Notes from ServiceEvent where ServiceEvent.Service_ID = " + templateID.ToString();

            this.connect();
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

                this.connect();
                cmd = new SqlCommand(insertServiceEvent, myConnection);
                cmd.ExecuteNonQuery();
            }
            return 0;
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
                this.connect();
                sql = "select Person.Person_ID from Person where\'" + fullName[0] + "\' = Person.First_Name and \'" + fullName[1] + "\' = Person.Last_Name";

            }
            this.connect();
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
        /*THIS IS FOR +3 POINTS, LET USER CHOOSE SONGLEADERNAMES FROM DROP DOWN. HERE IS WORKING QUERY, JSUT NEED TO MAKE METHOD
         * Select First_Name+' '+Last_Name as "name"
         * FROM dbo.Person,dbo.Service
         * WHERE dbo.Person.Person_ID = dbo.Service.Songleader_ID
         * */
    }
}
