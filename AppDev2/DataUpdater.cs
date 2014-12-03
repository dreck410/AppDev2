using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AppDev2
{

    class DataUpdater  //http://www.codeproject.com/Articles/4416/Beginners-guide-to-accessing-SQL-Server-through-C

    {
        public static void connect()
        {
            SqlConnection myConnection = new SqlConnection("Server = sparky.bju.edu;Databse=Cps301;Trusted_Connection=True;");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("Connected to database");
        }
        
        
        //blah blah do the good stuff here
        public 


        static void insertService(DateTime serviceDateTime, DateTime templateDateTime, string title, string theme, string SongLeader)
        {
            throw new NotImplementedException();
        }
    }
}
