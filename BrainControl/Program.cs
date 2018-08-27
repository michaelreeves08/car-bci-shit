using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrainControl.Library;

namespace BrainControl
{
	class Program
	{
		static void Main(string[] args)
		{
			BtManager bt = new BtManager();
			bt.Start();

			Console.ReadLine();
		}
	}
}
