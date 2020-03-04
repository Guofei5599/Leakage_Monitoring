using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SerialCardReaderLib
{
    public class StateObject:StateOneBase
    {
        public StateObject()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Length">数据长度</param>
        public StateObject(int Length)
        {
            DataLength = Length;
            Buffer = new byte[Length];
        }
        /// <summary>
        /// 唯一的一串数据
        /// </summary>
        public string Uniqueld { set; get; }
        /// <summary>
        /// 网络套接字
        /// </summary>
        public TcpClient WorkSocket { set; get; }
        /// <summary>
        /// 是否关闭了通道
        /// </summary>
        public bool IsClose { set; get; }

        /// <summary>
        /// 清空旧数据
        /// </summary>
        public void Clear()
        {
            IsError = false;
            IsClose = false;
            AlreadyDealLeaght = 0;
            Buffer = null;
        }

    }
}
