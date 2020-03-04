using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 照明模块软件
{
    class 计算日出日落
    {
        
        public static DateTime 计算日出时间(double 经度,double 纬度,DateTime dt)
        {
            double d1 = 24 * (180 + 8 * 15 - 经度 - Math.Acos(-Math.Tan(-23.4 * Math.Cos(2 * Math.PI * (dt.DayOfYear + 9) / 365) * Math.PI / 180) * Math.Tan(纬度 * Math.PI / 180)) * 180 / Math.PI) / 360;
            double b = d1 * 60;
            int h = (int)(b / 60);
            int m = (int)(b % 60);
            string s1 = h.ToString().PadLeft(2, '0') + ":" + m.ToString().PadLeft(2, '0');
            double d2 = 24 * (1 + (8 * 15 - 经度) / 180) - d1;
            double b1 = d2 * 60;
            int h1 = (int)(b1 / 60)%24;
            int m1 = (int)(b1 % 60);
            string s2 = h1.ToString().PadLeft(2, '0') + ":" + m1.ToString().PadLeft(2, '0');
            return DateTime.Parse(s1);
        }
        public static DateTime 计算日落时间(double 经度, double 纬度, DateTime dt)
        {
            double d1 = 24 * (180 + 8 * 15 - 经度 - Math.Acos(-Math.Tan(-23.4 * Math.Cos(2 * Math.PI * (dt.DayOfYear + 9) / 365) * Math.PI / 180) * Math.Tan(纬度 * Math.PI / 180)) * 180 / Math.PI) / 360;
            double b = d1 * 60;
            int h = (int)(b / 60);
            int m = (int)(b % 60);
            string s1 = h.ToString().PadLeft(2, '0') + ":" + m.ToString().PadLeft(2, '0');
            double d2 = 24 * (1 + (8 * 15 - 经度) / 180) - d1;
            double b1 = d2 * 60;
            int h1 = (int)(b1 / 60)%24;
            int m1 = (int)(b1 % 60);
            string s2 = h1.ToString().PadLeft(2, '0') + ":" + m1.ToString().PadLeft(2, '0');
            return DateTime.Parse(s2);
        }
    }
}
