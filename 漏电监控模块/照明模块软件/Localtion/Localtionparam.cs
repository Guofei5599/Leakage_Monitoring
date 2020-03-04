using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 照明模块软件
{
    public class IPDataInfo
    {
        public string address { set; get; }
        public Content content { set; get; }
        public string status { set; get; }
    }
    public class Content
    {
        public string address { set; get; }
        public Address_detail address_detail { set; get; }
        public ponitClass point { set; get; }
    }
    public class Address_detail
    {
        public string city { set; get; }
        public string city_code { set; get; }
        public string district { set; get; }
        public string province { set; get; }
        public string street { set; get; }
        public string street_number { set; get; }
        
    }

    public class ponitClass
    {
        public string x { set; get; }
        public string y { set; get; }
    }
}
