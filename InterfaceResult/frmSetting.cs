using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using InterfaceResult.conndb;
using MySql.Data.MySqlClient;

namespace InterfaceResult
{
    public partial class FrmSetting : Form
    {
        private readonly ConnectDb _connectDb = new ConnectDb();
        private bool _chkconn;
        private bool _chkpath;

        public FrmSetting()
        {
            InitializeComponent();
            _connectDb.Loadconnect_ini();
            tbResultDataSourcePath.Text = _connectDb.IniPath;
            tbMySqlDataSourceHostName.Text = _connectDb.IniHostname;
            tbMySqlDataSourceDatabaseName.Text = _connectDb.IniDatabase;
            tbMySqlDataSourceUserName.Text = _connectDb.IniUsername;
            tbMySqlDataSourcePassword.Text = _connectDb.IniPassword;
            tbMySqlDataSourcePort.Text = _connectDb.IniPort;
        }

        public void Writeinifile() //------ Create InterfaceRequest Settings INI file--------//
        {
            var pathiniconfigfile = @"C:\INI_InterfaceResult";
            var configfile = @"C:\INI_InterfaceResult\config_InterfaceResult.ini";
            Directory.CreateDirectory(pathiniconfigfile);
            var create = File.Open(configfile, FileMode.Create);
            using var newtask = new StreamWriter(create);
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
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            Writeinifile();
            Close();
        }

        private void lilResultDataSourceStatus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(tbResultDataSourcePath.Text))
            {
                MessageBox.Show(@"Path Available !");
                lblResultDataSourceStatusValue.Text = @"Connected !";
                lblResultDataSourceStatusValue.ForeColor = Color.Green;
                _chkpath = true;
                Checksaveini();
            }
            else
            {
                MessageBox.Show(@"Path doesn't exist");
                lblResultDataSourceStatusValue.Text = @"Path Not Connect !";
                lblResultDataSourceStatusValue.ForeColor = Color.Red;
                btnSave.Enabled = false;
            }
        }

        private void lilCheckMySqlDatasourceStatus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MySqlConnection con;

            string connectionString;
            string hostname;
            string username;
            string password;
            string database;
            string port;

            try
            {
                hostname = tbMySqlDataSourceHostName.Text;
                username = tbMySqlDataSourceUserName.Text;
                password = tbMySqlDataSourcePassword.Text;
                database = tbMySqlDataSourceDatabaseName.Text;
                port = tbMySqlDataSourcePort.Text;

                connectionString = "datasource=" + hostname + "; database=" + database + "; port =" + port + "; username =" + username + "; password=" + password + "; SslMode =none;";
                con = new MySqlConnection(connectionString);

                con.Open();
                MessageBox.Show(@"Connection Available !");
                lblMySqlDatasourceStatusValue.Text = @"Connected !";
                lblMySqlDatasourceStatusValue.ForeColor = Color.Green;
                _chkconn = true;
                Checksaveini();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Can not Connect !" + exception.Message);
                lblMySqlDatasourceStatusValue.Text = @"Not Connected !";
                lblMySqlDatasourceStatusValue.ForeColor = Color.Red;
                btnSave.Enabled = false;
            }
        }
    }
}