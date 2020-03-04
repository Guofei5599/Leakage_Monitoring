using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace SerialCardReaderLib
{
    public class TcpReadBase : IDisposable
    {
        /// <summary>
        /// 通信类的核心套接字
        /// </summary>
        public bool IsSocketError = false;
        public string IP { set; get; }
        public int Port { set; get; }
        public int ConnectTimeOut { set; get; }

        protected TcpClient CoreSocket = null;
        private int ReceiveTimeOut = 100;
        private int readyReceiveLen = 0;
        private bool DebugFlag = false;
        private TextBox txtBox = null;
        private bool ReadFlag = false;

        private DateTime lastStartTime = DateTime.Now;
        private DateTime lastDateTime = DateTime.Now;
        private bool ReceiveStart = false;
        private System.Threading.Timer timer1;
        public TcpReadBase(string ip,int port,int connectTimeout)
        {
            IP = ip;
            Port = port;
            ConnectTimeOut = connectTimeout;
            string s = "";
            IsSocketError = !ConnectServer(ip, port, connectTimeout, out s);
            timer1 = new System.Threading.Timer(timeCall,null, 3, 3);
        }

        public bool ConnectServer(string ip, int port, int timeout, out string ErrorStr)
        {
            ErrorStr = "";
            CoreSocket?.Close();
            var connectDone = new ManualResetEvent(false);
            var state = new StateObject();
            TcpClient tmpSocket = new TcpClient();
            tmpSocket.SendTimeout = 100;
            tmpSocket.ReceiveTimeout = 100;
            HslTimeOut connectTimeOut = new HslTimeOut()
            {
                WoekSocket = tmpSocket,
                DelayTime = timeout,
                WaitDown = connectDone,
                StartTime = DateTime.Now,
                isTimeout = false
            };
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolCheckTimeut), connectTimeOut);
            try
            {
                state.WaitDone = connectDone;
                CoreSocket = tmpSocket;
                state.WorkSocket = CoreSocket;
                tmpSocket.BeginConnect(ip, port, new AsyncCallback(ConnectCallBack), state);
            }
            catch (Exception ex)
            {
                connectTimeOut.isSuccessful = true;
                tmpSocket.Close();
                connectDone.Set();
                ErrorStr = ex.Message;
                return false;
            }
            connectDone.WaitOne();
            connectTimeOut.isSuccessful = true;
            if (connectTimeOut.isTimeout)
            {
                ErrorStr = "连接超时";
                tmpSocket?.Close();
                return false;
            }
            if (state.IsError)
            {
                ErrorStr = state.ErrorMessage;
                tmpSocket?.Close();
                return false;
            }
            state.Clear();
            state = null;
            return true;
        }

        private void ConnectCallBack(IAsyncResult ar)
        {
            StateObject state;
            if (ar.AsyncState is StateObject)
            {
                state = (StateObject)ar.AsyncState;
                try
                {
                    TcpClient socket = state.WorkSocket;
                    socket.EndConnect(ar);
                    state.WaitDone.Set();
                }
                catch (Exception ex)
                {
                    state.IsError = true;
                    state.ErrorMessage = ex.Message;
                    state.WaitDone.Set();
                }
            }
        }
        private void ThreadPoolCheckTimeut(object state)
        {
            HslTimeOut timeout;
            if (state is HslTimeOut)
            {
                timeout = (HslTimeOut)state;
                while (!timeout.isSuccessful)
                {
                    Thread.Sleep(10);
                    if ((DateTime.Now - timeout.StartTime).TotalMilliseconds > timeout.DelayTime)
                    {
                        if (!timeout.isSuccessful)
                        {
                            timeout.WoekSocket?.Close();
                            timeout.isTimeout = true;
                            timeout.WaitDown.Set();
                        }
                    }
                }
            }
        }

        static List<byte> tmpList = new List<byte>();
        DateTime lastReceiveDatetime = DateTime.Now;
        int pre_Count = 0;
        private void timeCall(object state)
        {
            if (CoreSocket != null && IsSocketError == false )
            {
                if (CoreSocket.GetStream().DataAvailable)
                {
                    Port_Receive(null, null);
                }
            }
        }
        private void Port_Receive(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (ReadFlag == true)
                    return;
                lastReceiveDatetime = DateTime.Now;
                byte[] tmpData = new byte[2048];
                int index = 0;
                if (CoreSocket.GetStream().DataAvailable)
                {
                    index = CoreSocket.GetStream().Read(tmpData, 0, 1024);
                    byte[] tmp = new byte[index];
                    Array.Copy(tmpData, tmp, index);
                    tmpList.AddRange(tmp);
                }
            }
            catch (Exception ex)
            {
                IsSocketError = true;
            }
            
        }

        public void Dispose()
        {
            CoreSocket?.Close();
            CoreSocket = null;
            timer1.Dispose();
        }

        public void StartDebug(TextBox tmpTextBox)
        {
            DebugFlag = true;
            txtBox = tmpTextBox;
        }
        public void StopDebug()
        {
            DebugFlag = false;
            txtBox.Dispose() ;
            txtBox = null;
        }
        private void SetData(string label, byte[] data)
        {
            string s = "";
            foreach (var v in data)
                s += v.ToString("X").PadLeft(2, '0') + " ";
            txtBox.Text += label + DateTime.Now.ToString() + ": " + s + "\r\n";
        }
        public OperateResult ReadBase(byte [] sendByte,int sendLen,int delays = 30)
        {
            try
            {
                ReadFlag = true;
                bool bTimeout = false;
                readyReceiveLen = 0;
                if (IsSocketError)
                {
                    string s = "";
                    IsSocketError = !ConnectServer(IP, Port, ConnectTimeOut, out s);
                }
                if (!IsSocketError)
                {
                    //byte[] tmpbuffer = new byte[CoreSocket.ReceiveBufferSize *2];
                    //CoreSocket.Receive(tmpbuffer, 0);
                    if(CoreSocket.GetStream().DataAvailable)
                        CoreSocket.GetStream().Read(new byte[2048],0,2048);
                    CoreSocket.GetStream().Write(sendByte, 0, sendByte.Length);
                }
                if (DebugFlag)
                    SetData("发送：", sendByte);
                byte[] tmpData = new byte[10240];
                DateTime lastDatetime = DateTime.Now;
                while (true)
                {
                    int tmpCount = 0;
                    //Thread.Sleep(delays);
                    byte[] tmpData1 = new byte[10240];
                    if (CoreSocket.GetStream().DataAvailable)
                        tmpCount = CoreSocket.GetStream().Read(tmpData1,0,1024);
                    Array.Copy(tmpData1, 0, tmpData, readyReceiveLen, tmpCount);
                    readyReceiveLen += tmpCount;
                    if (readyReceiveLen > 0 && tmpCount == 0)
                    {
                        break;
                    }
                    if (tmpCount > 0)
                        lastDatetime = DateTime.Now;
                    if ((DateTime.Now - lastDatetime).TotalMilliseconds > ReceiveTimeOut)
                    {
                        bTimeout = true;
                        break;
                    }
                }
                byte[] buffer = new byte[readyReceiveLen];
                Array.Copy(tmpData, 0, buffer, 0, readyReceiveLen);
                if (DebugFlag)
                    SetData("接收：", buffer);
                ReadFlag = false;
                if (bTimeout)
                {
                    return OperateResult.Create(false, "操作已超时", buffer, buffer);
                }
                else
                {
                    return OperateResult.Create(true, "", buffer, buffer);
                }
            }
            catch (Exception ex)
            {
                IsSocketError = true;
                return OperateResult.Create(false, ex.Message, new byte[] { }, new byte[] { });
            }
           
        }
        public OperateResult ReadBase(byte[] sendByte)
        {
            try
            {
                if (IsSocketError)
                {
                    string s = "";
                    IsSocketError = !ConnectServer(IP, Port, ConnectTimeOut, out s);
                }
                if (!IsSocketError)
                {
                    //byte[] buffer = new byte[2048];
                    //CoreSocket.Receive(buffer,0);
                    //CoreSocket.GetStream().Read(new byte[2048], 0, 2048);
                    CoreSocket.GetStream().Write(sendByte,0, sendByte.Length);
                }
                if (DebugFlag)
                    SetData("发送：", sendByte);
                return OperateResult.Create(true, "", new byte[] { }, new byte[] { });
            }
            catch (Exception ex)
            {
                IsSocketError = true;
                return OperateResult.Create(false, ex.Message, new byte[] { }, new byte[] { });
            }
        }
        public OperateResult Read()
        {
            if ((DateTime.Now - lastReceiveDatetime).TotalMilliseconds > 20)
            {
                List<byte> tmp = new List<byte>();
                foreach (var v in tmpList)
                    tmp.Add(v);
                tmpList.Clear();
                if (DebugFlag && tmp.Count != 0)
                    SetData("接收：", tmp.ToArray());
                return OperateResult.Create(true, "", tmp.ToArray(), tmp.ToArray());
            }
            else
            {
                List<byte> tmp = new List<byte>();
                return OperateResult.Create(true, "", tmp.ToArray(), tmp.ToArray());
            }
        }
    }
}
