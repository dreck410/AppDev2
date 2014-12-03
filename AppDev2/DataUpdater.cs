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
            int tempServID = dataBaseConnector.Instance.getTemplateServiceID("\'2010-10-03 10:30:00:000\'");
           // throw new NotImplementedException();
        }
    }
}
