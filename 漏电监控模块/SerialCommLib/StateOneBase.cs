using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerialCardReaderLib
{
    public class StateOneBase
    {
        /// <summary>
        /// 本次接收或发送的数据长度
        /// </summary>
        public int DataLength { set; get; } = 32;
        /// <summary>
        /// 已经处理的字节长度
        /// </summary>
        public int AlreadyDealLeaght { set; get; }
        /// <summary>
        /// 操作完成的信号
        /// </summary>
        public ManualResetEvent WaitDone { set; get; }
        /// <summary>
        /// 缓存器
        /// </summary>
        public byte[] Buffer { set; get; }
        /// <summary>
        /// 是否发生了错误
        /// </summary>
        public bool IsError { set; get; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { set; get; }
    }
}
