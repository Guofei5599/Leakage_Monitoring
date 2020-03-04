//=================================================================
//
//文件名:MeterThreshold
//
//Framework版本:4.0
//
//描述:为仪表盘刻度线提供类支持
//
//创建人:刘健
//
//创建日期:2016-09-12 13:45:48
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;
using System.Drawing;
using System.Collections;

namespace CAEA.Common.HMIControl.Meter
{
    public class MeterThreshold
    {
        #region (*属性变量*)
        private Color color = Color.Empty;
        private double startValue = 0.0;
        private double endValue = 1.0;
        #endregion

        #region (* 构造函数 *)
        public MeterThreshold()
        {
        }
        #endregion

        #region (* 属性 *)
        public Color Color
        {
            set { this.color = value; }
            get { return this.color; }
        }

        public double StartValue
        {
            set { this.startValue = value; }
            get { return this.startValue; }
        }

        public double EndValue
        {
            set { this.endValue = value; }
            get { return this.endValue; }
        }
        #endregion

        #region (* Public 方法 *)
        public bool IsInRange(double val)
        {
            if (val > this.EndValue)
                return false;

            if (val < this.StartValue)
                return false;

            return true;
        }
        #endregion
    }

    /// <summary>
    /// 为MeterThreshold提供集合接口
    /// </summary>
    public class MeterThresholdCollection : CollectionBase
    {
        #region (* 属性变量 *)
        private bool _IsReadOnly = false;
        #endregion

        #region (* 构造函数 *)
        public MeterThresholdCollection()
        {
        }
        #endregion

        #region (* 属性 *)
        public virtual MeterThreshold this[int index]
        {
            get { return (MeterThreshold)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public virtual bool IsReadOnly
        {
            get { return _IsReadOnly; }
        }
        #endregion

        #region (* Public 方法 *)
        /// <summary>
        /// 添加一个元素进入集合
        /// </summary>
        /// <param name="sector"></param>
        public virtual void Add(MeterThreshold sector)
        {
            InnerList.Add(sector);
        }

        /// <summary>
        ///从集合中删除一个元素
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        public virtual bool Remove(MeterThreshold sector)
        {
            bool result = false;

            //循环
            for (int i = 0; i < InnerList.Count; i++)
            {
                //循环中当前元素
                MeterThreshold obj = (MeterThreshold)InnerList[i];

                //元素比较
                if ((obj.StartValue == sector.StartValue) &&
                    (obj.EndValue == sector.EndValue))
                {
                    //移除当前元素
                    InnerList.RemoveAt(i);
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 比较集合中是否含有指定元素
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        public bool Contains(MeterThreshold sector)
        {
            foreach (MeterThreshold obj in InnerList)
            {
                if ((obj.StartValue == sector.StartValue) &&
                    (obj.EndValue == sector.EndValue))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 拷贝指定的集合，需要在子类中重写
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        public virtual void CopyTo(MeterThreshold[] MeterThresholdArray, int index)
        {
            throw new Exception("This Method is not valid for this implementation.");
        }
        #endregion
    }
}
