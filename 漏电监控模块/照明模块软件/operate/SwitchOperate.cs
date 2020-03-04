using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 照明模块软件
{
    public class SwitchOperate
    {
        public static void LoadSwitch(int 模块地址)
        {
            string sql = string.Format(@" select * from 开关信息 where 模块地址 = '{0}' ", 模块地址.ToString());
            调试模块 tmp = ModelsOperate.GetModel(模块地址);
            //if (tmp.开关列表 == null)
            //    tmp.开关列表 = new List<开关模块>();
            DataTable dt = AccessLib.GetData(sql);
            foreach (DataRow v in dt.Rows)
            {
                开关模块 swit = new 开关模块()
                {
                    模块编号 = 模块地址.ToString(),
                    开关编号 = Convert.ToString(v["开关编号"]),
                    开关名称 = Convert.ToString(v["开关名称"]),
                    开关位置 = Convert.ToString(v["开关位置"])
                };
                //int index = -1;
                //if ((index = tmp.开关列表.FindIndex(t => t.开关编号 == swit.开关编号)) != -1)
                //{
                //    //tmp.开关列表[index] = swit;
                //    tmp.开关列表[index].开关位置 = swit.开关位置;
                //    tmp.开关列表[index].开关名称 = swit.开关名称;
                //}
                //else
                //{
                //    tmp.开关列表.Add(swit);
                //}
            }
        }
  
        public static void SaveModel(开关模块 v)
        {
            string sql1 = string.Format("select count(*) from 开关信息 where 模块地址 = '{0}' and 开关编号 = '{1}' ", v.模块编号,v.开关编号);
            if ((int)AccessLib.GetFirstCell(sql1) == 0)
            {
                string s = string.Format("Insert into 开关信息(模块地址,开关编号, 开关名称, 开关位置) values('{0}', '{1}', '{2}','{3}')", v.模块编号, v.开关编号, v.开关名称, v.开关位置);
                AccessLib.Execute(s);
            }
            else
            {
                string s = string.Format("update 开关信息 set 开关名称 = '{0}',开关位置 = '{1}',State = '2' where 模块地址 = '{2}' and 开关编号 = '{3}'", v.开关名称, v.开关位置, v.模块编号,v.开关编号);
                AccessLib.Execute(s);
            }
        }
    }
}
