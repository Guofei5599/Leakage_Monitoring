using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static 照明模块软件.MainForm;

namespace 照明模块软件
{
    public class 获取节假日
    {

        public static List<公休日> GetData(int year)
        {
            List<公休日> dateList = new List<公休日>();
            var v = 获取Msg(year);
            Thread.Sleep(1000);
            var v1 = 获取周末(year);
            Thread.Sleep(1000);
            if (v == null || v1 == null)
            {
                return null;
            }
            foreach (var v2 in v)
            {
                string[] s = v2.Split(',');
                //string s1 = s[0] + "," + ((s[1] == "2") ? "节假日" : "假日");
                dateList.Add(new 公休日(){ 日期 = s[0], 说明 = ((s[1] == "2") ? "节假日" : "假日")});
            }
            foreach (var v2 in v1)
            {
                string[] s = v2.Split(',');
                //string s1 = s[0] + "," + ((s[1] == "2") ? "节假日" : "周末");
                if (dateList.FindIndex(t=>t.日期 == s[0]) == -1)
                    dateList.Add(new 公休日() { 日期 = s[0], 说明 = ((s[1] == "2") ? "节假日" : "周末") });
            }
            dateList = dateList.OrderBy(t=>t.日期).ToList();
            return dateList;
        }

        public static List<string> 获取Msg(int year)
        {
            try
            {
                List<string> tmpList = new List<string>();
                var v = HttpApi("http://tool.bitefu.net/jiari/?d=" + year.ToString(), "get");
                v = v.Substring(1, v.Length - 2);
                v = v.Substring(v.IndexOf('{'));
                v = v.Substring(1,v.Length -1);
                string[] array = v.Split(',');
                foreach (var v1 in array)
                {
                    if (v1.Split(':')[1] != "0")
                        tmpList.Add((year.ToString() + v1.Split(':')[0].Trim('\"') + "," + v1.Split(':')[1].Trim('\"')).Trim('}'));
                }
                return tmpList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<string> 获取周末(int year)
        {
            List<string> tmpList = new List<string>();
            string s = "";
            DateTime dt1 = DateTime.Parse(year.ToString() + "/01/01");
            DateTime dt2 = DateTime.Parse((year + 1).ToString() + "/01/01");
            for (DateTime dt = dt1; dt < dt2; dt = dt.AddDays(1))
            {
                if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday)
                    s += dt.ToString("yyyyMMdd") + ",";
            }
            s = s.TrimEnd(',');

            try
            {
                var v = 获取节假日.HttpApi(string.Format("http://tool.bitefu.net/jiari/?d={0}", s), "get");
                v = v.Substring(1, v.Length - 2);
                string[] array = v.Split(',');
                foreach (var v1 in array)
                {
                    if (v1.Split(':')[1] != "0")
                        tmpList.Add((v1.Split(':')[0].Trim('\"') + "," + v1.Split(':')[1].Trim('\"')).Trim('}'));
                }
                return tmpList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       /// <summary>  
       /// 调用api返回json  
       /// </summary>  
       /// <param name="url">api地址</param>  
       /// <param name="jsonstr">接收参数</param>  
       /// <param name="type">类型</param>  
       /// <returns></returns>  
       public static string HttpApi(string url, string jsonstr, string type)
       {  
           Encoding encoding = Encoding.UTF8;  
           HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址  
           request.Accept = "text/html,application/xhtml+xml,*/*";  
           request.ContentType = "application/json";  
           request.Method = type.ToUpper().ToString();//get或者post  
           byte[] buffer = encoding.GetBytes(jsonstr);  
           request.ContentLength = buffer.Length;  
           request.GetRequestStream().Write(buffer, 0, buffer.Length);  
           HttpWebResponse response = (HttpWebResponse)request.GetResponse();  
           using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))  
           {  
               return reader.ReadToEnd();  
           }  
       }

        public static string HttpApi(string url,string type)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址  
            request.Accept = "text/html,application/xhtml+xml,*/*";
            request.ContentType = "application/json";
            request.Method = type.ToUpper().ToString();//get或者post  
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

    }
}
