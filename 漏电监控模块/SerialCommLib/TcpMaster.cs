using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialCardReaderLib
{
    public class TcpMaster:IDisposable,IMaster
    {
        private TcpReadBase tcpReadBase;
        private CreateSendData createSendData;
        private AnalyseResult analyseResult;
        public TcpMaster(TcpReadBase ReadBase)
        {
            tcpReadBase = ReadBase;
            createSendData = new CreateSendData();
            analyseResult = new AnalyseResult();
        }
        public void StartDebug(TextBox txtBox)
        {
            if(tcpReadBase != null)
                tcpReadBase.StartDebug(txtBox);
        }
        public void StopDebug()
        {
            if (tcpReadBase != null)
                tcpReadBase.StopDebug();
        }
        public void Dispose()
        {
            tcpReadBase.Dispose();
        }

        /// <summary>
        /// 查询模块信息
        /// </summary>
        /// <param name="analyseresult"></param>
        /// <returns></returns>
        public byte[] GetModlesMsg(int addr,out OperateResult analyseresult)
        {
            byte[] data = createSendData.GetModlesMsg(addr);
            OperateResult receiveResult = tcpReadBase.ReadBase(data, data.Length,500);
            analyseresult = analyseResult.CheckReturnCrc(receiveResult);
            return analyseresult.ResultData;
        }
        public byte[] GetModlesAllMsg(int addr, out OperateResult analyseresult)
        {
            byte[] data = createSendData.GetModlesAllMsg(addr);
            OperateResult receiveResult = tcpReadBase.ReadBase(data, data.Length);
            analyseresult = analyseResult.CheckReturnCrc(receiveResult);
            return analyseresult.ResultData;
        }
        public byte[] SetModles_TK(int addr,out OperateResult analyseresult)
        {
            byte[] data = createSendData.SetModles_TK(addr);
            OperateResult receiveResult = tcpReadBase.ReadBase(data, data.Length);
            analyseresult = analyseResult.CheckReturnCrc(receiveResult);
            return analyseresult.ResultData;
        }
        public byte[] SetModles_Reset(int addr,out OperateResult analyseresult)
        {
            byte[] data = createSendData.SetModles_Reset(addr);
            OperateResult receiveResult = tcpReadBase.ReadBase(data, data.Length);
            analyseresult = analyseResult.CheckReturnCrc(receiveResult);
            return analyseresult.ResultData;
        }
        
        public byte[] ReadData(out OperateResult analyseresult)
        {
            List<byte> tmpList = new List<byte>();
            OperateResult operateResult = tcpReadBase.Read();
            foreach (var v in operateResult.Data)
                tmpList.Add(v);
            OperateResult receiveResult = new OperateResult()
            {
                IsSuccess = true,
                Data = tmpList.ToArray(),
                ResultData = tmpList.ToArray(),
                ResultString = ""
            };
            analyseresult = analyseResult.CheckReturnCrc(receiveResult);
            return analyseresult.Data;
        }
        public OperateResult WriteData(byte[] data)
        {
            OperateResult receiveResult = tcpReadBase.ReadBase(data);
            return receiveResult;
        }

        public void MasterBase()
        {
            throw new NotImplementedException();
        }
    }
}
