using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InterfaceRequest.conndb;
using MySql.Data.MySqlClient;

namespace InterfaceResult
{
    public partial class frmSetting : Form
    {
        private readonly ConnectDB _connectDb = new ConnectDB();
        private bool _chkpath = false;
        private bool _chkconn = false;

        public frmSetting()
        {
            InitializeComponent();
            _connectDb.Loadconnect_ini();
            tbResultDataSourcePath.Text        = _connectDb.INI_path;
            tbMySqlDataSourceHostName.Text     = _connectDb.INI_hostname;
            tbMySqlDataSourceDatabaseName.Text = _connectDb.INI_database;
            tbMySqlDataSourceUserName.Text     = _connectDb.INI_username;
            tbMySqlDataSourcePassword.Text     = _connectDb.INI_password;
            tbMySqlDataSourcePort.Text         = _connectDb.INI_port;
        }
        public void Writeinifile() //------ Create InterfaceRequest Settings INI file--------//
        {
            string pathiniconfigfile = @"C:\INI_InterfaceResult";
            string configfile = @"C:\INI_InterfaceResult\config_InterfaceResult.ini";
            System.IO.Directory.CreateDirectory(pathiniconfigfile);
            FileStream create = File.Open(configfile, FileMode.Create);
            using StreamWriter newtask = new StreamWriter(create);
            newtask.WriteLine(tbResultDataSourcePath.Text);
            newtask.WriteLine(tbMySqlDataSourceHostName.Text);
            newtask.WriteLine(tbMySqlDataSourceDatabaseName.Text);
            newtask.WriteLine(tbMySqlDataSourceUserName.Text);
            newtask.WriteLine(tbMySqlDataSourcePassword.Text);
            newtask.WriteLine(tbMySqlDataSourcePort.Text);
            newtask.WriteLine("\n");
            newtask.WriteLine(
                "-------------------------------------- Reference Connection Settings--------------------------------------");
            newtask.WriteLine("[Request Data Source]\n");
            newtask.WriteLine("Path = " + tbResultDataSourcePath.Text + "\n\n\n");
            newtask.WriteLine("[MySQL Data Source]\n");
            newtask.WriteLine("Hostname = " + tbMySqlDataSourceHostName.Text);
            newtask.WriteLine("Database = " + tbMySqlDataSourceDatabaseName.Text);
            newtask.WriteLine("Username = " + tbMySqlDataSourceUserName.Text);
            newtask.WriteLine("P@ssw0rd = " + tbMySqlDataSourcePassword.Text);
            newtask.WriteLine("Port = " + tbMySqlDataSourcePort.Text);
        }

        private void Checksaveini()
        {

            if (_chkconn && _chkpath)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            Writeinifile();
            this.Close();
        }

        private void lilResultDataSourceStatus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(tbResultDataSourcePath.Text))
            {
                MessageBox.Show(@"Path Available !");
                lblResultDataSourceStatusValue.Text = @"Connected !";
                lblResultDataSourceStatusValue.ForeColor = System.Drawing.Color.Green;
                _chkpath = true;
                Checksaveini();
            }
            else
            {
                MessageBox.Show(@"Path doesn't exist");
                lblResultDataSourceStatusValue.Text = @"Path Not Connect !";
                lblResultDataSourceStatusValue.ForeColor = System.Drawing.Color.Red;
                btnSave.Enabled = false;
            }
        }

        private void lilCheckMySqlDatasourceStatus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MySqlConnection con;

            string connectionString = null;
            string hostname = null;
            string username = null;
            string password = null;
            string database = null;
            string port = null;

            try
            {
                hostname = tbMySqlDataSourceHostName.Text;
                username = tbMySqlDataSourceUserName.Text;
                password = tbMySqlDataSourcePassword.Text;
                database = tbMySqlDataSourceDatabaseName.Text;
                port     = tbMySqlDataSourcePort.Text;

                connectionString = "datasource=" + hostname + "; database=" + database + "; port =" + port + "; username =" + username + "; password=" + password + "; SslMode =none;";
                con = new MySqlConnection(connectionString);

                con.Open();
                MessageBox.Show(@"Connection Available !");
                lblMySqlDatasourceStatusValue.Text = @"Connected !";
                lblMySqlDatasourceStatusValue.ForeColor = System.Drawing.Color.Green;
                _chkconn = true;
                Checksaveini();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Can not Connect !" + exception.Message);
                lblMySqlDatasourceStatusValue.Text = @"Not Connected !";
                lblMySqlDatasourceStatusValue.ForeColor = System.Drawing.Color.Red;
                btnSave.Enabled = false;
            }
        }
    }
}
