using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AppDev2
{

    // singleton
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

        public string getPastSongLeaders()
        {
            string output = "";
            string sql = "select distinct (Person.First_Name + ' ' + Person.Last_Name) as Name from service, Person where Service.Songleader_ID = Person.Person_ID";
            this.connect();
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                output += myReader["Name"] + "\n";
            }
            Console.WriteLine(output);
            return output;
        }

        public int getTemplateServiceID(string templateService){
            int serviceID = -1;

            this.connect();
            string sql = "SELECT Service.Service_ID FROM Service WHERE Service.Svc_DateTime = \'" + templateService + "\'";
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            
            myReader.Read();
            serviceID = Convert.ToInt32(myReader["Service_ID"]);
            Console.WriteLine(serviceID);
            return serviceID;
        }


        // inserts data into the table
        public void insert(int templateID, string theme, string title, string songLeader)
        {
            string sql = "INSERT INTO student (name)";
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            cmd.ExecuteNonQuery();
        }
    }
}
