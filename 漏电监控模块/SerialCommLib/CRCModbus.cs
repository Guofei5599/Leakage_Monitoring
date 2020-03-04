//=================================================================
//
//文件名:CRCModbus
//
//Framework版本:4.0
//
//描述:
//
//创建人:刘健
//
//创建日期:2018-03-13 09:42:00
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerialCardReaderLib
{
    class CRCModbus
    {
        //public static ushort GetCrcModbus(byte[] Buffer, int len)
        //{
        //    ushort wcrc = 0xFFFF;
        //    byte temp;

        //    for (int i = 0; i < len; i++)
        //    {
        //        temp = (byte)(Buffer[i] & 0x00FF);
        //        wcrc ^= temp;
        //        for (int j = 0; j < 8; j++)
        //        {
        //            if (Convert.ToBoolean(wcrc & 0x0001))
        //            {
        //                wcrc >>= 1;
        //                wcrc ^= 0xA001;
        //            }
        //            else
        //            {
        //                wcrc >>= 1;
        //            }
        //        }
        //    }
        //    return wcrc;
        //}

        public static byte GetCrcModbus(byte[] Buffer,int index, int len)
        {
            ushort temp = 0;
            for (int i = index; i < len + index; i++)
            {
                temp += Buffer[i];
            }
            return (byte)(temp & 0xff);
        }
    }
}
