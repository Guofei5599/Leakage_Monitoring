using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 照明模块软件
{
    [Serializable]
    public class 批量发送信息
    {
        public bool en { set; get; }
        public int sn { set; get; }
        public int timeout { set; get; }
        public byte [] data { set; get; }
    }
}
