//=================================================================
//
//�ļ���:MathFunc
//
//Framework�汾:4.0
//
//����:���ݽǶȻ�ȡ����
//
//������:����
//
//��������:2016-09-08 14:44:40
//
//���ݳ��������������޹�˾ �Զ��� �����
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
		/// ��ȡ�Ƕȶ�Ӧ�Ļ���
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
        public static float GetRadian ( float val )
		{
			return (float)(val * Math.PI / 180);
		}
	}
}
