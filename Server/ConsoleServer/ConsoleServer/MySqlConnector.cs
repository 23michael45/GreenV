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


        public void Insert(string dv,int timestamp,int data)
        {
            string sql = string.Format("INSERT INTO sensordata (device,timestamp,sensorvalue) VALUES ('{0}',{1},{2})",dv,timestamp,data);

            MySqlCommand cmd = new MySqlCommand(sql, mConnection);
            cmd.ExecuteNonQuery();
            
        }

    }
}
