using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace ConsoleServer
{
    class MySqlConnector
    {
        MySqlConnection mConnection;
        public void Connect()
        {
            string connStr = "server=localhost;user=root;database=greenv;port=3306;password=";
            mConnection = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                mConnection.Open();

              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                mConnection = null;
            }
            
        }

        public void Close()
        {
            if(mConnection != null)
            {

                mConnection.Close();
                Console.WriteLine("MYSQL Connection Close.");
            }
        }

        public void Select()
        {
            string sql = "SELECT * FROM sensordata WHERE id='0'";
            MySqlCommand cmd = new MySqlCommand(sql, mConnection);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + " -- " + rdr[1]);
            }
            rdr.Close();
        }


        public void InsertSensor(string dv,int timestamp,int data)
        {
            try
            {
                string sql = string.Format("INSERT INTO app_sensordata (device,timestamp,sensorvalue) VALUES ('{0}',{1},{2})", dv, timestamp, data);

                MySqlCommand cmd = new MySqlCommand(sql, mConnection);
                cmd.ExecuteNonQuery();



                Console.WriteLine(string.Format("Insert app_sensordata : {0} {1} {2} ", dv, timestamp, data));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public void InsertGroundTruth(string dv, string timestamp, string lr)
        {
            try
            {
                string sql = string.Format("INSERT INTO app_groundtruthdata (device,timestamp,leftright) VALUES ('{0}',{1},{2})", dv, timestamp, lr);

                MySqlCommand cmd = new MySqlCommand(sql, mConnection);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine(string.Format("Insert app_groundtruthdata : {0} {1} {2} ", dv, timestamp, lr));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

    }
}
