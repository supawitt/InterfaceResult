using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace InterfaceRequest.conndb
{
    internal class ConnectDB
    {
        public MySqlConnection con;

        public string connection_string;
        public string INI_hostname { get; set; }
        public string INI_username { get; set; }
        public string INI_password { get; set; }
        public string INI_database { get; set; }
        public string INI_port { get; set; }
        public string INI_path { get; set; }

        public List<string> connlist = new List<string>();

        public void Getconnstring()
        {
            Loadconnect_ini();
            connection_string = "datasource=" + INI_hostname + "; database=" + INI_database + "; port =" + INI_port + "; username =" + INI_username + "; password=" + INI_password + "; SslMode =none;";
            con = new MySqlConnection(connection_string);
        }

        public void Loadconnect_ini()
        {
            string fileconnect = @"C:\INI_InterfaceResult\config_InterfaceResult.ini";
            try
            {
                var fileStream = new FileStream(fileconnect, FileMode.Open, FileAccess.Read);
                using var streamreader = new StreamReader(fileStream, Encoding.UTF8);
                string line;
                while ((line = streamreader.ReadLine()) != null)
                {
                    connlist.Add(line);
                }

                INI_path     = connlist[0].ToString();
                INI_hostname = connlist[1].ToString();
                INI_database = connlist[2].ToString();
                INI_username = connlist[3].ToString();
                INI_password = connlist[4].ToString();
                INI_port     = connlist[5].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load config conn failed" + ex.Message);
            }
        }
    }
}