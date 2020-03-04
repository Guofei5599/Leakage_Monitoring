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

namespace SerialCardReaderLib
{
    public class SerialReadBase :IDisposable
    {
        public ConcurrentQueue<byte[]> DataQueue = new ConcurrentQueue<byte[]>();
        private SerialPort serialPort;
        private int receiveTimeouts = 500;
        private int readyReceiveLen = 0;
        private bool DebugFlag = false;
        private TextBox txtBox = null;
        private bool ReadFlag = false;

        private DateTime lastStartTime = DateTime.Now;
        private DateTime lastDateTime = DateTime.Now;
        private bool ReceiveStart = false;
        public SerialReadBase(string portName,int buadRate)
        {
            serialPort = new SerialPort(portName, buadRate);
            serialPort.ReadBufferSize = 2048;
            serialPort.WriteBufferSize = 2048;
            serialPort.ReadTimeout = 100;
            serialPort.WriteTimeout = 100;
            serialPort.DataReceived += Port_Receive;
            //serialPort.ReceivedBytesThreshold = 13;
            serialPort.Open();
        }

        static List<byte> tmpList = new List<byte>();
        DateTime lastReceiveDatetime = DateTime.Now;
        private void Port_Receive(object sender, SerialDataReceivedEventArgs e)
        {
            if (ReadFlag == true)
                return;
            lastReceiveDatetime = DateTime.Now;
            byte[] tmpData = new byte[10240];
            int index = 0;
            if ((index = serialPort.Read(tmpData, 0, serialPort.BytesToRead)) != 0)
            {
                byte[] tmp = new byte[index];
                Array.Copy(tmpData, tmp, index);
                tmpList.AddRange(tmp);
            }
        }

        public void Dispose()
        {
            if(serialPort.IsOpen)
                serialPort.Close();
        }

        public void SetReceiveTimeouts(int timeout)
        {
            receiveTimeouts = timeout;
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
                if (!serialPort.IsOpen)
                    serialPort.Open();
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                serialPort.Write(sendByte, 0, sendLen);
                if (DebugFlag)
                    SetData("发送：", sendByte);
                byte[] tmpData = new byte[10240];
                DateTime lastDatetime = DateTime.Now;
                while (true)
                {
                    int tmpCount = 0;
                    Thread.Sleep(delays);
                    tmpCount = serialPort.Read(tmpData, readyReceiveLen, serialPort.BytesToRead);
                    readyReceiveLen += tmpCount;
                    if (readyReceiveLen > 0 && tmpCount == 0)
                    {
                        break;
                    }
                    if (tmpCount > 0)
                        lastDatetime = DateTime.Now;
                    if ((DateTime.Now - lastDatetime).TotalMilliseconds > receiveTimeouts)
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
                return OperateResult.Create(false, ex.Message, new byte[] { }, new byte[] { });
            }
           
        }
        public OperateResult ReadBase(byte[] sendByte)
        {
            try
            {
                if (!serialPort.IsOpen)
                    serialPort.Open();
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                serialPort.Write(sendByte, 0, sendByte.Length);
                if (DebugFlag)
                    SetData("发送：", sendByte);
                return OperateResult.Create(true, "", new byte[] { }, new byte[] { });
            }
            catch (Exception ex)
            {
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
