using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCardReaderLib
{
    public class FuncationMainCode
    {
        /// <summary>
        /// 查询所有模块
        /// </summary>
        public const byte ReadAllModle = 0xAA;
        /// <summary>
        /// 所有模块全开
        /// </summary>
        public const byte AllModleOpen = 0x51;
        /// <summary>
        /// 所有模块全关
        /// </summary>
        public const byte AllModleClose = 0x52;



    }
}
