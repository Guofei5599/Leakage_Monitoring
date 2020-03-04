using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Microsoft.Win32;

namespace 照明模块软件
{
    public class SoftReg
    {
         /// <summary>  
         /// 获取硬盘序列号  
         /// </summary>  
         /// <returns></returns>  
         public string GetDiskSerialNum()
         {  
             ManagementClass mydisk = new ManagementClass("win32_NetworkAdapterConfiguration");  
             ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");  
             disk.Get();  
             return disk.GetPropertyValue("VolumeSerialNumber").ToString();  
         }  
         /// <summary>  
         /// 获取CPu序列号  
         /// </summary>  
         /// <returns></returns>  
         public string GetCpuSerialNum()
         {  
             string cpustr = "";  
             ManagementClass mycpu = new ManagementClass("win32_Processor");  
             ManagementObjectCollection mycpuCollention = mycpu.GetInstances();  
             foreach (ManagementObject var in mycpuCollention)  
             {  
                 cpustr = var.Properties["Processorid"].Value.ToString();  
             }  
             return cpustr;  
         }  
         /// <summary>  
         /// 通过CPU序列号和硬盘序列号的前24位做机器码  
         /// </summary>  
         /// <returns></returns>  
         public string GetMachineNum()
         {  
             string Num = GetCpuSerialNum() + GetDiskSerialNum();  
             string MachineNum = Num.Substring(0, 24);  
             return MachineNum;  
         }  
   
         public int[] m_intCode = new int[127];  //存储密钥  
         public char[] m_charASCII = new char[25];  //存储ASCII  
         public int[] m_intASCII = new int[25]; //存储ASCII的值  
   
         /// <summary>  
         /// 初始化密钥(通过模9生成)  
         /// </summary>  
         public void IntiIntCode()
         {  
             for (int i = 0; i<m_intCode.Length; i++)  
             {  
                 m_intCode[i] = i % 9;  
             }  
         }  
   
         /// <summary>  
         /// 获取设备注册码  
         /// </summary>  
         /// <returns></returns>  
         public string GetRegisterNum()
         {  
             IntiIntCode();  
             string MachineNume = GetMachineNum();  
             //通过机器码获取ASCII码  
             for (int i = 1; i<m_charASCII.Length; i++)  
             {  
                 m_charASCII[i] = Convert.ToChar(MachineNume.Substring(i - 1, 1));  
             }  
             //通过简单算法，改变ASCII的值， ASCII的值，再加上初始化密钥的值  
             for (int j = 1; j<m_intASCII.Length; j++)  
             {  
                 m_intASCII[j] = Convert.ToInt32(m_charASCII[j]) + m_intCode[Convert.ToInt32(m_charASCII[j])];  
             }  
             string MachineASCII = "";  
             for (int k = 1; k<m_intASCII.Length; k++)  
             {  
                 if ((m_intASCII[k] >= 48 && m_intASCII[k] <= 57) || (m_intASCII[k] >= 65 && m_intASCII[k] <= 90) || (m_intASCII[k] >= 97 && m_intASCII[k] <= 122))  
                 {  
                     MachineASCII += Convert.ToChar(m_intASCII[k]).ToString();  //在0-9,A-Z,a-z之间  
                 }  
                 else if (m_intASCII[k] > 122)  
                 {  
                     MachineASCII += Convert.ToChar(m_intASCII[k] - 10).ToString(); //大于z  
                 }  
                 else  
                 {  
                     MachineASCII += Convert.ToChar(m_intASCII[k] - 9).ToString();  
                 }  
             }  
             return MachineASCII;  
         }  
    }
    public class CheckReg
    {
        SoftReg softReg = new SoftReg();

        /// <summary>  
        /// 检查是否已经注册  
        /// </summary>  
        /// <returns></returns>  
        public bool GetIsReg()
        {
            bool IsCheck = false;
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true).CreateSubKey("mySoftWare").CreateSubKey("Register.INI");
            foreach (var item in regKey.GetSubKeyNames())
            {
                if (item == softReg.GetRegisterNum())
                {
                    IsCheck = true;
                }
            }
            return IsCheck;
        }


        /// <summary>  
        /// 判断软件是否可用，拥有二十次的试用期，也可以换成天数,再写入注册表信息  
        /// </summary>  
        /// <returns></returns>  
        public bool GetUseInfo(ref double days)
        {
            string m_intUse = "";
            bool Is_CanUse = false;
            try
            {
                m_intUse = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\mySoftWare", "UseTimes", DateTime.Now.ToString("yyyy/MM/dd"));
                if(m_intUse == null)
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\mySoftWare", "UseTimes", DateTime.Now.ToString("yyyy/MM/dd"), RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\mySoftWare", "UseTimes", DateTime.Now.ToString("yyyy/MM/dd"), RegistryValueKind.String);
            }
            m_intUse = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\mySoftWare", "UseTimes", DateTime.Now.ToString("yyyy/MM/dd"));
            if ((DateTime.Now.Date - DateTime.Parse(m_intUse).Date).TotalDays <= 3)
            {
                days = 3 - (DateTime.Now.Date - DateTime.Parse(m_intUse).Date).TotalDays;
                Is_CanUse = true;
            }
            else
            {
                days = 0;
                Is_CanUse = false;
            }
            return Is_CanUse;
        }
    }
}
