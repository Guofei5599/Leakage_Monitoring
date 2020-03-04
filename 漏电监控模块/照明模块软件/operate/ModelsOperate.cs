using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 照明模块软件
{
    public class ModelsOperate
    {
        public static List<调试模块> ModelsList = new List<调试模块>();
        public static List<调试模块> AllModelsList = new List<调试模块>();
        public static bool PanelCreate = false;


        public static void RefreshModel(List<byte[]> tmpList)
        {
            bool b = false;
            foreach (var v in tmpList)
            {
                int addr = (v[3] << 8) | v[4];
                int index = -1;
                if ((index = ModelsList.FindIndex(t => t.模块编号 == addr.ToString())) != -1)
                {
                    ModelsList[index].State = 2;
                    ModelsList[index].FalutState = 2;
                    if (ModelsList[index].为空)
                    {
                        ModelsList[index].为空 = false;
                    }
                    
                }
                else
                    continue;
                if (ModelsList[index].ModelsDataList == null)
                    ModelsList[index].ModelsDataList = new List<ModelsData>();
                if ((v[5] == 0x5A || v[5] == 0x57) && v[7] == 0x02)
                {
                    ModelsList[index].漏电路数 = 1;
                    ModelsList[index].温度路数 = 1;
                    ModelsList[index].模块类型 = "1路数码";
                    int value = v[9];
                    int tmpIndex = -1;
                    if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 1 && t.DataType == "漏电")) == -1)
                        ModelsList[index].ModelsDataList.Add(new ModelsData()
                        {
                            DataChannel = 1,
                            DataType = "漏电",
                            IsWarning = (value & 0x80) > 0 ? true : false
                    });
                    else
                    {
                        ModelsList[index].ModelsDataList[tmpIndex].DataType = "漏电";
                        ModelsList[index].ModelsDataList[tmpIndex].DataChannel = 1;
                        ModelsList[index].ModelsDataList[tmpIndex].IsWarning = (value & 0x80) > 0 ? true : false;
                    }

                    if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 1 && t.DataType == "温度")) == -1)
                        ModelsList[index].ModelsDataList.Add(new ModelsData()
                        {
                            DataChannel = 1,
                            DataType = "温度",
                            IsWarning = (value & 0x20) > 0 ? true : false
                        });
                    else
                    {
                        ModelsList[index].ModelsDataList[tmpIndex].DataType = "温度";
                        ModelsList[index].ModelsDataList[tmpIndex].DataChannel = 1;
                        ModelsList[index].ModelsDataList[tmpIndex].IsWarning = (value & 0x20) > 0 ? true : false;
                    }

                    if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 1 && t.DataType == "脱扣")) == -1)
                        ModelsList[index].ModelsDataList.Add(new ModelsData()
                        {
                            DataChannel = 1,
                            DataType = "脱扣",
                            IsWarning = (value & 0x01) > 0 ? true : false
                        });
                    else
                    {
                        ModelsList[index].ModelsDataList[tmpIndex].DataType = "脱扣";
                        ModelsList[index].ModelsDataList[tmpIndex].DataChannel = 1;
                        ModelsList[index].ModelsDataList[tmpIndex].IsWarning = (value & 0x01) > 0 ? true : false;
                    }

                }
                else if ((v[5] == 0x5A || v[5] == 0x57) && v[7] == 0x01)
                {
                    ModelsList[index].漏电路数 = 8;
                    ModelsList[index].温度路数 = 4;
                    ModelsList[index].模块类型 = "8路液晶";
                    int Lvalue = v[9];
                    int Tvalue = v[10];
                    int TKvalue = v[11];
                    int tmpIndex = -1;
                    for(int i = 1;i < ModelsList[index].漏电路数+1; i ++)
                    {
                        if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == i && t.DataType == "漏电")) == -1)
                            ModelsList[index].ModelsDataList.Add(new ModelsData()
                            {
                                DataChannel = i,
                                DataType = "漏电",
                                IsWarning = (Lvalue & (1<<(i-1))) > 0 ? true : false
                            });
                        else
                        {
                            ModelsList[index].ModelsDataList[tmpIndex].DataType = "漏电";
                            ModelsList[index].ModelsDataList[tmpIndex].DataChannel = i;
                            ModelsList[index].ModelsDataList[tmpIndex].IsWarning = (Lvalue & (1 << (i - 1))) > 0 ? true : false;
                        }
                   }

                    for (int i = 1; i < ModelsList[index].温度路数 + 1; i++)
                    {
                        if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == i && t.DataType == "温度")) == -1)
                            ModelsList[index].ModelsDataList.Add(new ModelsData()
                            {
                                DataChannel = i,
                                DataType = "温度",
                                IsWarning = (Tvalue & (1 << (i - 1))) > 0 ? true : false
                            });
                        else
                        {
                            ModelsList[index].ModelsDataList[tmpIndex].DataType = "温度";
                            ModelsList[index].ModelsDataList[tmpIndex].DataChannel = i;
                            ModelsList[index].ModelsDataList[tmpIndex].IsWarning = (Tvalue & (1 << (i - 1))) > 0 ? true : false;
                        }
                    }
                       

                    if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 1 && t.DataType == "脱扣")) == -1)
                        ModelsList[index].ModelsDataList.Add(new ModelsData()
                        {
                            DataChannel = 1,
                            DataType = "脱扣",
                            IsWarning = (TKvalue == 0x02) ? true : false
                        });
                    else
                    {
                        ModelsList[index].ModelsDataList[tmpIndex].DataType = "脱扣";
                        ModelsList[index].ModelsDataList[tmpIndex].DataChannel = 1;
                        ModelsList[index].ModelsDataList[tmpIndex].IsWarning = (TKvalue == 0x02) ? true : false;
                    }
                }
                else if ((v[5] == 0x5A || v[5] == 0x57) && v[7] == 0x03)
                {
                    ModelsList[index].漏电路数 = 16;
                    ModelsList[index].温度路数 = 4;
                    ModelsList[index].模块类型 = "16路液晶";
                    int LvalueH = v[8];
                    int LvalueL = v[9];
                    int Lvalue = (v[8] << 8 | v[9]);
                    int Tvalue = v[10];
                    int TKvalue = v[12];
                    int tmpIndex = -1;
                    for (int i = 1; i < ModelsList[index].漏电路数 + 1; i++)
                    {
                        if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == i && t.DataType == "漏电")) == -1)
                            ModelsList[index].ModelsDataList.Add(new ModelsData()
                            {
                                DataChannel = i,
                                DataType = "漏电",
                                IsWarning = (Lvalue & (1 << (i - 1))) > 0 ? true : false
                            });
                        else
                        {
                            ModelsList[index].ModelsDataList[tmpIndex].DataType = "漏电";
                            ModelsList[index].ModelsDataList[tmpIndex].DataChannel = i;
                            ModelsList[index].ModelsDataList[tmpIndex].IsWarning = (Lvalue & (1 << (i - 1))) > 0 ? true : false;
                        }
                    }

                    for (int i = 1; i < ModelsList[index].温度路数 + 1; i++)
                    {
                        if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == i && t.DataType == "温度")) == -1)
                            ModelsList[index].ModelsDataList.Add(new ModelsData()
                            {
                                DataChannel = i,
                                DataType = "温度",
                                IsWarning = (Tvalue & (1 << (i - 1))) > 0 ? true : false
                            });
                        else
                        {
                            ModelsList[index].ModelsDataList[tmpIndex].DataType = "温度";
                            ModelsList[index].ModelsDataList[tmpIndex].DataChannel = i;
                            ModelsList[index].ModelsDataList[tmpIndex].IsWarning = (Tvalue & (1 << (i - 1))) > 0 ? true : false;
                        }
                    }


                    if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 1 && t.DataType == "脱扣")) == -1)
                        ModelsList[index].ModelsDataList.Add(new ModelsData()
                        {
                            DataChannel = 1,
                            DataType = "脱扣",
                            IsWarning = (TKvalue == 0x01) ? true : false
                        });
                    else
                    {
                        ModelsList[index].ModelsDataList[tmpIndex].DataType = "脱扣";
                        ModelsList[index].ModelsDataList[tmpIndex].DataChannel = 1;
                        ModelsList[index].ModelsDataList[tmpIndex].IsWarning = (TKvalue == 0x01) ? true : false;
                    }
                }
                else if (v[5] == 0x03)
                {
                    int value1 = 0;
                    int value2 = 0;
                    int value3 = 0;
                    int tmpIndex = -1;
                    int channel = ModelsList[index].漏电路数;
                    if (channel != 1 || channel != 8 || channel != 16)
                        continue;
                    switch (v[6])
                    {
                        case 0x00:
                            if (channel == 1)
                            {
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 1 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[10] << 8) | v[9]);
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 1 && t.DataType == "温度")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = v[11] * 0.1;
                                }
                            }
                            else if (channel == 8 || channel == 16)
                            {
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 1 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[10] << 8) | v[9]);
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 2 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[12] << 8) | v[11]);
                                }
                            }
                            break;
                        case 0x06:
                            if (channel == 8 || channel == 16)
                            {
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 3 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[8] << 8) | v[7]);
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 4 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[10] << 8) | v[9]);
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 5 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[12] << 8) | v[11]);
                                }
                            }
                            break;
                        case 0x0c:
                            if (channel == 8 || channel == 16)
                            {
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 6 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[8] << 8) | v[7]);
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 7 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[10] << 8) | v[9]);
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 8 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[12] << 8) | v[11]);
                                }
                            }
                            break;
                        case 0x12:
                            if (channel == 8)
                            {
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 1 && t.DataType == "温度")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = v[7] * 0.1;
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 2 && t.DataType == "温度")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = v[9] * 0.1;
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 3 && t.DataType == "温度")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = v[11] * 0.1;
                                }
                            }
                            else if (channel == 16)
                            {
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 9 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[8] << 8) | v[7]);
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 10 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[10] << 8) | v[9]);
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 11 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[12] << 8) | v[11]);
                                }
                            }
                            break;
                        case 0x18:
                            if (channel == 8)
                            {
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 4 && t.DataType == "温度")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = v[7] * 0.1;
                                }
                            }
                            else if (channel == 16)
                            {
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 12 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[8] << 8) | v[7]);
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 13 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[10] << 8) | v[9]);
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 14 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[12] << 8) | v[11]);
                                }
                            }
                            break;
                        case 0x1E:
                            if (channel == 16)
                            {
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 15 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[8] << 8) | v[7]);
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 16 && t.DataType == "漏电")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = ((v[10] << 8) | v[9]);
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 1 && t.DataType == "温度")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = v[11] * 0.1;
                                }
                            }
                            break;
                        case 0x24:
                            if (channel == 16)
                            {
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 2 && t.DataType == "温度")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = v[7] * 0.1;
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 3 && t.DataType == "温度")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = v[9] * 0.1;
                                }
                                if ((tmpIndex = ModelsList[index].ModelsDataList.FindIndex(t => t.DataChannel == 4 && t.DataType == "温度")) != -1)
                                {
                                    ModelsList[index].ModelsDataList[tmpIndex].DataValue = v[11] * 0.1;
                                }
                            }
                            break;
                    }
                }
                else
                {
                    ModelsList[index].模块类型 = "模块异常";
                }
            }
        }

        public static void ClearModelMsg()
        {
            foreach (var v in AllModelsList)
            {
                v.安装位置 = "";
                v.模块名称 = "";
                v.为空 = false;
            }
        }

        public static 调试模块 GetModel(int addr)
        {
           return ModelsList.Find(t=>t.模块编号 == addr.ToString());
        }
        public static int GetMaxAddr()
        {
            if (ModelsList == null || ModelsList.Count == 0)
                return 0;
            var v = ModelsList.OrderBy(t=>int.Parse(t.模块编号)).ToList();
            return int.Parse( v[v.Count - 1].模块编号);
        }
        public static void Add(int addr)
        {
            if (ModelsList.FindIndex(t => t.模块编号 == addr.ToString()) == -1)
            {
                PanelCreate = true;
                AllModelsList.Add(new 调试模块() { 模块编号 = addr.ToString() });
            }
        }
        public static void Add(int addr,int state)
        {
            if (ModelsList.FindIndex(t => t.模块编号 == addr.ToString()) == -1)
            {
                ModelsList.Add(new 调试模块() { 模块编号 = addr.ToString() , State = state});
            }
        }
        public static void Delete(int addr)
        {
            int index = -1;
            if ((index = ModelsList.FindIndex(t => t.模块编号 == addr.ToString())) != -1)
            {
                ModelsList[index].IsRemove = true;
            }
        }
        public static void Modify(int addr,string name,string area,string channel,bool 为空)
        {
            int index = -1;
            if ((index = ModelsList.FindIndex(t => t.模块编号 == addr.ToString())) != -1)
            {
                ModelsList[index].安装位置 = area;
                ModelsList[index].模块名称 = name;
                ModelsList[index].为空 = 为空;
            }
        }
        public static void Modify(int addr, int state)
        {
            int index = -1;
            if ((index = ModelsList.FindIndex(t => t.模块编号 == addr.ToString())) != -1)
            {
                ModelsList[index].State = state;
            }
        }
        public static void Modify(int addr, int state,int FaultState)
        {
            int index = -1;
            if ((index = ModelsList.FindIndex(t => t.模块编号 == addr.ToString())) != -1)
            {
                ModelsList[index].State = state;
                ModelsList[index].FalutState = FaultState;
            }
        }
        public static void Display(DataGridView dgv)
        {
            dgv.Rows.Clear();
            foreach (var v in ModelsList)
            {
                dgv.Rows.Add(new object[] {v.为空,v.模块编号,v.模块名称,v.模块类型,"",v.安装位置  });
            }
        }
        public static void OnlyDisplay(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                int index = -1;
                if ((index = ModelsList.FindIndex(t => t.模块编号 == Convert.ToString(row.Cells["模块地址"].Value))) != -1)
                {
                    row.Cells["安装位置"].Value = ModelsList[index].安装位置;
                    row.Cells["模块名称"].Value = ModelsList[index].模块名称;
                    row.Cells["为空"].Value = ModelsList[index].为空;
                }
            }
        }
        public static void Sort()
        {
            //ModelsList = ModelsList.OrderBy(t=>Convert.ToInt32( t.模块编号)).ToList();
            //for (int i = 0; i < ModelsList.Count; i++)
            //{
            //    ModelsList[i].开关列表 = ModelsList[i].开关列表.OrderBy(t=>int.Parse(t.开关编号)).ToList();
            //}
        }
    }
}
