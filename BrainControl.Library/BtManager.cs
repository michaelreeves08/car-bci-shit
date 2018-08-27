using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using BrainControl.Library.models;

namespace BrainControl.Library
{
	public delegate void BtEventHandler(object sender, BtDataEventArgs e);

    public partial class BtManager
    {

		public event BtEventHandler BtDataParsed;

		private SerialPort bt;

		private const int MAX_PACKET_LENGTH = 32;
		private const int EEG_POWER_BANDS = 8;
		private byte lastByte;
		private bool inPacket = false;
		private bool freshPacket = false;
		private int packetIndex = 0;
		private int checksumAccumulator = 0;
		private int packetLength = 0;
		private int checkSum = 0;
		private uint[] eegPower = new uint[EEG_POWER_BANDS];
		private byte[] packetData = new byte[MAX_PACKET_LENGTH];

		private int signalQuality = 200;
		private int focus = 0;
		private int meditation = 0;

		public BtManager(string comPort)
		{
			bt = new SerialPort(comPort, 9600, Parity.None, 8, StopBits.One);
			bt.DataReceived += BtDataReceived;

			bt.Open();
		}
		protected virtual void OnBtDataParsed(BtDataEventArgs e)
		{
			BtDataParsed?.Invoke(this, e);
		}

		private void BtDataReceived (object o, SerialDataReceivedEventArgs e)
		{
			SerialPort sender = (SerialPort)o;

			int len = sender.BytesToRead;
			byte[] buffer = new byte[len];
			sender.Read(buffer, 0, len);

			byte[] sampleBuffer = new byte[256];

			if(buffer.Length >= 256)
				Array.Copy(buffer, sampleBuffer, 256);

			foreach (var b in sampleBuffer)
			{
				if (inPacket)
				{
					if (packetIndex == 0)
					{
						packetLength = b;

						if (packetLength > MAX_PACKET_LENGTH)
							inPacket = false;
					}
					else if(packetIndex <= packetLength)
					{
						packetData[packetIndex - 1] = b;

						checksumAccumulator += b;
					}
					else if(packetIndex > packetLength)
					{
						checkSum = b;
						checksumAccumulator = 255 - checksumAccumulator;

						if(checkSum == checksumAccumulator)
						{
							if (parsePacket())
							{
								freshPacket = true;
							}
							else
							{
								Console.WriteLine("ERROR: PARSING PACKET FAILED");
							}
						}
						else
						{
							//Console.WriteLine("ERROR: CHECKSUM");
						}
						inPacket = false;
					}
					packetIndex++;
				}


				if (b == 170 && lastByte == 170 && !inPacket)
				{
					inPacket = true;
					packetIndex = 0;
					checksumAccumulator = 0;
				}

				lastByte = b;
			}

			if (freshPacket)
				freshPacket = false;
		}

		private bool parsePacket()
		{
			bool parseSuccess = true;
			int rawValue = 0;

			clearEegPower();

			for (int i = 0; i < packetLength; i++)
			{
				switch (packetData[i])
				{
					case 0x2:
						signalQuality = packetData[++i];
						break;
					case 0x4:
						focus = packetData[++i];
						break;
					case 0x5:
						meditation = packetData[++i];
						break;
					case 0x83:
						i++;
						for (int j = 0; j < EEG_POWER_BANDS; j++)
							eegPower[j] = ((uint)packetData[++i] << 8) | packetData[++i];
						break;
					case 0x80:
						i++;
						rawValue = (packetData[++i] << 8) | packetData[++i];
						break;
					default:
						parseSuccess = false;
						break;
				}
			}

			//Don't allow for outliers
			//if (rawValue <= 200)
			OnBtDataParsed(new BtDataEventArgs() { rawValue = rawValue});

			return parseSuccess;
		}

		private void clearEegPower()
		{
			for (int i = 0; i < EEG_POWER_BANDS; i++)
			{
				eegPower[i] = 0;
			}
		}

		public void Start()
		{
			bt.Open();
		}
		public void Stop()
		{
			bt.Close();
		}
		public void printValues()
		{
			Console.WriteLine($"Focus: {focus}");
			Console.WriteLine($"Meditation: {meditation}");
			Console.WriteLine($"Signal: {signalQuality}");
		}

		~BtManager()
		{
			if (bt.IsOpen)
				bt.Close();
		}
    }
}
