using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 照明模块软件
{
    [Serializable]
    public class 场景调试模块
    {
        public string 模块编号 { set; get; }
        public List<场景开关信息> 场景开关信息列表{ set; get; }
    }
}
