using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5AB2D2_G
{
    public partial class MainForm : Form
    {
        public string path;
        public long size;
        public FileStream fin;
        public System.IO.FileInfo file;
        public bool debug = false;
        public byte[] buf = new byte[132];
        public int c, t;
        public int[] q = new int[2];

       
        public static ushort crc16new(byte[] buf, int len)
        {
            ushort crc = 0xFFFF;
            for (int pos = 0; pos < len; pos++)
            {
                crc = (ushort)(crc ^ buf[pos]);
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 1) != 0)
                    {
                        crc = (ushort)(crc >> 1);
                        crc = (ushort)(crc ^ 0x8005);
                    }
                    else
                    {
                        crc = (ushort)(crc >> 1);
                    }
                }
            }
            crc = (ushort)(crc ^ 0xFFFF);

            buf[len] = (byte) crc;
            buf[len+1] = (byte) (crc >> 8);
            return crc;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                serialPorts.Items.Add(ports[i]);
            }
        }

        private void serialBtn_Click(object sender, EventArgs e)
        {
            try
            {
                serial.PortName = serialPorts.Text;
                serial.BaudRate = (int)serialBaud.Value;
                serial.DataBits = 8;
                serial.Parity = System.IO.Ports.Parity.None;
                serial.StopBits = System.IO.Ports.StopBits.One;
                serial.ReadTimeout = 1000;
                serial.WriteTimeout = 1000;
                serial.Open();

                serial.Close();

                serialBtn.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                serial.Close();
                serialBtn.BackColor = Color.Red;
                MessageBox.Show(ex.Message,
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
        }

        private void serialRenew_Click(object sender, EventArgs e)
        {
            serialPorts.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                serialPorts.Items.Add(ports[i]);
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                fireBtn.Enabled = true;
            }
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void serial_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            try
            {
                try
                {
                    if (!debug) serial.Close();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message,
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                }
                try
                {
                    fin.Close();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message,
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                 "Ошибка",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error,
                                 MessageBoxDefaultButton.Button1,
                                 MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void fireBtn_Click(object sender, EventArgs e)
        {
            try
            {

                fin = new FileStream(path, FileMode.Open);
                file = new System.IO.FileInfo(path);
                size = file.Length;

                if (!debug)
                {
                    serial.PortName = serialPorts.Text;
                    serial.BaudRate = (int)serialBaud.Value;
                    if (DTRchk.Checked)
                    {
                        serial.DtrEnable = true;
                    }
                    serial.Open();

                    q[0] = 0;
                    q[1] = 0;
                    do
                    {
                        q[0] = serial.ReadByte();
                        q[1] = serial.ReadByte();
                    } while ((q[0] != 0xC2) || (q[1] != 0xD5));
                }
                for (int j = 1; j < (size / 128); j++)
                {
                    buf[0] = 0xE1;
                    buf[1] = 0xC2;
                    for (int i = 0; i < 128; i++)
                    {
                        c = fin.ReadByte();
                        if (c != -1)
                        {
                            buf[i + 2] = (byte)c;
                        }
                        else
                        {
                            buf[i + 2] = 0xFF;
                        }
                    }
                    crc16new(buf, 130);
                    if (!debug) serial.Write(buf, 0, 132);
                    do
                    {
                         t = serial.ReadByte();
                    } while ((t != 0x38) && (t != 0x04) && (t != 0xD2));
                    if (t == 0x04) {
                        if (!debug) serial.Write(buf, 0, 132);
                    }
                    else if (t == 0xd2)
                    {
                        try
                        {
                            if (!debug) serial.Close();
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show(ex1.Message,
                                        "Ошибка",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error,
                                        MessageBoxDefaultButton.Button1,
                                        MessageBoxOptions.DefaultDesktopOnly);
                        }
                        try
                        {
                            fin.Close();
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show(ex1.Message,
                                        "Ошибка",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error,
                                        MessageBoxDefaultButton.Button1,
                                        MessageBoxOptions.DefaultDesktopOnly);
                        }
                        MessageBox.Show("Ошибка! Перезапустите приложение, программируемое устройство и начните процесс заново.",
                                        "Сообщение 5AB2D2-G",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error,
                                        MessageBoxDefaultButton.Button1,
                                        MessageBoxOptions.DefaultDesktopOnly);
                        progressBar.Value = 0;
                        return;
                    }
                    progressBar.Value = (j * 12800) / ((int)size);
                }
                if (size % 128 > 0)
                {
                    buf[0] = 0xE1;
                    buf[1] = 0xC2;
                    for (int i = 0; i < 128; i++)
                    {
                        c = fin.ReadByte();
                        if (c != -1)
                        {
                            buf[i + 2] = (byte)c;
                        }
                        else
                        {
                            buf[i + 2] = 0xFF;
                        }
                    }
                    crc16new(buf, 130);
                    if (!debug) serial.Write(buf, 0, 132);
                    do
                    {
                        t = serial.ReadByte();
                    } while ((t != 0x38) && (t != 0x04) && (t != 0xD2));
                    if (t == 0x04)
                    {
                        if (!debug) serial.Write(buf, 0, 132);
                    }
                    else if (t == 0xd2)
                    {
                        try
                        {
                            if (!debug) serial.Close();
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show(ex1.Message,
                                        "Ошибка",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error,
                                        MessageBoxDefaultButton.Button1,
                                        MessageBoxOptions.DefaultDesktopOnly);
                        }
                        try
                        {
                            fin.Close();
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show(ex1.Message,
                                        "Ошибка",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error,
                                        MessageBoxDefaultButton.Button1,
                                        MessageBoxOptions.DefaultDesktopOnly);
                        }
                        MessageBox.Show("Ошибка! Перезапустите приложение, программируемое устройство и начните процесс заново.",
                                        "Сообщение 5AB2D2-G",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error,
                                        MessageBoxDefaultButton.Button1,
                                        MessageBoxOptions.DefaultDesktopOnly);
                        progressBar.Value = 0;
                        return;
                    }
                }
                progressBar.Value = 100;
                buf[0] = 0xD2;
                buf[1] = 0x38;
                for (int i = 0; i < 128; i++)
                {
                    c = fin.ReadByte();
                    if (c != -1)
                    {
                        buf[i + 2] = (byte)c;
                    }
                    else
                    {
                        buf[i + 2] = 0xFF;
                    }
                }
                crc16new(buf, 130);
                if (!debug) serial.Write(buf, 0, 132);
                do
                {
                    t = serial.ReadByte();
                } while ((t != 0xC5) && (t != 0xD2));

                if (!debug) serial.Close();
                fin.Close();

                if (t == 0xC5)
                {
                    MessageBox.Show("Успех! Это «пять»!",
                                "Сообщение 5AB2D2-G",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.None,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                }
                else
                {
                    MessageBox.Show("Ошибка! Это «два»!",
                                "Сообщение 5AB2D2-G",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                }


                progressBar.Value = 0;

                Console.WriteLine("Готово!");
                Console.WriteLine("");

            }
            catch (Exception ex)
            {
                try
                {
                    if (!debug) serial.Close();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message,
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                }
                try
                {
                    fin.Close();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message,
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                }

                MessageBox.Show(ex.Message,
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);                
                return;
            }
        }
    }
}
