﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using NetCoreMvcServer.Models;

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

        public List<App_SensorData> QueryTimeIP(string ip,DateTime startdt,DateTime enddt)
        {
            string sql = string.Format("SELECT * FROM app_sensordata WHERE device='{0}' and createtime between '{1}' and '{2}'" , ip,startdt.ToString("yyyy/MM/dd HH:mm:ss"),enddt.ToString("yyyy/MM/dd HH:mm:ss"));
            MySqlCommand cmd = new MySqlCommand(sql, mConnection);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<App_SensorData> list = new List<App_SensorData>();

            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + " -- " + rdr[1]);

                App_SensorData data = new App_SensorData();
                data.Id = Guid.Parse(rdr[0].ToString());
                data.createtime = DateTime.Parse(rdr[1].ToString());
                data.device = rdr[2].ToString();
                data.gain = Convert.ToInt16(rdr[3].ToString());
                data.rate = Convert.ToInt16(rdr[4].ToString());
                data.sensorvalue = (byte[])rdr[5];
                data.timestampms = Convert.ToInt16(rdr[6].ToString());
                data.timestamps = Convert.ToInt16(rdr[7].ToString());

                list.Add(data);

            }
            rdr.Close();
            return list;
        }


        public void InsertSensor(string dv, UInt32 timestamps, UInt32 timestampms, UInt16 rate,UInt16 gain,byte[] data)
        {
            try
            {
                DateTime dt = DateTime.Now;
                Guid Id = Guid.NewGuid();

                string sql = string.Format("INSERT INTO app_sensordata (Id,device,timestamps,timestampms,rate,gain,createtime,sensorvalue) VALUES ('{0}','{1}',{2},{3},{4},{5},(@createtime),(@blobData))", Id, dv, timestamps, timestampms, rate, gain);
                
                MySqlParameter blobData = new MySqlParameter("@blobData", MySqlDbType.Blob);
                blobData.Value = data;

                MySqlParameter createtime = new MySqlParameter("@createtime", MySqlDbType.DateTime);
                createtime.Value = dt;

                MySqlCommand cmd = new MySqlCommand(sql, mConnection);
                cmd.Parameters.Add(blobData);
                cmd.Parameters.Add(createtime);
                //cmd.Parameters.AddWithValue("@createtime", createtime);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public void InsertGroundTruth(string dv, int timestamp ,int timestampms,byte nodeindex, byte lr)
        {
            try
            {
                DateTime dt = DateTime.Now;
                string sql = string.Format("INSERT INTO app_groundtruthdata (device,timestamp,timestampms,nodeindex,leftright,createtime) VALUES ('{0}',{1},{2},{3},{4},(@createtime))", dv, timestamp, timestampms,nodeindex, lr);

                MySqlParameter createtime = new MySqlParameter("@createtime", MySqlDbType.DateTime);
                createtime.Value = dt;


                MySqlCommand cmd = new MySqlCommand(sql, mConnection);

                cmd.Parameters.Add(createtime);
                cmd.ExecuteNonQuery();

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
                int timestamps = rdr.GetInt32(6);
                int timestampms = rdr.GetInt32(5);
                int rate = rdr.GetInt32(3);
                int gain = rdr.GetInt32(2);



                byte[] data = new byte[1200];
                long len = rdr.GetBytes(4, 0, data, 0, 1200);
                MemoryStream ms = new MemoryStream(data);
                BinaryReader reader = new BinaryReader(ms);



                string s = string.Format("id:{0} device:{1} timestamp:{2} : {3}  rate: {4}  gain:{5} data: ", id, device, timestamps,timestampms,rate,gain);
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
                string timestamp = rdr.GetString(3);
                int leftright = rdr.GetInt16(2);

                

                string s = string.Format("id:{0} device:{1} timestamp:{2} leftright:{3} ", id, device, timestamp, leftright);
               
                file.WriteLine(s);
            }

            rdr.Close();

            file.Flush();
            fs.Close();
        }

      
        public class InputSensorData
        {
            public int _id;
            public string _device;
            public int _timestamps;
            public int _timestampms;
            public byte[] _data;
        }

        static List<InputSensorData> datalist = new List<InputSensorData>();
        public static void TransferReadDB()
        {
            FileStream fs = new FileStream("dbconfig.txt", FileMode.Open);
            var file = new System.IO.StreamReader(fs, System.Text.Encoding.UTF8, true, 128);

            List<string> cmdlist = new List<string>();
            string connStr = file.ReadLine();
            fs.Close();

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();


                string sql = string.Format("select * from app_sensordata");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int id = rdr.GetInt32(0);
                    string device = rdr.GetString(1);
                    int timestamps = rdr.GetInt32(2);
                    int timestampms = rdr.GetInt32(3);
                    //int rate = rdr.GetInt32(3);
                    //int gain = rdr.GetInt32(2);



                    byte[] data = new byte[1200];
                    long len = rdr.GetBytes(4, 0, data, 0, 1200);


                    InputSensorData isd = new InputSensorData();
                    isd._device = device;
                    isd._timestamps = timestamps;
                    isd._timestampms = timestampms;
                    isd._data = data;

                    datalist.Add(isd);

                    
                }

                rdr.Close();
                fs.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn = null;
            }
        }
        public static void TransferWriteDB()
        {
            FileStream fs = new FileStream("dbconfig2.txt", FileMode.Open);
            var file = new System.IO.StreamReader(fs, System.Text.Encoding.UTF8, true, 128);

            List<string> cmdlist = new List<string>();
            string connStr = file.ReadLine();
            fs.Close();

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();



                int count = 0;
                foreach(InputSensorData isd in datalist)
                {
                    Guid Id = Guid.NewGuid();
                    string dv = isd._device;
                    int timestamps = isd._timestamps;
                    int timestampms = isd._timestampms;

                    int rate = count / 30;
                    int gain = count / 15;

                    byte[] data = isd._data;


                    DateTime dt = DateTime.Now;
                    dt.AddHours(count / 10);

                    string sql = string.Format("INSERT INTO app_sensordata (Id,device,timestamps,timestampms,rate,gain,createtime,sensorvalue) VALUES ('{0}','{1}',{2},{3},{4},{5},(@createtime),(@blobData))", Id,dv, timestamps, timestampms, rate, gain);




                    MySqlParameter blobData = new MySqlParameter("@blobData", MySqlDbType.Blob);
                    blobData.Value = data;

                    MySqlParameter createtime = new MySqlParameter("@createtime", MySqlDbType.DateTime);
                    createtime.Value = dt;

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.Add(blobData);
                    cmd.Parameters.Add(createtime);
                    //cmd.Parameters.AddWithValue("@createtime", createtime);
                    cmd.ExecuteNonQuery();

                    
                    count++;
                }

              
                fs.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn = null;
            }
        }
        public static void TransferDB()
        {
            TransferReadDB();
            TransferWriteDB();
       
        }
    }



   
}
