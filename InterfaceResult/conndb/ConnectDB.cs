using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace InterfaceResult.conndb
{
    internal class ConnectDb
    {
        public MySqlConnection Con;

        public string ConnectionString;

        public List<string> Connlist = new List<string>();
        public string IniHostname { get; set; }
        public string IniUsername { get; set; }
        public string IniPassword { get; set; }
        public string IniDatabase { get; set; }
        public string IniPort { get; set; }
        public string IniPath { get; set; }

        public void Getconnstring()
        {
            Loadconnect_ini();
            ConnectionString = "datasource=" + IniHostname + "; database=" + IniDatabase + "; port =" + IniPort + "; username =" + IniUsername + "; password=" + IniPassword + "; SslMode =none;POOLING=FALSE;";
            Con = new MySqlConnection(ConnectionString);
        }

        public void Loadconnect_ini()
        {
            var fileconnect = @"C:\INI_InterfaceResult\config_InterfaceResult.ini";
            try
            {
                var fileStream = new FileStream(fileconnect, FileMode.Open, FileAccess.Read);
                using var streamreader = new StreamReader(fileStream, Encoding.UTF8);
                string line;
                while ((line = streamreader.ReadLine()) != null) Connlist.Add(line);

                IniPath = Connlist[0];
                IniHostname = Connlist[1];
                IniDatabase = Connlist[2];
                IniUsername = Connlist[3];
                IniPassword = Connlist[4];
                IniPort = Connlist[5];
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Load config ini file failed" + ex.Message);
            }
        }
    }
}