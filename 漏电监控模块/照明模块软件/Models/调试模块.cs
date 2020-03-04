using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 照明模块软件
{
    [Serializable]
    public class 调试模块
    {
        public 调试模块()
        {
        }
        public List<ModelsData> ModelsDataList { set; get; }
        public string 模块编号 { set; get; }
        public string 模块名称 { set; get; }
        public string 模块类型 { set; get; }
        public int 漏电路数 { set; get; }
        public int 温度路数 { set; get; }
        public string 安装位置 { set; get; }
        public bool 为空 { set; get; }
        public bool IsRemove { set; get; }
        public bool 脱扣 { set; get; }
        public int FalutState { set; get; }
        public int State { set; get; }
        public int InspectCount { set; get; }
    }
    [Serializable]
    public class ModelsData
    {
        private bool Warning = false;
        public string DataType{set;get;}
        public int DataChannel { set; get; }
        public double DataValue { set; get; }
        public DateTime WarnDateTime { set; get; }
        public int BeepStart { set; get; }
        public bool IsWarning
        {
            set
            {
                if (Warning != value)
                {
                    Warning = value;
                    if (Warning)
                    {
                        WarnDateTime = DateTime.Now;
                        BeepStart = 2;
                    }
                    else
                    {
                        BeepStart = 0;
                    }
                }
            }
            get
            {
                return Warning;
            }
        }
    }
}
