using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 照明模块软件
{
    [Serializable]
    public class 场景开关信息
    {
        public string 开关通道 { set; get; }
        public string 开关名称 { set; get; }
        public string 开关状态 { set; get; }
        public string 开关亮度 { set; get; }
    }
}
