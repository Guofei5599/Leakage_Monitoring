using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCardReaderLib
{
    public class AnalyseResult
    {
        public OperateResult CheckData(OperateResult operateResult,byte[] FuncCode,byte len)
        {
            if (!operateResult.IsSuccess)
                return operateResult;
            else
            {
                if (operateResult.Data == null)
                {
                    return OperateResult.Create(false, "接受数据异常,为空", operateResult.Data,new byte[] { });
                }
                else if (operateResult.Data.Length < 2)
                {
                    return OperateResult.Create(false, "接受数据异常", operateResult.Data, operateResult.Data);
                }
                else
                {
                    if (FuncCode[0] != operateResult.Data[0] || FuncCode[1] != operateResult.Data[1])
                    {
                        return OperateResult.Create(false, "功能码异常", operateResult.Data, operateResult.Data);
                    }
                    if (len != operateResult.Data[2])
                    {
                        return OperateResult.Create(false, "数据长度异常", operateResult.Data, operateResult.Data);
                    }
                    if (operateResult.Data.Length - 3 != len)
                    {
                        return OperateResult.Create(false, "数据长度不符合设定", operateResult.Data, operateResult.Data);
                    }
                    byte[] tmp = new byte[operateResult.Data.Length-3];
                    operateResult.Data.CopyTo(tmp,3);
                    return OperateResult.Create(true, "数据校验成功", operateResult.Data, tmp);
                }
            }
        }



        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <param name="operateResult"></param>
        /// <returns></returns>
        public OperateResult CheckReturnCrc(OperateResult operateResult)
        {
            if (!operateResult.IsSuccess)
                return operateResult;
            OperateResult Result = new OperateResult();
            int index = Array.IndexOf(operateResult.Data, (byte)8, 0);
            List<byte> tmpList = new List<byte>();
            if (index == -1)
            {
                Result.IsSuccess = false;
                Result.ResultData = tmpList.ToArray();
                return Result;
            }
            bool flag = false;
            while (index != -1)
            {
                if (operateResult.Data.Length >= index + 13)
                {
                    byte b = PackDataClass.CheckCRC(operateResult.Data, index + 5, 7);
                    if (operateResult.Data[index + 13 - 1] == b)
                    {
                        for (int i = index; i < index + 13; i++)
                            tmpList.Add(operateResult.Data[i]);
                        flag = true;
                    }
                    index = Array.IndexOf(operateResult.Data, (byte)8, index + 13);
                }
                else
                    index = -1;
            }
            Result.IsSuccess = flag;
            Result.ResultData = tmpList.ToArray();
            return Result;
        }
    }
}
