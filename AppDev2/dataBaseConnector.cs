﻿using System;
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

        public int getServiceID(string templateService){
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
        public void insert(string serviceTime, int templateID, string theme, string title, string songLeader)
        {
            int personID = getPersonID(songLeader);
            List<int> Seq_Num = new List<int>();
            List<int> EventType_ID = new List<int>();
            List<string> Notes = new List<string>();

            this.connect();
            string insertService = "insert into Service values ( \'"+ serviceTime +"\', \'" + theme + "\', \'" + title + "\', null, \'N\', \'N\', \'N\', null, null, null";
            int newServiceID = getServiceID(serviceTime);
            SqlCommand cmd = new SqlCommand(insertService, myConnection);
            Console.WriteLine("Rows affected "+cmd.ExecuteNonQuery().ToString());



            string serviceEvents = "select Seq_Num, EventType_ID, Notes from ServiceEvent where ServiceEvent.Service_ID = " + templateID.ToString();

            cmd = new SqlCommand(serviceEvents, myConnection);
            SqlDataReader myReader = null;
            myReader = cmd.ExecuteReader();
            int size = 0;
            while (myReader.Read())
            {
                Seq_Num.Add(Convert.ToInt32(myReader["Event_ID"]));
                EventType_ID.Add(Convert.ToInt32(myReader["EventType_ID"]));
                Notes.Add(myReader["Notes"].ToString());
                ++size;
            }
            for (int i = 0; i < size; ++i)
            {
                string insertServiceEvent = "insert into ServiceEvent values ( " + newServiceID.ToString() + ", " + Seq_Num[i].ToString() + ", " + EventType_ID[i] + " , '" + Notes[i] + "', 'N', null, null, null)";

                cmd = new SqlCommand(insertServiceEvent, myConnection);
                cmd.ExecuteNonQuery();
            }
        }

        private int getPersonID(string songLeader)
        {

            int personID = -1;
            try
            {
                personID = Convert.ToInt32(songLeader);
            }
            catch (Exception e)
            {
                string[] fullName = songLeader.Split(' ');
                this.connect();
                string sql = "select Person.Person_ID from Person where\'" + fullName[0] + "\' = Person.First_Name and \'" + fullName[1] + "\' = Person.Last_Name";
                SqlCommand cmd = new SqlCommand(sql, myConnection);
                SqlDataReader myReader = null;
                myReader = cmd.ExecuteReader();

                myReader.Read();
                personID = Convert.ToInt32(myReader["Person_ID"]);
                Console.WriteLine(personID);
            }

            return personID;
        }
    }
}
