using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;

namespace ConsoleServer
{
    public class MySqlConnector
    {
        MySqlConnection mConnection;
        public void Connect()
        {


            FileStream fs = new FileStream("dbconfig.txt", FileMode.Open);
            var file = new System.IO.StreamReader(fs, System.Text.Encoding.UTF8, true, 128);

            List<string> cmdlist = new List<string>();
            string connStr = file.ReadLine();
            fs.Close();
            
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


        public void InsertSensor(string dv, UInt32 timestamps, UInt32 timestampms,byte[] data)
        {
            try
            {
                string sql = string.Format("INSERT INTO app_sensordata (device,timestamps,timestampms,sensorvalue) VALUES ('{0}',{1},{2},(@blobData))", dv, timestamps,timestampms, data);




                MySqlParameter par = new MySqlParameter("@blobData", MySqlDbType.Blob);
                par.Value = data;
                MySqlCommand cmd = new MySqlCommand(sql, mConnection);
                cmd.Parameters.Add(par);
                cmd.ExecuteNonQuery();
                Console.WriteLine(string.Format("Insert app_sensordata : {0} {1} {2}", dv, timestamps,timestampms));


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public void InsertGroundTruth(string dv, string timestamp, Int16 lr)
        {
            try
            {
                string sql = string.Format("INSERT INTO app_groundtruthdata (device,timestamp,leftright) VALUES ('{0}','{1}',{2})", dv, timestamp, lr);


                MySqlCommand cmd = new MySqlCommand(sql, mConnection);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine(string.Format("Insert app_groundtruthdata : {0} {1} {2} ", dv, timestamp, lr));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }



        public void SaveTxt()
        {
            SaveSensor();
            SaveGroundTruth();


            string sql = string.Format("TRUNCATE TABLE app_sensordata");
            MySqlCommand cmd = new MySqlCommand(sql, mConnection);
            cmd.ExecuteNonQuery();

            sql = string.Format("TRUNCATE TABLE app_groundtruthdata");
            cmd = new MySqlCommand(sql, mConnection);
            cmd.ExecuteNonQuery();
        }

        void SaveSensor()
        {
            FileStream fs = new FileStream("sensor.txt", FileMode.OpenOrCreate);
            var file = new System.IO.StreamWriter(fs);



            string sql = string.Format("select * from app_sensordata");
            MySqlCommand cmd = new MySqlCommand(sql, mConnection);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string device = rdr.GetString(1);
                UInt32 timestamps = rdr.GetUInt32(2);
                UInt32 timestampms = rdr.GetUInt32(3);



                byte[] data = new byte[1200];
                long len = rdr.GetBytes(4, 0, data, 0, 1200);
                MemoryStream ms = new MemoryStream(data);
                BinaryReader reader = new BinaryReader(ms);



                string s = string.Format("id:{0} device:{1} timestamp:{2} : {3}  data: ", id, device, timestamps,timestampms);
                for (int i = 0; i < len/2; i++)
                {
                    UInt16 d = reader.ReadUInt16();
                    s += " " + d.ToString();
                }
                file.WriteLine(s);
            }

            rdr.Close();

            file.Flush();
            fs.Close();
        }
        void SaveGroundTruth()
        {
            FileStream fs = new FileStream("groundtruth.txt", FileMode.OpenOrCreate);
            var file = new System.IO.StreamWriter(fs);



            string sql = string.Format("select * from app_groundtruthdata");
            MySqlCommand cmd = new MySqlCommand(sql, mConnection);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string device = rdr.GetString(1);
                string timestamp = rdr.GetString(2);
                int leftright = rdr.GetInt16(3);

                

                string s = string.Format("id:{0} device:{1} timestamp:{2} leftright:{3} ", id, device, timestamp, leftright);
               
                file.WriteLine(s);
            }

            rdr.Close();

            file.Flush();
            fs.Close();
        }
    }
}
