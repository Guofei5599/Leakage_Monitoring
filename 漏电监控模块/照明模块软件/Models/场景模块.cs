using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 照明模块软件
{
    public enum SceneModel
    {
        国家公休日,
        工作日模式
    }
    [Serializable]
    public class 场景模块
    {
        public 场景模块()
        {
            场景子名称列表 = new List<场景子模块>();
            场景调试模块列表 = new List<场景调试模块>();
        }
        public string 场景名称 { set; get; }
        public List<场景子模块> 场景子名称列表 { set; get; }
        public List<场景调试模块> 场景调试模块列表 { set; get; }
        public bool 启用标志 { set; get; }
        public SceneModel 模式 { set; get; }
        public byte 星期数据 { set; get; }
        public DateTime 开始时间 { set; get; }
        public DateTime 结束时间 { set; get; }
    }
}
