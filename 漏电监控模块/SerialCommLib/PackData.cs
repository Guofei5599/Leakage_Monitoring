using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCardReaderLib
{
    public class PackDataClass
    {
        public static byte[] PackHead(byte[] data)
        {
            byte[] head = new byte[] { 0x08,0x00,0x00,0x07,0xFF };
            List<byte> bList = new List<byte>();
            bList.AddRange(head);
            bList.AddRange(data);
            return bList.ToArray();
        }

        public static byte[] PackCRC(byte[] data,int index,int length)
        {
            byte tmpdata = CRCModbus.GetCrcModbus(data,index, length);
            List<byte> bList = new List<byte>();
            bList.AddRange(data);
            bList.Add(tmpdata);
            return bList.ToArray();
        }

        //public static byte[] PackData(byte [] data)
        //{
        //    byte[] tmp1 = PackCRC(data);
        //    //byte [] tmp = PackHead(tmp1);
        //    return tmp1;
        //}

        public static byte CheckCRC(byte[] data,int index,int length)
        {
            int len = data.Length;
            byte value = CRCModbus.GetCrcModbus(data, index, length);
            return value;
        }
        public static byte[] GetData(byte[] data)
        {
            if (data.Length <= 6)
            {
                throw new Exception("数据长度异常！");
            }
            int len = data.Length - 6;
            byte[] result = new byte[len];
            Array.Copy(data,4,result,0,len);
            return result;
        }
    }
}
