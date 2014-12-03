using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AppDev2
{

    static class DataUpdater  //http://www.codeproject.com/Articles/4416/Beginners-guide-to-accessing-SQL-Server-through-C

    {
        public static void connect()
        {
            // connect to sparky - recker
            /*SqlConnection myConnection = new SqlConnection("user id=username;" +
                                       "password=password;server=serverurl;" +
                                       "Trusted_Connection=yes;" +
                                       "database=database; " +
                                       "connection timeout=30");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }*/
        }
        
        
        //blah blah do the good stuff here


        public static void insertService(DateTime serviceDateTime, DateTime templateDateTime, string title, string theme, string SongLeader)
        {
            throw new NotImplementedException();
        }
    }
}
