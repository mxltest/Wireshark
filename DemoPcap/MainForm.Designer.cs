namespace DemoPcap
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.combDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.spcContent = new System.Windows.Forms.SplitContainer();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtMacAddr = new System.Windows.Forms.TextBox();
            this.txtMask = new System.Windows.Forms.TextBox();
            this.txtIpAddr = new System.Windows.Forms.TextBox();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPorts = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.spcContainer = new System.Windows.Forms.SplitContainer();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.rtxtPacketInfo = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlblStatistic = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.dstIpText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcContent)).BeginInit();
            this.spcContent.Panel1.SuspendLayout();
            this.spcContent.Panel2.SuspendLayout();
            this.spcContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcContainer)).BeginInit();
            this.spcContainer.Panel1.SuspendLayout();
            this.spcContainer.Panel2.SuspendLayout();
            this.spcContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcMain.IsSplitterFixed = true;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.btnStop);
            this.spcMain.Panel1.Controls.Add(this.btnStart);
            this.spcMain.Panel1.Controls.Add(this.combDevice);
            this.spcMain.Panel1.Controls.Add(this.label1);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.spcContent);
            this.spcMain.Size = new System.Drawing.Size(954, 562);
            this.spcMain.SplitterWidth = 1;
            this.spcMain.TabIndex = 0;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(684, 13);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "停止捕捉";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(590, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始捕捉";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // combDevice
            // 
            this.combDevice.FormattingEnabled = true;
            this.combDevice.Location = new System.Drawing.Point(71, 14);
            this.combDevice.Name = "combDevice";
            this.combDevice.Size = new System.Drawing.Size(513, 20);
            this.combDevice.TabIndex = 1;
            this.combDevice.SelectedIndexChanged += new System.EventHandler(this.combDevice_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备列表";
            // 
            // spcContent
            // 
            this.spcContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spcContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcContent.Location = new System.Drawing.Point(0, 0);
            this.spcContent.Name = "spcContent";
            // 
            // spcContent.Panel1
            // 
            this.spcContent.Panel1.Controls.Add(this.dstIpText);
            this.spcContent.Panel1.Controls.Add(this.label10);
            this.spcContent.Panel1.Controls.Add(this.txtDesc);
            this.spcContent.Panel1.Controls.Add(this.txtMacAddr);
            this.spcContent.Panel1.Controls.Add(this.txtMask);
            this.spcContent.Panel1.Controls.Add(this.txtIpAddr);
            this.spcContent.Panel1.Controls.Add(this.txtDeviceName);
            this.spcContent.Panel1.Controls.Add(this.label9);
            this.spcContent.Panel1.Controls.Add(this.label8);
            this.spcContent.Panel1.Controls.Add(this.label7);
            this.spcContent.Panel1.Controls.Add(this.label6);
            this.spcContent.Panel1.Controls.Add(this.label5);
            this.spcContent.Panel1.Controls.Add(this.label4);
            this.spcContent.Panel1.Controls.Add(this.txtPorts);
            this.spcContent.Panel1.Controls.Add(this.label3);
            this.spcContent.Panel1.Controls.Add(this.txtProcessName);
            this.spcContent.Panel1.Controls.Add(this.label2);
            // 
            // spcContent.Panel2
            // 
            this.spcContent.Panel2.Controls.Add(this.spcContainer);
            this.spcContent.Size = new System.Drawing.Size(954, 511);
            this.spcContent.SplitterDistance = 180;
            this.spcContent.TabIndex = 0;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(54, 361);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(118, 81);
            this.txtDesc.TabIndex = 7;
            // 
            // txtMacAddr
            // 
            this.txtMacAddr.Location = new System.Drawing.Point(54, 330);
            this.txtMacAddr.Name = "txtMacAddr";
            this.txtMacAddr.Size = new System.Drawing.Size(118, 21);
            this.txtMacAddr.TabIndex = 7;
            // 
            // txtMask
            // 
            this.txtMask.Location = new System.Drawing.Point(54, 299);
            this.txtMask.Name = "txtMask";
            this.txtMask.Size = new System.Drawing.Size(118, 21);
            this.txtMask.TabIndex = 7;
            // 
            // txtIpAddr
            // 
            this.txtIpAddr.Location = new System.Drawing.Point(55, 268);
            this.txtIpAddr.Name = "txtIpAddr";
            this.txtIpAddr.Size = new System.Drawing.Size(118, 21);
            this.txtIpAddr.TabIndex = 7;
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(56, 238);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(118, 21);
            this.txtDeviceName.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 364);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "描述";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "MAC地址";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "子网掩码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "IP地址";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "设备名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Tag = "";
            this.label4.Text = "网卡信息";
            // 
            // txtPorts
            // 
            this.txtPorts.Location = new System.Drawing.Point(11, 70);
            this.txtPorts.Multiline = true;
            this.txtPorts.Name = "txtPorts";
            this.txtPorts.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPorts.Size = new System.Drawing.Size(163, 124);
            this.txtPorts.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "进程端口信息";
            // 
            // txtProcessName
            // 
            this.txtProcessName.Location = new System.Drawing.Point(56, 10);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(118, 21);
            this.txtProcessName.TabIndex = 1;
            this.txtProcessName.Text = "iexplore";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "进程名";
            // 
            // spcContainer
            // 
            this.spcContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcContainer.Location = new System.Drawing.Point(0, 0);
            this.spcContainer.Name = "spcContainer";
            this.spcContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcContainer.Panel1
            // 
            this.spcContainer.Panel1.Controls.Add(this.dgvData);
            // 
            // spcContainer.Panel2
            // 
            this.spcContainer.Panel2.Controls.Add(this.rtxtPacketInfo);
            this.spcContainer.Size = new System.Drawing.Size(768, 509);
            this.spcContainer.SplitterDistance = 211;
            this.spcContainer.TabIndex = 2;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(768, 211);
            this.dgvData.TabIndex = 1;
            this.dgvData.SelectionChanged += new System.EventHandler(this.dgvData_SelectionChanged);
            // 
            // rtxtPacketInfo
            // 
            this.rtxtPacketInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtPacketInfo.Location = new System.Drawing.Point(0, 0);
            this.rtxtPacketInfo.Name = "rtxtPacketInfo";
            this.rtxtPacketInfo.Size = new System.Drawing.Size(768, 294);
            this.rtxtPacketInfo.TabIndex = 0;
            this.rtxtPacketInfo.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblStatistic});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(954, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlblStatistic
            // 
            this.tlblStatistic.Name = "tlblStatistic";
            this.tlblStatistic.Size = new System.Drawing.Size(131, 17);
            this.tlblStatistic.Text = "toolStripStatusLabel1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 451);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "目标IP";
            // 
            // dstIpText
            // 
            this.dstIpText.Location = new System.Drawing.Point(54, 448);
            this.dstIpText.Name = "dstIpText";
            this.dstIpText.Size = new System.Drawing.Size(118, 21);
            this.dstIpText.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 562);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.spcMain);
            this.Name = "MainForm";
            this.Text = "MainForm--网络捕捉";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel1.PerformLayout();
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.spcContent.Panel1.ResumeLayout(false);
            this.spcContent.Panel1.PerformLayout();
            this.spcContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcContent)).EndInit();
            this.spcContent.ResumeLayout(false);
            this.spcContainer.Panel1.ResumeLayout(false);
            this.spcContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcContainer)).EndInit();
            this.spcContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.SplitContainer spcContent;
        private System.Windows.Forms.ComboBox combDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblStatistic;
        private System.Windows.Forms.RichTextBox rtxtPacketInfo;
        private System.Windows.Forms.SplitContainer spcContainer;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox txtPorts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMacAddr;
        private System.Windows.Forms.TextBox txtMask;
        private System.Windows.Forms.TextBox txtIpAddr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox dstIpText;
        private System.Windows.Forms.Label label10;
    }
}

