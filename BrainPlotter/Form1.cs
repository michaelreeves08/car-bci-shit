using BrainControl.Library;
using BrainControl.Library.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BrainPlotter
{
	public partial class Form1 : Form
	{
		Queue<int> points = new Queue<int>();

		private SerialPort ard = new SerialPort();
		private readonly string saveFile;
		private static object locker = new object();
		private ushort writeThreshold = 0;

		private const float FOCUS_THRESHOLD = 1.15f;
		private const float FOCUS_SCOPE = .2f;

		public Form1()
		{
			InitializeComponent();
			saveFile = DateTime.Now.ToString("dd__HH-mm-ss") + ".csv";
			File.Create(saveFile);
			startArd("COM4");
			startBT();
		}

		private void startArd(string portName)
		{
			ard.PortName = portName;
			ard.BaudRate = 9600;
			//ard.Open();
		}

		private void startBT()
		{
			var bt = new BtManager("COM10");

			//BT data received
			bt.BtDataParsed += (o, e) =>
			{
				points.Enqueue(e.rawValue);
				fullAverageLabel.Invoke((MethodInvoker)(() => fullAverageLabel.Text = ("Full Focus Average: " + (int)points.Average()).ToString()));

				chart1.Invoke((MethodInvoker)(() => chart1.Series[0].Points.Add(e.rawValue)));

				//Keeps queue and chart counts below max chart x axis
				if (points.Count > chart1.ChartAreas[0].AxisX.Maximum - 1)
				{
					checkFocusThreshold(points);

					points.Dequeue();
					chart1.Invoke((MethodInvoker)(() => chart1.Series[0].Points.RemoveAt(0)));
				}

				//Writes values to CSV
				if (++writeThreshold >= chart1.ChartAreas[0].AxisX.Maximum - 1)
				{
					writeThreshold = 0;
					AppendToFile(saveFile, String.Join(",", points));
				}
			};
		}

		uint i = 0;

		private void checkFocusThreshold(IEnumerable<int> vals)
		{

			var fullRange = vals.ToList();
			var focusRange = fullRange.GetRange(0, (int)(vals.Count() * FOCUS_SCOPE)).Average();

			if (focusRange > fullRange.Average() * FOCUS_THRESHOLD)
			{
				Console.WriteLine(i++.ToString() + "  BING BANG BOOM REEEEEE");
				if(clickCheck.Checked)
					click();

				if (checkCom.Checked)
				{
					textBox1.Invoke((MethodInvoker)(() => textBox1.AppendText($"{++i} REEEE TRIGGERED\n")));
					ard.Write("ON");
				}
			}
			else
			{
				if (checkCom.Checked)
					ard.Write("OFF");
			}


			sampleLabel.Invoke((MethodInvoker)(() => sampleLabel.Text = $"Sample Buffer Average: {focusRange}"));
		}

		//Click Vars
		#region
		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
		private const int MOUSEEVENTF_LEFTDOWN = 0x02;
		private const int MOUSEEVENTF_LEFTUP = 0x04;
		private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
		private const int MOUSEEVENTF_RIGHTUP = 0x10;
		#endregion
		void click()
		{
			mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
		}

		private void AppendToFile(string path, string txt)
		{
			lock (locker)
			{
				using (FileStream file = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Read))
				using(StreamWriter writer = new StreamWriter(file, Encoding.UTF8))
				{
					writer.Write(txt);
				}
			}
		}
		~Form1()
		{
			ard.Close();
		}

		
	}
}
