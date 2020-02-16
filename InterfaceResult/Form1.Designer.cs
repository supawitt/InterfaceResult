namespace InterfaceResult
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lilAbout = new System.Windows.Forms.LinkLabel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lbCaption1 = new System.Windows.Forms.Label();
            this.lbCaption2 = new System.Windows.Forms.Label();
            this.pnlButtonHeader = new System.Windows.Forms.Panel();
            this.btnMin = new System.Windows.Forms.Button();
            this.lilSetting = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.tabActivateList = new System.Windows.Forms.TabControl();
            this.tabPageActivateList = new System.Windows.Forms.TabPage();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtActive = new System.Windows.Forms.TextBox();
            this.pnlActiviteList = new System.Windows.Forms.Panel();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblrunningtime = new System.Windows.Forms.Label();
            this.stopwatch = new System.Windows.Forms.Timer(this.components);
            this.lblServer = new System.Windows.Forms.Label();
            this.lblServerValue = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlButtonHeader.SuspendLayout();
            this.tabActivateList.SuspendLayout();
            this.tabPageActivateList.SuspendLayout();
            this.pnlActiviteList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnClose.Location = new System.Drawing.Point(33, -7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 24);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStart.Location = new System.Drawing.Point(170, 10);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 33);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lilAbout
            // 
            this.lilAbout.AutoSize = true;
            this.lilAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lilAbout.LinkColor = System.Drawing.Color.White;
            this.lilAbout.Location = new System.Drawing.Point(7, 20);
            this.lilAbout.Name = "lilAbout";
            this.lilAbout.Size = new System.Drawing.Size(43, 16);
            this.lilAbout.TabIndex = 14;
            this.lilAbout.TabStop = true;
            this.lilAbout.Text = "About";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(168)))));
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lbCaption1);
            this.pnlHeader.Controls.Add(this.lbCaption2);
            this.pnlHeader.Controls.Add(this.btnStart);
            this.pnlHeader.Controls.Add(this.pnlButtonHeader);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.btnStop);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(524, 55);
            this.pnlHeader.TabIndex = 13;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            this.pnlHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseMove);
            // 
            // lbCaption1
            // 
            this.lbCaption1.AutoSize = true;
            this.lbCaption1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCaption1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCaption1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbCaption1.Location = new System.Drawing.Point(49, 9);
            this.lbCaption1.Name = "lbCaption1";
            this.lbCaption1.Size = new System.Drawing.Size(58, 18);
            this.lbCaption1.TabIndex = 10;
            this.lbCaption1.Tag = "4";
            this.lbCaption1.Text = "NexLab";
            // 
            // lbCaption2
            // 
            this.lbCaption2.AutoSize = true;
            this.lbCaption2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCaption2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCaption2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbCaption2.Location = new System.Drawing.Point(3, 24);
            this.lbCaption2.Name = "lbCaption2";
            this.lbCaption2.Size = new System.Drawing.Size(128, 18);
            this.lbCaption2.TabIndex = 18;
            this.lbCaption2.Tag = "4";
            this.lbCaption2.Text = "(Interface Results)";
            // 
            // pnlButtonHeader
            // 
            this.pnlButtonHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(168)))));
            this.pnlButtonHeader.Controls.Add(this.btnClose);
            this.pnlButtonHeader.Controls.Add(this.btnMin);
            this.pnlButtonHeader.Controls.Add(this.lilSetting);
            this.pnlButtonHeader.Controls.Add(this.lilAbout);
            this.pnlButtonHeader.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtonHeader.Location = new System.Drawing.Point(470, 0);
            this.pnlButtonHeader.Name = "pnlButtonHeader";
            this.pnlButtonHeader.Size = new System.Drawing.Size(52, 53);
            this.pnlButtonHeader.TabIndex = 15;
            // 
            // btnMin
            // 
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnMin.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnMin.Location = new System.Drawing.Point(15, -2);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(19, 19);
            this.btnMin.TabIndex = 7;
            this.btnMin.Text = "-";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // lilSetting
            // 
            this.lilSetting.AutoSize = true;
            this.lilSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lilSetting.LinkColor = System.Drawing.Color.White;
            this.lilSetting.Location = new System.Drawing.Point(2, 35);
            this.lilSetting.Name = "lilSetting";
            this.lilSetting.Size = new System.Drawing.Size(49, 16);
            this.lilSetting.TabIndex = 15;
            this.lilSetting.TabStop = true;
            this.lilSetting.Text = "Setting";
            this.lilSetting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lilSetting_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Lavender;
            this.label1.Location = new System.Drawing.Point(153, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 18);
            this.label1.TabIndex = 51;
            this.label1.Text = "|";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnStop
            // 
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnStop.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStop.Location = new System.Drawing.Point(249, 10);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 33);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tabActivateList
            // 
            this.tabActivateList.Controls.Add(this.tabPageActivateList);
            this.tabActivateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabActivateList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabActivateList.Location = new System.Drawing.Point(0, 0);
            this.tabActivateList.Name = "tabActivateList";
            this.tabActivateList.SelectedIndex = 0;
            this.tabActivateList.Size = new System.Drawing.Size(522, 354);
            this.tabActivateList.TabIndex = 0;
            // 
            // tabPageActivateList
            // 
            this.tabPageActivateList.Controls.Add(this.lblServerValue);
            this.tabPageActivateList.Controls.Add(this.lblServer);
            this.tabPageActivateList.Controls.Add(this.lblrunningtime);
            this.tabPageActivateList.Controls.Add(this.label3);
            this.tabPageActivateList.Controls.Add(this.lblStatus);
            this.tabPageActivateList.Controls.Add(this.txtActive);
            this.tabPageActivateList.Location = new System.Drawing.Point(4, 25);
            this.tabPageActivateList.Name = "tabPageActivateList";
            this.tabPageActivateList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageActivateList.Size = new System.Drawing.Size(514, 325);
            this.tabPageActivateList.TabIndex = 0;
            this.tabPageActivateList.Text = "Activate List";
            this.tabPageActivateList.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(24, 17);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(51, 16);
            this.lblStatus.TabIndex = 74;
            this.lblStatus.Text = "Status :";
            // 
            // txtActive
            // 
            this.txtActive.BackColor = System.Drawing.SystemColors.Window;
            this.txtActive.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActive.Location = new System.Drawing.Point(27, 49);
            this.txtActive.Multiline = true;
            this.txtActive.Name = "txtActive";
            this.txtActive.ReadOnly = true;
            this.txtActive.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtActive.Size = new System.Drawing.Size(460, 243);
            this.txtActive.TabIndex = 0;
            this.txtActive.WordWrap = false;
            // 
            // pnlActiviteList
            // 
            this.pnlActiviteList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActiviteList.Controls.Add(this.tabActivateList);
            this.pnlActiviteList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActiviteList.Location = new System.Drawing.Point(0, 55);
            this.pnlActiviteList.Name = "pnlActiviteList";
            this.pnlActiviteList.Size = new System.Drawing.Size(524, 356);
            this.pnlActiviteList.TabIndex = 14;
            // 
            // tmrMain
            // 
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(24, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 79;
            this.label3.Text = "Running Time :";
            // 
            // lblrunningtime
            // 
            this.lblrunningtime.AutoSize = true;
            this.lblrunningtime.BackColor = System.Drawing.Color.Transparent;
            this.lblrunningtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrunningtime.ForeColor = System.Drawing.Color.Red;
            this.lblrunningtime.Location = new System.Drawing.Point(126, 298);
            this.lblrunningtime.Name = "lblrunningtime";
            this.lblrunningtime.Size = new System.Drawing.Size(34, 16);
            this.lblrunningtime.TabIndex = 80;
            this.lblrunningtime.Text = "stop";
            // 
            // stopwatch
            // 
            this.stopwatch.Interval = 1000;
            this.stopwatch.Tick += new System.EventHandler(this.stopwatch_Tick_1);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.BackColor = System.Drawing.Color.Transparent;
            this.lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.ForeColor = System.Drawing.Color.Black;
            this.lblServer.Location = new System.Drawing.Point(347, 17);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(54, 16);
            this.lblServer.TabIndex = 81;
            this.lblServer.Text = "Server :";
            // 
            // lblServerValue
            // 
            this.lblServerValue.AutoSize = true;
            this.lblServerValue.BackColor = System.Drawing.Color.Transparent;
            this.lblServerValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerValue.ForeColor = System.Drawing.Color.Blue;
            this.lblServerValue.Location = new System.Drawing.Point(407, 17);
            this.lblServerValue.Name = "lblServerValue";
            this.lblServerValue.Size = new System.Drawing.Size(65, 16);
            this.lblServerValue.TabIndex = 82;
            this.lblServerValue.Text = "Waiting . .";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 411);
            this.Controls.Add(this.pnlActiviteList);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmMain";
            this.Text = "Interface Result";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlButtonHeader.ResumeLayout(false);
            this.pnlButtonHeader.PerformLayout();
            this.tabActivateList.ResumeLayout(false);
            this.tabPageActivateList.ResumeLayout(false);
            this.tabPageActivateList.PerformLayout();
            this.pnlActiviteList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.LinkLabel lilAbout;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lbCaption1;
        private System.Windows.Forms.Label lbCaption2;
        private System.Windows.Forms.Panel pnlButtonHeader;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.LinkLabel lilSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TabControl tabActivateList;
        private System.Windows.Forms.TabPage tabPageActivateList;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtActive;
        private System.Windows.Forms.Panel pnlActiviteList;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Label lblrunningtime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer stopwatch;
        private System.Windows.Forms.Label lblServerValue;
        private System.Windows.Forms.Label lblServer;
    }
}

