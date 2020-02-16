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

namespace InterfaceResult
{
    public partial class frmMain : Form
    {
        #region Attributes
        private Point pointClick = new Point();
        private bool isStop = false;
        #endregion

        #region Operations
        /// <summary>
        /// 
        /// </summary>
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
                #endregion
            }
            return;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - pointClick.X;
                this.Top += e.Y - pointClick.Y;
            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pointClick = e.Location;
            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            //-set isStop
            this.isStop = false;
            //-set timer
            this.tmrMain.Interval = 2000;
            this.tmrMain.Enabled = true;
            //-set button
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            this.lilSetting.Enabled = false;
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            //-set isStop
            this.isStop = true;
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrMain_Tick(object sender, EventArgs e)
        {
            //-set tmrMain.Enabled
            this.tmrMain.Enabled = false;

            #region//-Process Select Result

            #endregion

            #region//-Process Check Result
            #endregion

            #region//-Process Save Result
            #endregion

            #region//-Process Delet Result
            #endregion

            #region//-Process Save Log, Display Data
            #endregion

            #region//-Process Check Stop
            this.CheckStartStop();
            #endregion

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lilSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSetting frmSetting = new frmSetting();
            frmSetting.Owner = this;
            frmSetting.Closed += new EventHandler(frmSetting_Closed);
            frmSetting.ShowDialog();
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSetting_Closed(object sender, EventArgs e)
        {
            frmSetting frmSetting = (frmSetting)sender;
            if (frmSetting.DialogResult == DialogResult.OK)
            {
                //-set objects
            }
            return;
        }
    }
}
