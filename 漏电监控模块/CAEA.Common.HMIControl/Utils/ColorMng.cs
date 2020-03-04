//=================================================================
//
//�ļ���:ColorMng
//
//Framework�汾:4.0
//
//����:��ɫ������
//
//������:����
//
//��������:2016-09-08 14:44:40
//
//���ݳ��������������޹�˾ �Զ��� �����
//
//=================================================================

using System;
using System.Drawing;

namespace CAEA.Common.HMIControl.Utils
{
	/// <summary>
	/// ��ɫ����
	/// </summary>
	public class HMIColorManager : Object
	{
		public static double BlendColour ( double fg, double bg, double alpha )
		{
			double result = bg + (alpha * (fg - bg));
			if (result < 0.0)
				result = 0.0;
			if (result > 255)
				result = 255;
			return result;
		}

		public static Color StepColor ( Color clr, int alpha )
		{
			if ( alpha == 100 )
				return clr;
			
			byte a = clr.A;
			byte r = clr.R;
			byte g = clr.G;
			byte b = clr.B;
			float bg = 0;
				
			int _alpha = Math.Min(alpha, 200);
			_alpha = Math.Max(alpha, 0);
			double ialpha = ((double)(_alpha - 100.0))/100.0;
		    
			if (ialpha > 100)
			{
				// white
				bg = 255.0F;
				ialpha = 1.0F - ialpha; 
			}
			else
			{
				//black
				bg = 0.0F;
				ialpha = 1.0F + ialpha;  
			}
		    
			r = (byte)(HMIColorManager.BlendColour(r, bg, ialpha));
			g = (byte)(HMIColorManager.BlendColour(g, bg, ialpha));
			b = (byte)(HMIColorManager.BlendColour(b, bg, ialpha));
	    
			return Color.FromArgb ( a, r, g, b );
		}
	};
}
