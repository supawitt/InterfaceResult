using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells;
using InterfaceResult.conndb;
using MySql.Data.MySqlClient;

namespace InterfaceResult
{
    public partial class FrmMain : Form
    {
        DateTime _time = DateTime.Now;
        public FrmMain()
        {
            InitializeComponent();
        }
        
        #region Main Attributes

        private readonly ConnectDb _connectDb = new ConnectDb();
        private Point _pointClick;
        private bool _isStop;
        private readonly Stopwatch _watch = new Stopwatch();
        public List<string> Datalist = new List<string>();

        private string _logstart;
        private string _logcheckresult;
        private string _logupdate;
        private string _logdelete;
        private string[] _labresultfiles;
        private string _labresultdata;
        private readonly StringBuilder _labresult = new StringBuilder();

        #endregion

        #region Result Attributes

        private static string[] _hn;
        private static string[] _ptname;
        private static int _age;
        private static string _sex;
        private static string[] _height;
        private static string[] _weight;
        private static string[] _bmi;
        private static string[] _bunResult;
        private static string[] _creatinineResult;
        private static string[] _uricacidResult;
        private static string[] _cholesterolResult;
        private static string[] _triglycerideResult;
        private static string[] _hdlResult;
        private static string[] _ldlResult;
        private static string[] _astsgotResult;
        private static string[] _altsgptResult;
        private static string[] _alkalineResult;
        private static string[] _wbccountResult;
        private static string[] _rbccountResult;
        private static string[] _hbResult;
        private static string[] _hematocritResult;
        private static string[] _mvcResult;
        private static string[] _mchResult;
        private static string[] _mchcResult;
        private static string[] _pltcountResult;
        private static string[] _neutResult;
        private static string[] _lympResult;
        private static string[] _monoResult;
        private static string[] _eosinophilResult;
        private static string[] _basoResult;
        private static string[] _pltsmearResult;
        private static string[] _rbcmorphologyResult;
        private static string[] _nrbcResult;
        private static string[] _rdwResult;
        private static string[] _appearanceurineResult;
        private static string[] _colorurineResult;
        private static string[] _spgrurineResult;
        private static string[] _phurineResult;
        private static string[] _glucoseurineResult;
        private static string[] _proteinurineResult;
        private static string[] _bloodurineResult;
        private static string[] _wbcurineResult;
        private static string[] _rbcurineResult;
        private static string[] _epithurineResult;
        private static string[] _bacteriaurineResult;
        private static string[] _ketoneurineResult;
        private static string[] _leukocyteurineResult;
        private static string[] _nitriteurineResult;
        private static string[] _urobilinogenurineResult;
        private static string[] _bilirubinurineResult;
        private static string[] _mucousthreadurineResult;
        private static string[] _glucoseResult;

        #endregion

        #region Operations

        private void CheckStartStop()
        {
            if (_isStop)
            {
                #region //-set status stop

                //-set lblStatus
                lblStatus.Text = @"Status: Stop";
                lblStatus.ForeColor = Color.Red;
                //-set timer
                tmrMain.Enabled = false;
                stopwatch.Enabled = false;
                //-set button
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                lilSetting.Enabled = true;

                #endregion
            }
            else
            {
                #region //-set status start

                //-set lblStatus
                lblStatus.Text = @"Status: Start";
                lblStatus.ForeColor = Color.Blue;
                //-set txtActive
                txtActive.ForeColor = Color.Black;
                //-set timer
                tmrMain.Enabled = true;
                //-loop to start
                tmrMain.Interval = 2000;

                #endregion
            }
        }

        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            #region check process running

            var currentProcess = Process.GetCurrentProcess();
            var localAll = Process.GetProcesses();
            foreach (var localProces in localAll)
                if (currentProcess.ProcessName == localProces.ProcessName &&
                    currentProcess.Id != localProces.Id)
                {
                    //Duplicate Process
                    MessageBox.Show(@"Program already running.", @"Program start", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    currentProcess.Kill();
                    Close();
                }

            #endregion

            //-set screen
            FormBorderStyle = FormBorderStyle.None;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - _pointClick.X;
                Top += e.Y - _pointClick.Y;
            }
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) _pointClick = e.Location;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //-set isStop
            _isStop = false;
            CheckStartStop();
            //-set timer
            tmrMain.Interval = 2000;
            tmrMain.Enabled = true;
            //-set button
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lilSetting.Enabled = false;
            //-set stopwatch
            _watch.Start();
            stopwatch.Interval = 1000;
            lblrunningtime.ForeColor = Color.Black;
            stopwatch.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //-set isStop
            _isStop = true;
            _watch.Stop();
            _watch.Reset();
            CheckStartStop();

            try
            {
                _connectDb.Con.Close();
                MessageBox.Show(@"Program has stopped !");
                lblServerValue.Text = @"Not Connected";
                lblServerValue.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"cannot stop program" + ex.Message);
            }
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            //-set tmrMain.Enabled
            tmrMain.Enabled = false;
            //-set connection state
            _connectDb.Getconnstring();
            lblServerValue.Text = @"Connected";
            lblServerValue.ForeColor = Color.Green;

            #region Process Select Result

            _logstart = GetTimestamp(DateTime.Now);
            _labresultfiles = Directory.GetFiles(_connectDb.IniPath, "*.HL7", SearchOption.TopDirectoryOnly);

            #endregion

            #region Process Check Result

            if (_labresultfiles.Length == 0)
            {
                _connectDb.Getconnstring();
                MySqlCommand cmd;
                var sql = @"select lab_result_data from lab_result order by lab_result_id desc limit 1";
                cmd = new MySqlCommand(sql, _connectDb.Con);
                _connectDb.Con.Open();
                var rawresultdata = cmd.ExecuteReader();
                if (rawresultdata.HasRows)
                {
                    rawresultdata.Read();
                    var byteresult = (byte[]) rawresultdata.GetValue(0);
                    var result = Encoding.UTF8.GetString(byteresult);
                    txtActive.Text = result;
                    _connectDb.Con.Close();
                    btnStart_Click(sender, e);
                }
                else
                {
                    btnStart_Click(sender, e);
                }
            }

            #endregion

            #region Process Save Result

            else
            {
                _logcheckresult = GetTimestamp(DateTime.Now);
                var filestream = new FileStream(_labresultfiles[0], FileMode.Open, FileAccess.Read);
                using var data = new StreamReader(filestream, Encoding.Default);
                string labdata;
                while ((labdata = data.ReadLine()) != null) Datalist.Add(labdata);
                var msgType = Datalist[1].Split('|');
                var resultLon = Datalist[7].Split('|');

                for (var i = 0; i < Datalist.Count; i++) _labresult.Append(Datalist[i] + "\n");

                var time = DateTime.Now;
                MySqlCommand cmd;
                _connectDb.Getconnstring();
                var sql = @"insert into lab_result (lab_result_lon,lab_result_msg_type,lab_result_data,lab_result_datatype_id,lab_result_note,lab_result_datetime,lab_result_receive,lab_result_receive_datetime,lab_result_receive_data) values (@lab_result_lon,@lab_result_msg_type,@lab_result_data,@lab_result_datatype_id,@lab_result_note,@lab_result_datetime,@lab_result_receive,@lab_result_receive_datetime,@lab_result_receive_data)";
                cmd = new MySqlCommand(sql, _connectDb.Con);
                _connectDb.Con.Open();
                cmd.Parameters.AddWithValue("@lab_result_lon", resultLon[2]);
                cmd.Parameters.AddWithValue("@lab_result_msg_type", msgType[8]);
                cmd.Parameters.AddWithValue("@lab_result_data", _labresult.ToString());
                cmd.Parameters.AddWithValue("@lab_result_datatype_id", 1);
                cmd.Parameters.AddWithValue("@lab_result_note", null);
                cmd.Parameters.AddWithValue("@lab_result_datetime", time);
                cmd.Parameters.AddWithValue("@lab_result_receive", 'N');
                cmd.Parameters.AddWithValue("@lab_result_receive_datetime", null);
                cmd.Parameters.AddWithValue("@lab_result_receive_data", null);
                cmd.ExecuteNonQuery();
                _logupdate = GetTimestamp(DateTime.Now);
                Datalist.Clear();
                _labresult.Remove(0, _labresult.Length);
                _connectDb.Con.Close();
                data.Close();

                #endregion

                #region Process Save Log, Display Data

                var streamlabresult = new FileStream(_labresultfiles[0], FileMode.Open, FileAccess.Read);
                using var labresultshow = new StreamReader(streamlabresult, Encoding.Default);
                _labresultdata = labresultshow.ReadToEnd();
                txtActive.Text = _labresultdata;
                Writelogfile();
                labresultshow.Close();
                Savereport();
                _logdelete = GetTimestamp(DateTime.Now);

                #endregion

                #region Process Delet Result

                File.Delete(_labresultfiles[0]);

                #endregion

                #region Process Check Stop

                CheckStartStop();

                #endregion
            }
        }

        private void lilSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmSetting = new FrmSetting();
            frmSetting.Owner = this;
            frmSetting.Closed += frmSetting_Closed;
            frmSetting.ShowDialog();
        }

        private void frmSetting_Closed(object sender, EventArgs e)
        {
            var frmSetting = (FrmSetting) sender;
            if (frmSetting.DialogResult == DialogResult.OK)
            {
                //-set objects
            }
        }

        private void stopwatch_Tick_1(object sender, EventArgs e)
        {
            lblrunningtime.Text = string.Format(@"{0:00}:{1:00}:{2:00}", _watch.Elapsed.Hours, _watch.Elapsed.Minutes, _watch.Elapsed.Seconds);
        }

        public static string GetTimestamp(DateTime value)
        {
            return value.ToString("dd/MM/yyyy hh:mm:ss");
        }

        public void Writelogfile()
        {
            Directory.CreateDirectory(_connectDb.IniPath + @"\Event_Log");
            var create = File.Open(_connectDb.IniPath + @"\Event_Log\LabResult_log.log", FileMode.Append);
            using var newtask = new StreamWriter(create);
            newtask.WriteLine(_logstart + @"  Start Running !!");
            newtask.WriteLine(_logcheckresult + @" Have Result Data : " + _labresultfiles[0]);
            newtask.WriteLine(_logcheckresult + "HL7(New order) are =\n" + _labresultdata);
            newtask.WriteLine(_logupdate + @"Update Reqsult Data");
            newtask.WriteLine(_logdelete + @"Delete Reqsult Data");
            newtask.WriteLine("\n\n");
        }

        private void Savereport()
        {
            Directory.CreateDirectory(_connectDb.IniPath + @"\report");
            Directory.CreateDirectory(_connectDb.IniPath + @"\report\pdf");
            Directory.CreateDirectory(_connectDb.IniPath + @"\report\excel");
            var result = Directory.GetFiles(_connectDb.IniPath, "*.HL7", SearchOption.TopDirectoryOnly);
            var filestream = new FileStream(result[0], FileMode.Open, FileAccess.Read);
            using var data = new StreamReader(filestream, Encoding.Default);
            string labdata;
            while ((labdata = data.ReadLine()) != null) Datalist.Add(labdata);

            #region labresultattributes

            try
            {
                _hn = Datalist[3].Split('|');
                _ptname = Datalist[3].Split('|');
                _ptname = _ptname[4].Split('^');
                #region age_cal

                var rowage = Datalist[3].Split('|');
                var agestring = rowage[6].Substring(0, 4);
                int birth = Int32.Parse(agestring);
                DateTime time = DateTime.Now;
                int year = Int32.Parse(time.Year.ToString());
                _age = year - birth;

                #endregion
                #region Sex_convert

                var rowsex = Datalist[3].Split('|');
                _sex = rowsex[7];
                switch (_sex)
                {
                    case "F":
                        _sex = "หญิง";
                        break;
                    case "M":
                        _sex = "ชาย";
                        break;
                    default:
                        _sex = "ไม่ระบุ";
                        break;
                }

                #endregion
                _height = Datalist[5].Split('|');
                _height = _height[10].Split('^');
                _weight = Datalist[5].Split('|');
                _weight = _weight[11].Split('^');
                _bmi = Datalist[5].Split('|');
                _bmi = _bmi[12].Split('^');
                _bunResult = Datalist[11].Split('|');
                _creatinineResult = Datalist[15].Split('|');
                _uricacidResult = Datalist[19].Split('|');
                _cholesterolResult = Datalist[23].Split('|');
                _triglycerideResult = Datalist[27].Split('|');
                _hdlResult = Datalist[31].Split('|');
                _ldlResult = Datalist[35].Split('|');
                _astsgotResult = Datalist[39].Split('|');
                _altsgptResult = Datalist[43].Split('|');
                _alkalineResult = Datalist[47].Split('|');
                _wbccountResult = Datalist[51].Split('|');
                _rbccountResult = Datalist[53].Split('|');
                _hbResult = Datalist[55].Split('|');
                _hematocritResult = Datalist[57].Split('|');
                _mvcResult = Datalist[59].Split('|');
                _mchResult = Datalist[61].Split('|');
                _mchcResult = Datalist[63].Split('|');
                _pltcountResult = Datalist[65].Split('|');
                _neutResult = Datalist[67].Split('|');
                _lympResult = Datalist[69].Split('|');
                _monoResult = Datalist[71].Split('|');
                _eosinophilResult = Datalist[73].Split('|');
                _basoResult = Datalist[75].Split('|');
                _pltsmearResult = Datalist[79].Split('|');
                _rbcmorphologyResult = Datalist[81].Split('|');
                _nrbcResult = Datalist[85].Split('|');
                _rdwResult = Datalist[87].Split('|');
                _appearanceurineResult = Datalist[105].Split('|');
                _colorurineResult = Datalist[107].Split('|');
                _spgrurineResult = Datalist[109].Split('|');
                _phurineResult = Datalist[111].Split('|');
                _glucoseurineResult = Datalist[113].Split('|');
                _proteinurineResult = Datalist[115].Split('|');
                _bloodurineResult = Datalist[117].Split('|');
                _wbcurineResult = Datalist[119].Split('|');
                _rbcurineResult = Datalist[121].Split('|');
                _epithurineResult = Datalist[123].Split('|');
                _bacteriaurineResult = Datalist[125].Split('|');
                _ketoneurineResult = Datalist[129].Split('|');
                _leukocyteurineResult = Datalist[131].Split('|');
                _nitriteurineResult = Datalist[133].Split('|');
                _urobilinogenurineResult = Datalist[135].Split('|');
                _bilirubinurineResult = Datalist[137].Split('|');
                _mucousthreadurineResult = Datalist[139].Split('|');
                _glucoseResult = Datalist[149].Split('|');
            }
            catch (Exception)
            {
            }

            #endregion

            #region write_result_to_excel

            var workbook = new Workbook(_connectDb.IniPath + @"\Report_tmp.xlsx");
            var worksheet = workbook.Worksheets[0];

            worksheet.Cells["M2"].Value = _hn[2];
            worksheet.Cells["B1"].Value = _ptname[0]+_ptname[1] + " " + _ptname[3];
            worksheet.Cells["B2"].Value = _age;
            worksheet.Cells["I2"].Value = _sex;
            worksheet.Cells["V2"].Value = _time.ToString(@"dd/MM/yyyy");
            worksheet.Cells["B38"].Value = _weight[0];
            worksheet.Cells["J38"].Value = _height[0];
            worksheet.Cells["S38"].Value = _bmi[0];
            
            worksheet.Cells["M102"].Value = _hbResult[5];
            worksheet.Cells["M103"].Value = _hematocritResult[5];
            worksheet.Cells["M104"].Value = _wbccountResult[5];
            worksheet.Cells["M105"].Value = _wbccountResult[5];
            worksheet.Cells["M106"].Value = _rbccountResult[5];
            worksheet.Cells["M107"].Value = _pltcountResult[5];
            worksheet.Cells["M108"].Value = _pltsmearResult[5];
            worksheet.Cells["M109"].Value = _mvcResult[5];
            worksheet.Cells["M110"].Value = _mchResult[5];
            worksheet.Cells["M111"].Value = _mchcResult[5];
            worksheet.Cells["M112"].Value = _rdwResult[5];
            worksheet.Cells["M113"].Value = _neutResult[5];
            worksheet.Cells["M114"].Value = _lympResult[5];
            worksheet.Cells["M115"].Value = _monoResult[5];
            worksheet.Cells["M116"].Value = _eosinophilResult[5];
            worksheet.Cells["M117"].Value = _basoResult[5];
            worksheet.Cells["M118"].Value = _nrbcResult[5];
            worksheet.Cells["M119"].Value = _rbcmorphologyResult[5];
            worksheet.Cells["M121"].Value = _glucoseResult[5];
            worksheet.Cells["M125"].Value = _bunResult[5];
            worksheet.Cells["M126"].Value = _creatinineResult[5];
            worksheet.Cells["M138"].Value = _uricacidResult[5];
            worksheet.Cells["M140"].Value = _cholesterolResult[5];
            worksheet.Cells["M141"].Value = _triglycerideResult[5];
            worksheet.Cells["M142"].Value = _hdlResult[5];
            worksheet.Cells["M143"].Value = _ldlResult[5];
            worksheet.Cells["M145"].Value = _astsgotResult[5];
            worksheet.Cells["M146"].Value = _altsgptResult[5];
            worksheet.Cells["M147"].Value = _alkalineResult[5];
            worksheet.Cells["M169"].Value = _colorurineResult[5];
            worksheet.Cells["M170"].Value = _appearanceurineResult[5];
            worksheet.Cells["M171"].Value = _spgrurineResult[5];
            worksheet.Cells["M172"].Value = _phurineResult[5];
            worksheet.Cells["M173"].Value = _leukocyteurineResult[5];
            worksheet.Cells["M174"].Value = _nitriteurineResult[5];
            worksheet.Cells["M175"].Value = _proteinurineResult[5];
            worksheet.Cells["M176"].Value = _glucoseurineResult[5];
            worksheet.Cells["M177"].Value = _ketoneurineResult[5];
            worksheet.Cells["M178"].Value = _urobilinogenurineResult[5];
            worksheet.Cells["M179"].Value = _bilirubinurineResult[5];
            worksheet.Cells["M180"].Value = _bloodurineResult[5];
            worksheet.Cells["M181"].Value = _rbcurineResult[5];
            worksheet.Cells["M182"].Value = _wbcurineResult[5];
            worksheet.Cells["M183"].Value = _epithurineResult[5];
            worksheet.Cells["M184"].Value = _mucousthreadurineResult[5];
            worksheet.Cells["M185"].Value = _bacteriaurineResult[5];

            worksheet.PageSetup.FitToPagesWide = 1;
            worksheet.PageSetup.FitToPagesTall = 0;
            
            workbook.Save(_connectDb.IniPath + @"\report\excel\HN_" + _hn[2] + @".xlsx");
            workbook.Save(_connectDb.IniPath + @"\report\pdf\HN_" + _hn[2] + @".pdf", SaveFormat.Pdf);
            
            workbook.Dispose();

            #endregion
        }
    }
}