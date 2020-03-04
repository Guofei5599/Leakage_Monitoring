using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCardReaderLib
{
    public class CreateSendData
    {
        /// <summary>
        /// 查询模块信息
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public byte[] GetModlesMsg(int addr)
        {
            return new byte[] { 0x81, 0x00, 0x00, Convert.ToByte(addr>>8), Convert.ToByte(addr & 0xff), 0x5A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        }

        /// <summary>
        /// 查询模块具体信息
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public byte[] GetModlesAllMsg(int addr)
        {
            return new byte[] { 0x83, 0x00, 0x00, Convert.ToByte(addr >> 8), Convert.ToByte(addr & 0xff), 0x03, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00 };
        }

        /// <summary>
        /// 模块脱扣
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public byte[] SetModles_TK(int addr)
        {
            return new byte[] { 0x83, 0x00, 0x00, Convert.ToByte(addr >> 8), Convert.ToByte(addr & 0xff), 0x05, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 };
        }

        /// <summary>
        /// 模块复位
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public byte[] SetModles_Reset(int addr)
        {
            return new byte[] { 0x83, 0x00, 0x00, Convert.ToByte(addr >> 8), Convert.ToByte(addr & 0xff), 0x05, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00 };
        }
    }
}
