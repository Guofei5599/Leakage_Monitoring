using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 照明模块软件
{
    public class 场景执行
    {
        public class SwitchMsg
        {
            public SwitchMsg()
            {
                channel = new int[16];
                value = new int[16];
            }
            public string addr { set; get; }
            public int[] channel { set; get; }
            public int[] value { set; get; }
        }



        //public static void FroeachScene()
        //{
        //    var tmpList = 获取启用场景();
        //    if (tmpList == null)
        //        return;
        //    DateTime currentDt = DateTime.Now;
        //    if (lastCheckDatetime >= currentDt)
        //    {
        //        lastCheckDatetime = currentDt;
        //        return;
        //    }
        //    foreach (var v in tmpList)
        //    {
        //        if (v.场景子名称列表 != null)
        //        {
        //            var msg = 获取场景模块信息(v);
        //            if (msg == null)
        //                continue;
        //            foreach (var v1 in v.场景子名称列表)
        //            {
        //                switch (v1.场景类型)
        //                {
        //                    case "国家公休日":
        //                        if (v1.开始日期.Date <= currentDt.Date && currentDt.Date <= v1.结束日期.Date)
        //                        {
        //                            string dt = currentDt.Date.ToString("yyyyMMdd");
        //                            if (MainForm.国家公休日列表.FindIndex(t => t == dt) != -1)
        //                            {
        //                                if (msg.ContainsKey(v.场景名称))
        //                                {
        //                                    var tmpMsg = msg[v.场景名称];
        //                                    if (v1.开启时间.TimeOfDay < currentDt.TimeOfDay && v1.开启时间.TimeOfDay >= lastCheckDatetime.TimeOfDay)
        //                                    {
        //                                        foreach (var v5 in tmpMsg)
        //                                        {
        //                                            List<ushort> tmpl = new List<ushort>();
        //                                            foreach (var i in v5.channel)
        //                                                tmpl.Add((ushort)i);
        //                                            var tmpModel = ModelsOperate.GetModel(int.Parse(v5.addr));
        //                                            if (tmpModel == null)
        //                                                continue;
        //                                            if (tmpModel.模块类型 == "开关模块")
        //                                            {
        //                                                ModlesMsg modlesMsg = new ModlesMsg()
        //                                                {
        //                                                    addr = int.Parse(v5.addr),
        //                                                    action = ActionState.Open,
        //                                                    bitArray = tmpl.ToArray(),
        //                                                    valueArray = v5.value,
        //                                                    模块类型 = tmpModel.模块类型,
        //                                                    bit = 0xf1
        //                                                };
        //                                                MainForm.WriteDic.AddOrUpdate(v5.addr + "," + "场景", modlesMsg, (key, value) => value);
        //                                            }
        //                                            else if (tmpModel.模块类型 == "调光模块")
        //                                            {
        //                                                ModlesMsg modlesMsg = new ModlesMsg()
        //                                                {
        //                                                    addr = int.Parse(v5.addr),
        //                                                    action = ActionState.Open,
        //                                                    bitArray = tmpl.ToArray(),
        //                                                    valueArray = v5.value,
        //                                                    模块类型 = tmpModel.模块类型,
        //                                                    bit = 0xf1
        //                                                };
        //                                                MainForm.WriteDic.AddOrUpdate(v5.addr + "," + "场景_1", modlesMsg, (key, value) => value);
        //                                                ModlesMsg modlesMsg1 = new ModlesMsg()
        //                                                {
        //                                                    addr = int.Parse(v5.addr),
        //                                                    action = ActionState.Open,
        //                                                    bitArray = tmpl.ToArray(),
        //                                                    valueArray = v5.value,
        //                                                    模块类型 = tmpModel.模块类型,
        //                                                    bit = 0xf2
        //                                                };
        //                                                MainForm.WriteDic.AddOrUpdate(v5.addr + "," + "场景_2", modlesMsg1, (key, value) => value);
        //                                            }
        //                                        }
        //                                        //v1.openstate = 2;
        //                                    }
        //                                    if (v1.结束时间.TimeOfDay < currentDt.TimeOfDay && v1.结束时间.TimeOfDay >= lastCheckDatetime.TimeOfDay)
        //                                    {
        //                                        foreach (var v5 in tmpMsg)
        //                                        {
        //                                            List<ushort> tmpl = new List<ushort>();
        //                                            foreach (var i in v5.channel)
        //                                                tmpl.Add((ushort)i);
        //                                            var tmpModel = ModelsOperate.GetModel(int.Parse(v5.addr));
        //                                            if (tmpModel == null)
        //                                                continue;
        //                                            if (tmpModel.模块类型 == "开关模块")
        //                                            {
        //                                                ModlesMsg modlesMsg = new ModlesMsg()
        //                                                {
        //                                                    addr = int.Parse(v5.addr),
        //                                                    action = ActionState.Close,
        //                                                    bitArray = tmpl.ToArray(),
        //                                                    valueArray = v5.value,
        //                                                    模块类型 = tmpModel.模块类型,
        //                                                    bit = 0xf1
        //                                                };
        //                                                MainForm.WriteDic.AddOrUpdate(v5.addr + "," + "场景", modlesMsg, (key, value) => value);
        //                                            }
        //                                            else if (tmpModel.模块类型 == "调光模块")
        //                                            {
        //                                                ModlesMsg modlesMsg = new ModlesMsg()
        //                                                {
        //                                                    addr = int.Parse(v5.addr),
        //                                                    action = ActionState.Close,
        //                                                    bitArray = tmpl.ToArray(),
        //                                                    valueArray = v5.value,
        //                                                    模块类型 = tmpModel.模块类型,
        //                                                    bit = 0xf1
        //                                                };
        //                                                MainForm.WriteDic.AddOrUpdate(v5.addr + "," + "场景_1", modlesMsg, (key, value) => value);
        //                                                ModlesMsg modlesMsg1 = new ModlesMsg()
        //                                                {
        //                                                    addr = int.Parse(v5.addr),
        //                                                    action = ActionState.Close,
        //                                                    bitArray = tmpl.ToArray(),
        //                                                    valueArray = v5.value,
        //                                                    模块类型 = tmpModel.模块类型,
        //                                                    bit = 0xf2
        //                                                };
        //                                                MainForm.WriteDic.AddOrUpdate(v5.addr + "," + "场景_2", modlesMsg1, (key, value) => value);
        //                                            }
        //                                        }
        //                                        //v1.closestate = 2;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        break;
        //                    case "普通定时":
        //                        if (v1.开始日期.Date <= currentDt.Date && currentDt.Date <= v1.结束日期.Date)
        //                        {
        //                            if (msg.ContainsKey(v.场景名称))
        //                            {
        //                                var tmpMsg = msg[v.场景名称];
        //                                if (v1.开启时间.TimeOfDay < currentDt.TimeOfDay && v1.开启时间.TimeOfDay >= lastCheckDatetime.TimeOfDay)
        //                                {
        //                                    foreach (var v5 in tmpMsg)
        //                                    {
        //                                        List<ushort> tmpl = new List<ushort>();
        //                                        foreach (var i in v5.channel)
        //                                            tmpl.Add((ushort)i);
        //                                        var tmpModel = ModelsOperate.GetModel(int.Parse(v5.addr));
        //                                        if (tmpModel == null)
        //                                            continue;
        //                                        if (tmpModel.模块类型 == "开关模块")
        //                                        {
        //                                            ModlesMsg modlesMsg = new ModlesMsg()
        //                                            {
        //                                                addr = int.Parse(v5.addr),
        //                                                action = ActionState.Open,
        //                                                bitArray = tmpl.ToArray(),
        //                                                valueArray = v5.value,
        //                                                模块类型 = tmpModel.模块类型,
        //                                                bit = 0xf1
        //                                            };
        //                                            MainForm.WriteDic.AddOrUpdate(v5.addr + "," + "场景", modlesMsg, (key, value) => value);
        //                                        }
        //                                        else if (tmpModel.模块类型 == "调光模块")
        //                                        {
        //                                            ModlesMsg modlesMsg = new ModlesMsg()
        //                                            {
        //                                                addr = int.Parse(v5.addr),
        //                                                action = ActionState.Open,
        //                                                bitArray = tmpl.ToArray(),
        //                                                valueArray = v5.value,
        //                                                模块类型 = tmpModel.模块类型,
        //                                                bit = 0xf1
        //                                            };
        //                                            MainForm.WriteDic.AddOrUpdate(v5.addr + "," + "场景_1", modlesMsg, (key, value) => value);
        //                                            ModlesMsg modlesMsg1 = new ModlesMsg()
        //                                            {
        //                                                addr = int.Parse(v5.addr),
        //                                                action = ActionState.Open,
        //                                                bitArray = tmpl.ToArray(),
        //                                                valueArray = v5.value,
        //                                                模块类型 = tmpModel.模块类型,
        //                                                bit = 0xf2
        //                                            };
        //                                            MainForm.WriteDic.AddOrUpdate(v5.addr + "," + "场景_2", modlesMsg1, (key, value) => value);
        //                                        }
        //                                    }
        //                                    //v1.openstate = 2;
        //                                }
        //                                if (v1.结束时间.TimeOfDay < currentDt.TimeOfDay && v1.结束时间.TimeOfDay >= lastCheckDatetime.TimeOfDay)
        //                                {
        //                                    foreach (var v5 in tmpMsg)
        //                                    {
        //                                        List<ushort> tmpl = new List<ushort>();
        //                                        foreach (var i in v5.channel)
        //                                            tmpl.Add((ushort)i);
        //                                        var tmpModel = ModelsOperate.GetModel(int.Parse(v5.addr));
        //                                        if (tmpModel == null)
        //                                            continue;
        //                                        if (tmpModel.模块类型 == "开关模块")
        //                                        {
        //                                            ModlesMsg modlesMsg = new ModlesMsg()
        //                                            {
        //                                                addr = int.Parse(v5.addr),
        //                                                action = ActionState.Close,
        //                                                bitArray = tmpl.ToArray(),
        //                                                valueArray = v5.value,
        //                                                模块类型 = tmpModel.模块类型,
        //                                                bit = 0xf1
        //                                            };
        //                                            MainForm.WriteDic.AddOrUpdate(v5.addr + "," + "场景", modlesMsg, (key, value) => value);
        //                                        }
        //                                        else if (tmpModel.模块类型 == "调光模块")
        //                                        {
        //                                            ModlesMsg modlesMsg = new ModlesMsg()
        //                                            {
        //                                                addr = int.Parse(v5.addr),
        //                                                action = ActionState.Close,
        //                                                bitArray = tmpl.ToArray(),
        //                                                valueArray = v5.value,
        //                                                模块类型 = tmpModel.模块类型,
        //                                                bit = 0xf1
        //                                            };
        //                                            MainForm.WriteDic.AddOrUpdate(v5.addr + "," + "场景_1", modlesMsg, (key, value) => value);
        //                                            ModlesMsg modlesMsg1 = new ModlesMsg()
        //                                            {
        //                                                addr = int.Parse(v5.addr),
        //                                                action = ActionState.Close,
        //                                                bitArray = tmpl.ToArray(),
        //                                                valueArray = v5.value,
        //                                                模块类型 = tmpModel.模块类型,
        //                                                bit = 0xf2
        //                                            };
        //                                            MainForm.WriteDic.AddOrUpdate(v5.addr + "," + "场景_2", modlesMsg1, (key, value) => value);
        //                                        }
        //                                    }
        //                                    //v1.closestate = 2;
        //                                }
        //                            }
        //                        }
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //    lastCheckDatetime = currentDt;
        //}

        //public static List<场景模块> 获取启用场景()
        //{
        //   var v = 场景设置.当前场景模块.FindAll(t=>t.启用标志 == true);
        //    return v;
        //}

        public static DateTime lastCheckDatetime = DateTime.Now;
        public static void FroeachScene()
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now;
            bool bSure = false;
            DateTime currentDt = DateTime.Now;
            if (lastCheckDatetime >= currentDt)
            {
                lastCheckDatetime = currentDt;
                return;
            }
            try
            {
                dt1 = 计算日出日落.计算日出时间(MainForm.currentParam.经度, MainForm.currentParam.维度, DateTime.Now);
                dt2 = 计算日出日落.计算日落时间(MainForm.currentParam.经度, MainForm.currentParam.维度, DateTime.Now);
                MainForm.日出日落时间 = string.Format("日出:{0} 日落:{1}", dt1.ToString("HH:mm:ss"),dt2.ToString("HH:mm:ss"));
                MainForm.日出时间 = dt1.ToString("HH:mm:ss");
                MainForm.日落时间 = dt2.ToString("HH:mm:ss");
                bSure = true;
            }
            catch (Exception ex)
            {
                bSure = false;
            }
            //for (int i = 0; i < ModelsOperate.ModelsList.Count; i++)
            //{
            //var v = ModelsOperate.ModelsList[i];
            //}

            var tmp = 场景设置.当前场景模块.Where((t, b) =>
            {
                if (t.启用标志)
                    return true;
                else
                    return false;
            }).ToList();
            foreach (var v1 in tmp)
            {
                if (tmp.FindIndex(t => t.模式 == SceneModel.国家公休日) != -1)
                {
                    string currentd = DateTime.Now.ToString("yyyyMMdd");
                    if (MainForm.国家公休日列表.FindIndex(t => t.日期 == currentd) != -1)
                    {
                        if (v1.模式 == SceneModel.工作日模式)
                            continue;
                    }
                    else
                    {
                        if (v1.模式 == SceneModel.国家公休日)
                            continue;
                        if (DateTime.Now.DayOfWeek == DayOfWeek.Monday && ((v1.星期数据 >> 0) & 0x01) == 1 ||
                            DateTime.Now.DayOfWeek == DayOfWeek.Tuesday && ((v1.星期数据 >> 1) & 0x01) == 1 ||
                            DateTime.Now.DayOfWeek == DayOfWeek.Wednesday && ((v1.星期数据 >> 2) & 0x01) == 1 ||
                            DateTime.Now.DayOfWeek == DayOfWeek.Thursday && ((v1.星期数据 >> 3) & 0x01) == 1 ||
                            DateTime.Now.DayOfWeek == DayOfWeek.Friday && ((v1.星期数据 >> 4) & 0x01) == 1 ||
                            DateTime.Now.DayOfWeek == DayOfWeek.Saturday && ((v1.星期数据 >> 5) & 0x01) == 1 ||
                            DateTime.Now.DayOfWeek == DayOfWeek.Sunday && ((v1.星期数据 >> 6) & 0x01) == 1)
                        { }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    if (DateTime.Now.DayOfWeek == DayOfWeek.Monday && ((v1.星期数据 >> 0) & 0x01) == 1 ||
                            DateTime.Now.DayOfWeek == DayOfWeek.Tuesday && ((v1.星期数据 >> 1) & 0x01) == 1 ||
                            DateTime.Now.DayOfWeek == DayOfWeek.Wednesday && ((v1.星期数据 >> 2) & 0x01) == 1 ||
                            DateTime.Now.DayOfWeek == DayOfWeek.Thursday && ((v1.星期数据 >> 3) & 0x01) == 1 ||
                            DateTime.Now.DayOfWeek == DayOfWeek.Friday && ((v1.星期数据 >> 4) & 0x01) == 1 ||
                            DateTime.Now.DayOfWeek == DayOfWeek.Saturday && ((v1.星期数据 >> 5) & 0x01) == 1 ||
                            DateTime.Now.DayOfWeek == DayOfWeek.Sunday && ((v1.星期数据 >> 6) & 0x01) == 1)
                    { }
                    else
                    {
                        continue;
                    }
                }
                if (DateTime.Now.Date >= v1.开始时间.Date && v1.结束时间.Date >= DateTime.Now.Date)
                {
                    foreach (var v2 in v1.场景子名称列表)
                    {
                        if (v2.定时方式 != SetTimeType.普通定时 && !bSure)
                            continue;
                        DateTime dt3;
                        if (v2.定时方式 == SetTimeType.普通定时)
                            dt3 = v2.动作时间;
                        else if (v2.定时方式 == SetTimeType.日出时间)
                            dt3 = dt1;
                        else
                            dt3 = dt2;
                        var Msg1 = 获取场景模块信息(v2);
                        if (lastCheckDatetime.TimeOfDay < dt3.TimeOfDay && dt3.TimeOfDay <= DateTime.Now.TimeOfDay)
                        {
                            var Msg = 获取场景模块信息(v2);
                            if (Msg != null)
                            {
                                foreach (var tmpMsg in Msg)
                                {
                                    List<ushort> tmpl = new List<ushort>();
                                    foreach (var ii in tmpMsg.channel)
                                        tmpl.Add((ushort)ii);
                                    var tmpModel = ModelsOperate.GetModel(int.Parse(tmpMsg.addr));
                                    if (tmpModel == null)
                                        continue;
                                    if (tmpModel.模块类型 == "开关模块")
                                    {
                                        ModlesMsg modlesMsg = new ModlesMsg()
                                        {
                                            addr = int.Parse(tmpMsg.addr),
                                            //action = v2.动作 ? ActionState.Open : ActionState.Close,
                                            bitArray = tmpl.ToArray(),
                                            valueArray = tmpMsg.value,
                                            模块类型 = tmpModel.模块类型,
                                            bit = 0xf1
                                        };
                                        MainForm.WriteDic.AddOrUpdate(tmpMsg.addr + "," + "场景", modlesMsg, (key, value) => value);
                                    }
                                    else if (tmpModel.模块类型 == "调光模块")
                                    {
                                        ModlesMsg modlesMsg = new ModlesMsg()
                                        {
                                            addr = int.Parse(tmpMsg.addr),
                                            //action = v2.动作 ? ActionState.Open : ActionState.Close,
                                            bitArray = tmpl.ToArray(),
                                            valueArray = tmpMsg.value,
                                            模块类型 = tmpModel.模块类型,
                                            bit = 0xf1
                                        };
                                        MainForm.WriteDic.AddOrUpdate(tmpMsg.addr + "," + "场景_1", modlesMsg, (key, value) => value);
                                        ModlesMsg modlesMsg1 = new ModlesMsg()
                                        {
                                            addr = int.Parse(tmpMsg.addr),
                                            //action = v2.动作 ? ActionState.Open : ActionState.Close,
                                            bitArray = tmpl.ToArray(),
                                            valueArray = tmpMsg.value,
                                            模块类型 = tmpModel.模块类型,
                                            bit = 0xf2
                                        };
                                        MainForm.WriteDic.AddOrUpdate(tmpMsg.addr + "," + "场景_2", modlesMsg1, (key, value) => value);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            lastCheckDatetime = currentDt;
        }
        public static List<SwitchMsg> 获取场景模块信息(场景子模块 msg)
        {
            try
            {
                List<SwitchMsg> tmpList = new List<SwitchMsg>();
                foreach (var v in msg.场景调试模块列表2)
                {
                    SwitchMsg tmp = new SwitchMsg();
                    tmp.addr = v.模块编号;
                    var v1 = v.场景开关信息列表.OrderBy(t => int.Parse(t.开关通道));
                    foreach (var v2 in v1)
                    {
                        tmp.channel[int.Parse(v2.开关通道) - 1] = v2.开关状态 == "是" ? 1 : 0;
                        tmp.value[int.Parse(v2.开关通道) - 1] = int.Parse(v2.开关亮度);
                    }
                    tmpList.Add(tmp);
                }
                return tmpList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
