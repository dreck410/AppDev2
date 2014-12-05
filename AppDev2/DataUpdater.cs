using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;
namespace AppDev2
{

    class DataUpdater  //http://www.codeproject.com/Articles/4416/Beginners-guide-to-accessing-SQL-Server-through-C
    {

        //blah blah do the good stuff here
        public static bool validateDateTime(string date, string time, string tempDate, string tempTime)
        {
             bool invalid=true;
             try
             {

                // DateTime serviceDateTime = DateTime.ParseExact(date + " " + time, "MM/dd/yyyy hh:mm:ss ", CultureInfo.InvariantCulture);
                // DateTime templateDateTime = DateTime.ParseExact(tempDate + " " + tempTime, "MM/dd/yyyy hh:mm:ss ", CultureInfo.InvariantCulture);
                 DateTime serviceDateTime = Convert.ToDateTime(date + " " + time);
                 DateTime templateDateTime = Convert.ToDateTime(tempDate + " " + tempTime);
                 invalid = false;


                 return invalid;
             }
             catch { return true; }
        }

        public static int insertService(DateTime serviceDateTime, DateTime templateDateTime, string title, string theme, string SongLeader)
        {
            Console.WriteLine(templateDateTime.ToString());
            Console.WriteLine(templateDateTime.ToShortDateString());
            Console.WriteLine(templateDateTime.ToShortTimeString());
            int tempServID = dataBaseConnector.Instance.getServiceID(templateDateTime.ToString());
            if (-1 == tempServID)
            {
                return -2;
            }
            /*
             * Insert records into the ServiceEvent table for the new service based on the events in the template service, 
             * except that the specific songs, personnel, and ensembles should be left blank. For example, if the user enters
             * 10/3/2010 10am for the date/time for the template service, the program should insert ServiceEvent records for the 
             * new service that have the same sequence numbers and event types as those for the 10/3/2010 10am service. (10 points)
             */
            int result = dataBaseConnector.Instance.insert(serviceDateTime.ToString(), tempServID, theme, title, SongLeader);
            return result;
            //dataBaseConnector.Instance.insert
           // throw new NotImplementedException();
        }
    }
}
