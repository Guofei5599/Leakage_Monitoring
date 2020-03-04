using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerialCardReaderLib
{
    public class HslTimeOut
    {
        public HslTimeOut()
        {

        }
        /// <summary>
        /// 操作开始时间
        /// </summary>
        public DateTime StartTime { set; get; }
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool isSuccessful { set; get; }
        /// <summary>
        /// 延时的时间，单位毫秒
        /// </summary>
        public int DelayTime { set; get; }
        /// <summary>
        /// 连接操作用的Socket
        /// </summary>
        public TcpClient WoekSocket { set; get; }
        /// <summary>
        /// 用于超时执行的方法
        /// </summary>
        public Action Operator { set; get; }

        public ManualResetEvent WaitDown {set;get;}
        public bool isTimeout { set; get; }
    }
}
