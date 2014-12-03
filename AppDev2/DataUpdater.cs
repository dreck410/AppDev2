using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;

namespace AppDev2
{

    class DataUpdater  //http://www.codeproject.com/Articles/4416/Beginners-guide-to-accessing-SQL-Server-through-C
    {

        //blah blah do the good stuff here
        

        public static void insertService(DateTime serviceDateTime, DateTime templateDateTime, string title, string theme, string SongLeader)
        {
            int tempServID = dataBaseConnector.Instance.getTemplateServiceID("2010-10-03 10:30:00");
            /*
             * Insert records into the ServiceEvent table for the new service based on the events in the template service, 
             * except that the specific songs, personnel, and ensembles should be left blank. For example, if the user enters
             * 10/3/2010 10am for the date/time for the template service, the program should insert ServiceEvent records for the 
             * new service that have the same sequence numbers and event types as those for the 10/3/2010 10am service. (10 points)
             */
            //dataBaseConnector.Instance.insert
           // throw new NotImplementedException();
        }
    }
}
