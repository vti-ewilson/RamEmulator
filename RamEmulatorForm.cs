using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RamEmulator
{
	public partial class RamEmulatorForm : Form
	{
		SerialPort port;
		System.Threading.Thread comThread;
		bool disconnectClicked = false;
		int counts = 0;
		Mutex mutex = new Mutex();
		string Response;

		public RamEmulatorForm()
		{
			InitializeComponent();
		}

		private void populateComPortMenu()
		{
			COMPortDropdown.Items.AddRange(
					System.IO.Ports.SerialPort.GetPortNames()
						.OrderBy(s => s)
						.Distinct()
						.ToArray());
		}

		private void RamEmulatorForm_Load(object sender, EventArgs e)
		{
			populateComPortMenu();
			timer1.Enabled = true;

			// Generate random values for each byte
			byte statusByte = 0xf0;
			byte alarms = 0xff;
			byte inputs = 0xff;
			byte outputs = 0x10;
			byte end = 0xdd;

			// Construct response string (ensuring proper hex format with leading zeros)
			Response = "RESP" +
				statusByte.ToString("X2") +
				alarms.ToString("X2") +
				inputs.ToString("X2") +
				outputs.ToString("X2") +
				end.ToString("X2") +
				end.ToString("X2") +
				end.ToString("X2") +
				end.ToString("X2");

			mutex.WaitOne();
			textBox1.Text = Response;
			mutex.ReleaseMutex();
		}

		private string GetDropdownValue()
		{
			if(COMPortDropdown.SelectedItem != null)
				return COMPortDropdown.SelectedItem.ToString();
			else
				return "";
		}

		private void SetButtonStates(bool connected)
		{
			if(connected)
			{
				connectButton.Enabled = false;
				disconnectButton.Enabled = true;
				connectButton.BackColor = Color.LightGreen;
				disconnectButton.BackColor = Color.White;
			}
			else
			{
				connectButton.Enabled = true;
				disconnectButton.Enabled = false;
				disconnectButton.BackColor = Color.Red;
				connectButton.BackColor = Color.White;
			}

		}

		private void communicate()
		{
			string portName = (string)COMPortDropdown.Invoke(new Func<string>(() => GetDropdownValue()));
			if(portName == "")
			{
				connectButton.Invoke(new Action(() => SetButtonStates(false)));
				return;
			}
			port = new SerialPort(portName, 9600);
			port.Open();
			byte[] buffer;
			string recd, msg;
			int position = 0;
			
			while(!disconnectClicked)
			{
				int count = port.BytesToRead;
				if(count >= 2)
				{
					buffer = new byte[count];
					var str = port.Read(buffer, 0, count);
					recd = Encoding.Default.GetString(buffer);
					Console.WriteLine(recd);

					mutex.WaitOne();
					if(recd.StartsWith(":0103")) // read register
					{
						int address = 0;
						if(Int32.TryParse(recd.Substring(5, 4), NumberStyles.HexNumber, CultureInfo.CurrentCulture, out address))
						{
							if(address >= 0x1000 && address <= 0x3FFF)
							{
								string resp = "01030C000007D000001F4000003A98E8000000000000000000000000000000000000";
								port.WriteLine(resp + "\r\n");
							}
							else if(address == 0x0500) // alarm codes
							{
								string alarms = "01030C0000FFFF000000E82AD1D07B24";
								port.WriteLine(alarms + "\r\n");
							}
							else if(address == 0x9000) //getting position
							{
								string resp = "010314" + position.ToString("X8") + "0000B80162002000800031C7000800111C";
								port.WriteLine(resp + "\r\n");
							}
							else if(address == 0x9005)
							{
								port.WriteLine("01039000080FFFF000000E\r\n");
							}
							else
							{
								port.WriteLine(recd + "\r\n");
							}
						}
					}
					else if(recd.StartsWith(":01109900000204")) // setting position
					{
						position = Int32.Parse(recd.Substring(15, 8), NumberStyles.HexNumber);
						port.WriteLine(recd + "\r\n");
					}
					else
					{
						port.WriteLine(recd + "\r\n");
					}
					mutex.ReleaseMutex();
				}
				else
				{
					Thread.Sleep(10);
				}
			}
			disconnectClicked = false;
			port.Close();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
		}

		private void connectButton_Click(object sender, EventArgs e)
		{
			SetButtonStates(true);

			comThread = new Thread(() => communicate());
			comThread.Start();
		}

		private void disconnectButton_Click(object sender, EventArgs e)
		{
			SetButtonStates(false);
			disconnectClicked = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			mutex.WaitOne();
			Response = textBox1.Text;
			mutex.ReleaseMutex();
		}
	}
}
