using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using InterfaceRequest.conndb;

namespace InterfaceResult
{
    public partial class frmMain : Form
    {
        #region Attributes
        private readonly ConnectDB connectDB = new ConnectDB();
        private Point pointClick = new Point();
        private bool isStop = false;
        private readonly Stopwatch watch = new Stopwatch();
        public List<string> datalist = new List<string>();
        #endregion

        #region Operations
        private void CheckStartStop()
        {
            if (this.isStop == true)
            {
                #region//-set status stop
                //-set lblStatus
                this.lblStatus.Text = "Status: Stop";
                this.lblStatus.ForeColor = System.Drawing.Color.Red;
                //-set timer
                this.tmrMain.Enabled = false;
                this.stopwatch.Enabled = false;
                //-set button
                this.btnStart.Enabled = true;
                this.btnStop.Enabled = false;
                this.lilSetting.Enabled = true;
                #endregion
            }
            else
            {
                #region//-set status start
                //-set lblStatus
                this.lblStatus.Text = "Status: Start";
                this.lblStatus.ForeColor = System.Drawing.Color.Blue;
                //-set txtActive
                this.txtActive.ForeColor = Color.Black;
                //-set timer
                this.tmrMain.Enabled = true;
                //-loop to start
                tmrMain.Interval = 2000;
                #endregion
            }
        }
        #endregion
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            #region//-check process running
            Process currentProcess = Process.GetCurrentProcess();
            Process[] localAll = Process.GetProcesses();
            foreach (Process localProces in localAll)
            {
                if (currentProcess.ProcessName == localProces.ProcessName &&
                    currentProcess.Id != localProces.Id)
                {
                    //Duplicate Process
                    MessageBox.Show("Program already running.", "Program start", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    currentProcess.Kill();
                    this.Close();
                }
            }
            #endregion

            //-set screen
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            return;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            return;
        }
        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - pointClick.X;
                this.Top += e.Y - pointClick.Y;
            }
            return;
        }
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pointClick = e.Location;
            }
            return;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            //-set isStop
            this.isStop = false;
            CheckStartStop();
            //-set timer
            this.tmrMain.Interval = 2000;
            this.tmrMain.Enabled = true;
            //-set button
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            this.lilSetting.Enabled = false;
            //-set stopwatch
            watch.Start();
            this.stopwatch.Interval = 1000;
            this.lblrunningtime.ForeColor = System.Drawing.Color.Black;
            this.stopwatch.Enabled = true;
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            //-set isStop
            this.isStop = true;
            watch.Stop();
            watch.Reset();
            CheckStartStop();

            try
            {
                connectDB.con.Close();
                MessageBox.Show("Program has stopped !");
                lblServerValue.Text = @"Not Connected";
                lblServerValue.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show("cannot stop program" + ex.Message);
            }
        }
        private void tmrMain_Tick(object sender, EventArgs e)
        {
            //-set tmrMain.Enabled
            this.tmrMain.Enabled = false;
            //-set connection state
            connectDB.Getconnstring();
            lblServerValue.Text = @"Connected";
            lblServerValue.ForeColor = Color.Green;

            #region Process Select Result
            string[] labresultfiles = Directory.GetFiles(connectDB.INI_path, "*.HL7", SearchOption.TopDirectoryOnly);
            #endregion

            #region Process Check Result
            try
            {
                if (labresultfiles != null)
                {
                    using var data = new StreamReader(labresultfiles[0]);
                    string labdata;
                    while ((labdata = data.ReadLine()) != null)
                    {
                        datalist.Add(labdata);
                    }
                    string newLine = Environment.NewLine;
                    txtActive.Text = datalist[0] + newLine + datalist[1] + newLine + datalist[2] + newLine + datalist[3];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion

            #region Process Save Result
            Console.WriteLine("cvcv");
            #endregion

            #region Process Delet Result
            #endregion

            #region Process Save Log, Display Data
            #endregion

            #region Process Check Stop
            this.CheckStartStop();
            #endregion
        }
        private void lilSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSetting frmSetting = new frmSetting();
            frmSetting.Owner = this;
            frmSetting.Closed += new EventHandler(frmSetting_Closed);
            frmSetting.ShowDialog();
            return;
        }
        private void frmSetting_Closed(object sender, EventArgs e)
        {
            frmSetting frmSetting = (frmSetting)sender;
            if (frmSetting.DialogResult == DialogResult.OK)
            {
                //-set objects
            }
            return;
        }
        private void stopwatch_Tick_1(object sender, EventArgs e)
        {
            lblrunningtime.Text = string.Format("{0:00}:{1:00}:{2:00}", watch.Elapsed.Hours, watch.Elapsed.Minutes, watch.Elapsed.Seconds);
        }
    }
}
