using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 照明模块软件
{
    [Serializable]
    public class sysParam
    {
        public bool 串口通信选择 { set; get; }
        public bool 以太网通信选择 { set; get; }
        public string 串口名称 { set; get; }
        public int 波特率 { set; get; }
        public string IP地址 { set; get; }
        public int 端口 { set; get; }

        public bool 开机自动巡检 { set; get; }
        public bool 开机自动广播 { set; get; }
        public bool 自动刷新 { set; get; }

        public int 发送速度 { set; get; }
        public int 接收速度 { set; get; }
        public int 状态巡检 { set; get; }
        public int 场景巡检 { set; get; }
        public double 经度 { set; get; }
        public double 维度 { set; get; }

        public string 标题 { set; get; }
        public string 公司 { set; get; }
        public string 网址 { set; get; }
        public string 电话 { set; get; }
        public string QQ { set; get; }
    }
}
