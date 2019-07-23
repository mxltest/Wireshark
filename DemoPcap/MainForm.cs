using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SharpPcap;
using SharpPcap.WinPcap;
using System.Threading;
using PacketDotNet;
using System.Net;
using System.Diagnostics;

namespace DemoPcap
{
    public partial class MainForm : Form
    {
        #region 属性和字段

        private ICaptureDevice device;//当前设备

        private Thread backgroundThread;//封装原始包的进程

        private bool backgroundThreadStop;//是否手动停止后台线程

        private object QueueLock = new object();

        private List<RawCapture> PacketQueue = new List<RawCapture>();//接收的原始包数据

        private Queue<PacketWrapper> packetStrings;//进一步封装后的队列，作为Gr

        private int packetCount;//接收包数量和序号

        private ICaptureStatistics captureStatistics;//统计信息

        private DateTime LastStatisticsOutput;

        private bool statisticsUiNeedsUpdate = false;

        private BindingSource bs;//GridView数据源

        private Process curProcess = new Process();//扫描进程对应端口的进程
        private string ipMy = string.Empty;
        private string ipYou = string.Empty;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            //WinPcapDeviceList Instance = WinPcapDeviceList.Instance;
        }

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            


            foreach (var dev in CaptureDeviceList.Instance)
            {
                var str = String.Format("{0}", dev.Description);
                this.combDevice.Items.Add(str);
            }
            this.btnStop.Enabled = false;
            InitInfo();
        }

        private void InitInfo()
        {
            curProcess.OutputDataReceived -= new DataReceivedEventHandler(ProcessOutDataReceived);
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = "cmd.exe";
            p.UseShellExecute = false;
            p.WindowStyle = ProcessWindowStyle.Maximized;
            p.CreateNoWindow = true;
            p.RedirectStandardError = true;
            p.RedirectStandardInput = true;
            p.RedirectStandardOutput = true;
            curProcess.StartInfo = p;
            curProcess.Start();

            curProcess.BeginOutputReadLine();
            curProcess.OutputDataReceived += new DataReceivedEventHandler(ProcessOutDataReceived);
        }

        /// <summary>
        /// 开始捕捉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.combDevice.SelectedIndex > -1)
            {
                StartCapture(this.combDevice.SelectedIndex);
                this.btnStart.Enabled = false;
                this.btnStop.Enabled = true;
                ipMy = this.txtIpAddr.Text.Trim();
                ipYou = this.dstIpText.Text.Trim();
            }
            else {
                MessageBox.Show(this,"请选择一个设备","提示",MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 停止捕捉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            Shutdown();
            this.btnStop.Enabled = false;
            this.btnStart.Enabled = true;
        }

        private void StartCapture(int itemIndex)
        {
            packetCount = 0;
            device = CaptureDeviceList.Instance[itemIndex];
            packetStrings = new Queue<PacketWrapper>();
            bs = new BindingSource();
            dgvData.DataSource = bs;
            LastStatisticsOutput = DateTime.Now;

            // start the background thread
            backgroundThreadStop = false;
            backgroundThread = new Thread(BackgroundThread);
            backgroundThread.Start();

            
            // setup background capture
            device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);
            device.OnCaptureStopped +=  new CaptureStoppedEventHandler(device_OnCaptureStopped);
            device.Open();

            // tcpdump filter to capture only TCP/IP packets
            string filter = "ip and tcp or udp";
            device.Filter = filter;

            // force an initial statistics update
            captureStatistics = device.Statistics;
            UpdateCaptureStatistics();

            // start the background capture
            device.StartCapture();

            btnStop.Enabled = true;
        }

        /// <summary>
        /// 设备接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            // print out periodic statistics about this device
            var Now = DateTime.Now;
            var interval = Now - LastStatisticsOutput;
            if (interval > new TimeSpan(0, 0, 2))
            {
                Console.WriteLine("device_OnPacketArrival: " + e.Device.Statistics);
                captureStatistics = e.Device.Statistics;
                statisticsUiNeedsUpdate = true;
                LastStatisticsOutput = Now;
            }
            
            lock (QueueLock)
            {
                if (filterDataIp(ipMy, ipYou, e.Packet)) {
                    PacketQueue.Add(e.Packet);
                };
                
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IPMy">本地Ip</param>
        /// <param name="IpYou">目标ip</param>
        private bool filterDataIp(string IPMy,string IpYou,RawCapture PacketD) {
            bool result = false;
            var packet = Packet.ParsePacket(PacketD.LinkLayerType, PacketD.Data);

            var tcpPacket =  packet.Extract(typeof (TcpPacket));
            if (tcpPacket != null)
            {


                var ipPacket = (PacketDotNet.IpPacket)tcpPacket.ParentPacket;
                IPAddress srcIp = ipPacket.SourceAddress;
                IPAddress dstIp = ipPacket.DestinationAddress;
                if ((srcIp.ToString()== IPMy || dstIp.ToString()== IPMy)&& (srcIp.ToString() == IpYou || dstIp.ToString() == IpYou)) {
                    result = true;
                }
            }
            else
            {
                var udpPacket = (UdpPacket)packet.Extract(typeof(UdpPacket));
                if (udpPacket!=null) {

                    result = true;
                }

            }
            return result;
        }
        /// <summary>
        /// 设备停止事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="status"></param>
        private void device_OnCaptureStopped(object sender, CaptureStoppedEventStatus status)
        {
            if (status != CaptureStoppedEventStatus.CompletedWithoutError)
            {
                MessageBox.Show("Error stopping capture", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCaptureStatistics()
        {
            tlblStatistic.Text = string.Format("接收包: {0}, 丢弃包: {1}, 接口丢弃包: {2}", captureStatistics.ReceivedPackets,captureStatistics.DroppedPackets, captureStatistics.InterfaceDroppedPackets);
        }

        private void BackgroundThread()
        {
            while (!backgroundThreadStop)
            {
                bool shouldSleep = true;

                lock (QueueLock)
                {
                    if (PacketQueue.Count != 0)
                    {
                        shouldSleep = false;
                    }
                }

                if (shouldSleep)
                {
                    Thread.Sleep(250);
                }
                else // should process the queue
                {
                    List<RawCapture> ourQueue;
                    lock (QueueLock)
                    {
                        // swap queues, giving the capture callback a new one
                        ourQueue = PacketQueue;
                        PacketQueue = new List<RawCapture>();
                    }

                    Console.WriteLine("BackgroundThread: ourQueue.Count is {0}", ourQueue.Count);
                    int tmpCount = packetStrings.Count;
                    foreach (var packet in ourQueue)
                    {
                        var packetWrapper = new PacketWrapper(packetCount, packet);
                        this.BeginInvoke(new MethodInvoker(delegate
                        {
                            if (packetWrapper.SourceAddress == "192.168.1.8")
                            {
                                packetStrings.Enqueue(packetWrapper);
                            }
                        }
                        ));

                        packetCount++;

                        var time = packet.Timeval.Date;
                        var len = packet.Data.Length;
                        Console.WriteLine("BackgroundThread: {0}:{1}:{2},{3} Len={4}",
                            time.Hour, time.Minute, time.Second, time.Millisecond, len);
                    }
                    if (packetStrings.Count > tmpCount)
                    {
                        this.BeginInvoke(new MethodInvoker(delegate
                        {
                            bs.DataSource =  packetStrings.Reverse();
                        }
                        ));
                    }
                    if (statisticsUiNeedsUpdate)
                    {
                        UpdateCaptureStatistics();
                        statisticsUiNeedsUpdate = false;
                    }
                }
            }
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.SelectedCells.Count == 0)
                return;

            var packetWrapper = (PacketWrapper)dgvData.Rows[dgvData.SelectedCells[0].RowIndex].DataBoundItem;

            var packet = Packet.ParsePacket(packetWrapper.p.LinkLayerType, packetWrapper.p.Data);
            var tcpPacket = (TcpPacket)packet.Extract(typeof(TcpPacket));
            //EthernetPacket
            
            if (tcpPacket != null)
            {
                if (!string.IsNullOrEmpty(txtPorts.Text) && txtPorts.Text.IndexOf(tcpPacket.SourcePort.ToString()) == -1)
                {
                    return;
                }
                
                var ipPacket = (PacketDotNet.IpPacket)tcpPacket.ParentPacket;
                
                IPAddress srcIp = ipPacket.SourceAddress;
                IPAddress dstIp = ipPacket.DestinationAddress;
                var tcpPacketData = (TcpPacket)ipPacket.PayloadPacket.Extract(typeof(TcpPacket));
                //this.rtxtPacketInfo.Text = this.rtxtPacketInfo.Text.Insert(0, string.Format("序号{6}>>源IP:{0}端口:{1}>>目标IP:{2}端口:{3}时间:{4}>>内容：{5} \n", srcIp.ToString(), tcpPacket.SourcePort, dstIp.ToString(), tcpPacket.DestinationPort, packetWrapper.Timeval.Date.ToString("yyyy-MM-dd HH:mm:ss"), tcpPacketData.PrintHex(), packetWrapper.Count));
                this.rtxtPacketInfo.Text = string.Format("序号{6}>>源IP:{0}端口:{1}>>目标IP:{2}端口:{3}时间:{4}>>内容：{5}-------->数据：{7} \n", srcIp.ToString(), tcpPacket.SourcePort, dstIp.ToString(), tcpPacket.DestinationPort, packetWrapper.Timeval.Date.ToString("yyyy-MM-dd HH:mm:ss"), tcpPacketData.PrintHex(), packetWrapper.Count, PrintHexString(tcpPacketData.PayloadData, "-"));
            }
            else
            {
                var udpPacket = (UdpPacket)packet.Extract(typeof(UdpPacket));
                if (udpPacket!=null) {
                    if (udpPacket.ParentPacket==null) { return; }
                    var ipPacket = (PacketDotNet.IpPacket)udpPacket.ParentPacket;
                    if (ipPacket==null) { return; }
                    IPAddress srcIp = ipPacket.SourceAddress;
                    IPAddress dstIp = ipPacket.DestinationAddress;
                    if (ipPacket.PayloadPacket==null) {
                        return;
                    }
                    var UDPPacketData = (UdpPacket)ipPacket.PayloadPacket.Extract(typeof(UdpPacket));
                    if (UDPPacketData==null) { return; }
                    //this.rtxtPacketInfo.Text = this.rtxtPacketInfo.Text.Insert(0, string.Format("序号{6}>>源IP:{0}端口:{1}>>目标IP:{2}端口:{3}时间:{4}>>内容：{5} \n", srcIp.ToString(), udpPacket.SourcePort, dstIp.ToString(), udpPacket.DestinationPort, packetWrapper.Timeval.Date.ToString("yyyy-MM-dd HH:mm:ss"), UDPPacketData.PrintHex(), packetWrapper.Count));

                    this.rtxtPacketInfo.Text = string.Format("序号{6}>>源IP:{0}端口:{1}>>目标IP:{2}端口:{3}时间:{4}>>内容：{5}-------->数据：{7} \n", srcIp.ToString(), udpPacket.SourcePort, dstIp.ToString(), udpPacket.DestinationPort, packetWrapper.Timeval.Date.ToString("yyyy-MM-dd HH:mm:ss"), UDPPacketData.PrintHex(), packetWrapper.Count, PrintHexString(UDPPacketData.PayloadData, "-"));
                }

                
            }
        }

        private void Shutdown()
        {
            if (device != null)
            {
                device.StopCapture();
                device.Close();
                device = null;
                backgroundThreadStop = true;
                backgroundThread.Join();
            }
        }

        /// <summary>
        /// 定时器，定时查询对应的端口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            string processName = this.txtProcessName.Text;
            Process[] pros = Process.GetProcessesByName(processName);
            if (pros != null && pros.Length > 0) {
                //this.txtPorts.Text = "";
                int proId = pros[0].Id;
                string cmdName = string.Format("netstat -ano|find \"{0}\"", proId);
                curProcess.StandardInput.WriteLine(cmdName);
                //curProcess.WaitForExit();
            }
        }

        /// <summary>
        /// 进程接受事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProcessOutDataReceived(object sender, DataReceivedEventArgs e)
        {
            string data = e.Data;
            if (string.IsNullOrEmpty(data)) {
                return;
            }
            if (!data.Trim().StartsWith("TCP")) {
                return;
            }
            data = data.Trim();
            string protocal = data.Substring(0, 6).Trim();
            string source = data.Substring(7, 23).Trim();
            string dest = data.Substring(30, 23).Trim();
            this.txtPorts.Invoke(new Action(() =>
            {
                if (source.IndexOf(":") != -1)
                {
                    string[] arr = source.Split(':');
                    if (this.txtPorts.Text.IndexOf(arr[1]) == -1)
                    {
                        this.txtPorts.AppendText(arr[1] + ",");
                    }
                }

            }));
          
        }

        private void combDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.combDevice.SelectedIndex > -1)
            {
                var device = WinPcapDeviceList.Instance[this.combDevice.SelectedIndex];
                this.txtDeviceName.Text=device.Interface.FriendlyName;

                this.txtDesc.Text= device.Interface.Description;
            }
            else {
                this.txtDeviceName.Text = "";
                this.txtIpAddr.Text = "";
                this.txtMask.Text = "";
                this.txtMacAddr.Text = "";
                this.txtDesc.Text = "";
            }
        }

        public string PrintHexString(byte[] infos, string split) {
            string tmp = string.Empty;
            if (infos.Length == 0) return tmp;
            foreach (byte info in infos) {
                tmp += info.ToString("X2") + split;
            }
            return tmp.Substring(0,tmp.Length-1);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.btnStop_Click(null,null);
        }
    }

    public class PacketWrapper
    {
        public RawCapture p;

        public int Count { get; private set; }
        public string SourceAddress { get; private set; }
        public string DestinationAddress { get; private set; }
        public PosixTimeval Timeval { get { return p.Timeval; } }
        public LinkLayers LinkLayerType { get { return p.LinkLayerType; } }
        public IPProtocolType Type { get; private set; }
        public int Length { get { return p.Data.Length; } }

        public PacketWrapper(int count, RawCapture p)
        {
            this.Count = count;
            this.p = p;
            var packet = Packet.ParsePacket(p.LinkLayerType, p.Data);
            if (packet==null) { return; }

            var tcpPacket = (TcpPacket)packet.Extract(typeof(TcpPacket));
            if (tcpPacket != null)
            {

                if (tcpPacket.ParentPacket==null) { return; }
                var ipPacket = (PacketDotNet.IpPacket)tcpPacket.ParentPacket;
                
                if (ipPacket == null) { return; }
                IPAddress srcIp = ipPacket.SourceAddress;
                IPAddress dstIp = ipPacket.DestinationAddress;
                SourceAddress= srcIp.ToString();
                DestinationAddress = dstIp.ToString();
                Type = ipPacket.Protocol;
            }
            else
            {
                var udpPacket = (UdpPacket)packet.Extract(typeof(UdpPacket));
                if (udpPacket==null) { return; }
                if (udpPacket.ParentPacket == null) { return; }
                var ipPacket = (PacketDotNet.IpPacket)udpPacket.ParentPacket;

                if (ipPacket == null) { return; }
                IPAddress srcIp = ipPacket.SourceAddress;
                IPAddress dstIp = ipPacket.DestinationAddress;
                SourceAddress = srcIp.ToString();
                DestinationAddress = dstIp.ToString();
                Type = ipPacket.Protocol;

            }
            
        }
    }
}
