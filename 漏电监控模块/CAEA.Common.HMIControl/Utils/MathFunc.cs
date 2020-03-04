//=================================================================
//
//文件名:MathFunc
//
//Framework版本:4.0
//
//描述:根据角度获取弧度
//
//创建人:刘健
//
//创建日期:2016-09-08 14:44:40
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;

namespace CAEA.Common.HMIControl.Utils
{
	/// <summary>
	/// 
	/// </summary>
	public class HMIMath : Object
	{
		/// <summary>
		/// 获取角度对应的弧度
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
        public static float GetRadian ( float val )
		{
			return (float)(val * Math.PI / 180);
		}
	}
}
