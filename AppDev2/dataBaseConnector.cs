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

        public int getTemplateServiceID(string templateService){
            int serviceID = -1;

            this.connect();
            string sql = "SELECT Service.Service_ID FROM Service WHERE Service.Svc_DateTime = " + templateService;
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                Console.WriteLine(myReader["Service_ID"].ToString());
            }
            return serviceID;
        }

        // inserts data into the table
        public void insert(string sql)
        {
            sql = "INSERT INTO student (name)";
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            cmd.ExecuteNonQuery();
        }
    }
}
