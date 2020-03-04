using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerialCardReaderLib;
using System.Windows.Forms;

namespace 照明模块软件
{
    public enum CommState
    {
        DOEachRount,
        GetModlesMsg,
        GetModlesAllMsg,
        SetModles_TK,
        SetModles_Reset,
        Idel
    }

    public enum ActionState
    {
        复位,
        脱扣,
    }

    public class ModlesMsg
    {
        public CommState Function { set; get; }
        public int addr { set; get; }
        public int value { set; get; }
        public int[] valueArray { set; get; }
        public ushort bit { set; get; }
        public ushort[] bitArray { set; get; }
        public string 模块类型 { set; get; }
        public ActionState action { set; get; }
    }

    public class Communication
    {
        public static CommState currentCommState = CommState.Idel;
        static IAsyncResult iar = null;
        public static bool RoutInspecting = false;
        public static bool EachRoutInspecting = false;
        public static int RoutInspectCount = 0;
        public static int CommSuccessState = 0;
        public static int CurrentAddr = -1;
        public static bool BeginDoCommunication(ModlesMsg modlesMsg)
        {
            if (currentCommState != CommState.Idel)
            {
                return false;
            }
            iar = null;
            currentCommState = modlesMsg.Function;
            if (MainForm.CommMaster != null)
            {
                if(MainForm.CommMaster is Master)
                    iar = DoCommunicationFunc.BeginInvoke((MainForm.CommMaster as Master), modlesMsg, null, null);
                else
                    iar = DoCommunicationTcpFunc.BeginInvoke((MainForm.CommMaster as TcpMaster), modlesMsg, null, null);
            }
            return true;
        }
        public static CommState GetCommState()
        {
            return currentCommState;
        }
        public static int GetDoCommState()
        {
            if (iar == null)
                return 0;
            if (currentCommState == CommState.Idel)
                return 0;
            else
            {
                return iar.IsCompleted ? 2 : 1;
            }
        }

        public static byte[] CommReadData(out OperateResult operateResult)
        {
            byte[] data;
            if(MainForm.CommMaster is Master)
                data = (MainForm.CommMaster as Master ).ReadData(out operateResult);
            else
                data = (MainForm.CommMaster as TcpMaster).ReadData(out operateResult);
            return data;
        }
        public static void CommWriteData(byte[] data)
        {
            if (MainForm.CommMaster is Master)
                (MainForm.CommMaster as Master).WriteData(data);
            else
                (MainForm.CommMaster as TcpMaster).WriteData(data);
        }
        public static void StartDebug(TextBox textbox1)
        {
            if (MainForm.CommMaster is Master)
                (MainForm.CommMaster as Master).StartDebug(textbox1);
            else
                (MainForm.CommMaster as TcpMaster).StartDebug(textbox1);
        }
        public static void CommDispose()
        {
            if (MainForm.CommMaster is Master)
                (MainForm.CommMaster as Master).Dispose();
            else
                (MainForm.CommMaster as TcpMaster).Dispose();
        }
        public static void StopDebug()
        {
            if (MainForm.CommMaster is Master)
                (MainForm.CommMaster as Master).StopDebug();
            else
                (MainForm.CommMaster as TcpMaster).StopDebug();
        }
        public static OperateResult EndDoCommunication()
        {
            try
            {
               currentCommState = CommState.Idel;
               if(MainForm.CommMaster is Master)
                    return DoCommunicationFunc.EndInvoke(iar);
               else
                    return DoCommunicationTcpFunc.EndInvoke(iar);
            }
            catch (Exception ex)
            {
                return OperateResult.Create(false,ex.Message,new byte[] { }, new byte[] { });
            }
        }

        static Func<Master, ModlesMsg,OperateResult> DoCommunicationFunc = (Master master, ModlesMsg modlesMsg) =>
         {
             OperateResult operateResult;
             switch (modlesMsg.Function)
             {
                 case CommState.GetModlesMsg:
                     CurrentAddr = -2;
                     operateResult = new OperateResult();
                     master.GetModlesMsg(modlesMsg.addr, out operateResult);
                     return operateResult;
                 case CommState.GetModlesAllMsg:
                     CurrentAddr = -2;
                     operateResult = new OperateResult();
                     master.GetModlesAllMsg(modlesMsg.addr, out operateResult);
                     return operateResult;
                 case CommState.SetModles_TK:
                     CurrentAddr = -2;
                     operateResult = new OperateResult();
                     master.SetModles_TK(modlesMsg.addr, out operateResult);
                     return operateResult;
                 case CommState.SetModles_Reset:
                     CurrentAddr = (ushort)modlesMsg.addr;
                     operateResult = new OperateResult();
                     master.SetModles_Reset(modlesMsg.addr, out operateResult);
                     return operateResult;
                 case CommState.Idel:
                     CurrentAddr = -1;
                     return null;
             }
             return null;
         };
        static Func<TcpMaster, ModlesMsg, OperateResult> DoCommunicationTcpFunc = (TcpMaster master, ModlesMsg modlesMsg) =>
        {
            OperateResult operateResult;
            switch (modlesMsg.Function)
            {
                case CommState.GetModlesMsg:
                    CurrentAddr = -2;
                    operateResult = new OperateResult();
                    master.GetModlesMsg(modlesMsg.addr, out operateResult);
                    return operateResult;
                case CommState.GetModlesAllMsg:
                    CurrentAddr = -2;
                    operateResult = new OperateResult();
                    master.GetModlesAllMsg(modlesMsg.addr, out operateResult);
                    return operateResult;
                case CommState.SetModles_TK:
                    CurrentAddr = -2;
                    operateResult = new OperateResult();
                    master.SetModles_TK(modlesMsg.addr, out operateResult);
                    return operateResult;
                case CommState.SetModles_Reset:
                    CurrentAddr = (ushort)modlesMsg.addr;
                    operateResult = new OperateResult();
                    master.SetModles_Reset(modlesMsg.addr, out operateResult);
                    return operateResult;
                case CommState.Idel:
                    CurrentAddr = -1;
                    return null;
            }
            return null;
        };
    }
}
