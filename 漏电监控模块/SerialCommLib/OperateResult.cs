using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCardReaderLib
{
    public class OperateResult
    {
        public bool IsSuccess { set; get; }
        public string ResultString { set; get; }
        public byte [] Data { set; get; }
        public byte[] ResultData { set; get; }

        public static OperateResult Create(bool isSuccess, string resultString, byte[] data, byte[] resultData)
        {
            OperateResult operateResult = new OperateResult();
            operateResult.IsSuccess = isSuccess;
            operateResult.Data = new byte[data.Length];
            data.CopyTo(operateResult.Data,0);
            operateResult.ResultData = new byte[resultData.Length];
            resultData.CopyTo(operateResult.ResultData,0);
            operateResult.ResultString = resultString;
            return operateResult;
        }
    }
}
