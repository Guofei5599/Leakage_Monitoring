using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 照明模块软件
{
    public class GetLocaltion
    {
        public static ponitClass GetPoint()
        {
            WebClient client = new WebClient();//用System.Net.WebClient类可以从特定的URI请求文件。System.Net.WebClient是一个非常高级的类，它用简单的命令就能实现一些基本操作
            string url = @"http://api.map.baidu.com/location/ip?ak=CRGeKEM99NlIQM3uO6K6vG9H66sHrzPS&coor=bd09ll";
            string jsonData = client.DownloadString(url);
            IPDataInfo ipInfo = JsonConvert.DeserializeObject<IPDataInfo>(jsonData);
            return ipInfo.content.point;
        }
    }
}
