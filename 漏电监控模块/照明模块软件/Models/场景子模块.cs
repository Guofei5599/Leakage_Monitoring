using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 照明模块软件
{
    public enum SetTimeType
    {
        普通定时,
        日出时间,
        日落时间
    }

    [Serializable]
    public class 场景子模块
    {
        public string 场景子名称 { set; get; }
        public SetTimeType 定时方式 { set; get; }
        public bool 动作 { set; get; }
        public DateTime 动作时间 { set; get; }
        public List<场景调试模块> 场景调试模块列表2 { set; get; }
    }
}
