using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 照明模块软件
{
    class AccessLib
    {
        public static OleDbConnection sqlconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=照明模块.mdb");
        public AccessLib()
        {
        }
        public static DataTable GetData(string sql)
        {
            if (sqlconnection.State == ConnectionState.Closed)
                sqlconnection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(sql,sqlconnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public static object GetFirstCell(string sql)
        {
            if (sqlconnection.State == ConnectionState.Closed)
                sqlconnection.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = sqlconnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            object obj = cmd.ExecuteScalar();
            return obj;
        }
        public static bool Execute(string sql)
        {
            if (sqlconnection.State == ConnectionState.Closed)
                sqlconnection.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = sqlconnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            int i = cmd.ExecuteNonQuery();
            return true;
        }

        public static int CheckPassword(string UserName,string password)
        {
            string sql =string.Format( " select count(*) from 用户信息 where UserName = '{0}' and Password = '{1}'",UserName,password);
            object obj = GetFirstCell(sql);
            return Convert.ToInt32(obj);
        }

        public static void SaveError(FaultModles tmpModles)
        {
            try
            {
                string sql = string.Format(" Insert into 故障信息表 ( 模块地址, 模块名称,模块位置,故障时间,故障描述,故障代码) values('{0}','{1}','{2}','{3}','{4}','{5}')  ",
               tmpModles.模块地址, tmpModles.模块名称, tmpModles.模块位置, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), tmpModles.故障描述, tmpModles.故障代码);
                Execute(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存故障信息失败：" + ex.Message);
            }
        }
        public static DataTable GetError(string date1,string date2)
        {
            try
            {
                string sql = string.Format(" select * from 故障信息表 where 故障时间 > #{0}# and 故障时间 < #{1}# ",date1,date2);
                return GetData(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取故障信息失败：" + ex.Message);
                return null;
            }
        }
        public static void DeleteError(string date1, string date2)
        {
            if (MessageBox.Show("是否清空故障信息！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    string sql = string.Format(" delete from 故障信息表 ", date1, date2);
                    Execute(sql);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("获取故障信息失败：" + ex.Message);
                }
            }
            
        }
    }
}
