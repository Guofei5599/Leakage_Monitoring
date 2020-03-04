//=================================================================
//
//文件名:Renderer
//
//Framework版本:4.0
//
//描述:渲染器接口
//
//创建人:刘健
//
//创建日期:2016-09-08 13:44:40
//
//温州长江汽车电子有限公司 自动化 软件科
//
//=================================================================

using System;
using System.Drawing;

namespace CAEA.Common.HMIControl.Base
{
    /// <summary>
    /// 渲染器接口
    /// </summary>
    public interface IRenderer : IDisposable
    {
        object Control
        {
            set;
            get;
        }
        bool Update();
        void Draw(Graphics Gr);
    }
}
