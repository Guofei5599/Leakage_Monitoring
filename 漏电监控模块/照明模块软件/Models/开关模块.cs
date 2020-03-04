using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 照明模块软件
{
    public class 开关模块
    {
        private int i = 1;
        public bool isChange { set; get; }
        public string 模块编号 { set; get; }
        public string 模块类型 { set; get; }
        public string 开关编号 { set; get; }
        public string 开关名称 { set; get; }
        public string 开关位置 { set; get; }
        public bool flag { set; get; }
        public int 亮度
        {
            set { i = value; }
            get { return i; }
        }
        public int 输出亮度 { set; get; }
        public bool 输出Flag { set; get; }
    }
}
