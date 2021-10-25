using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoIlkProjem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbPorts.Items.AddRange(SerialPort.GetPortNames());
        }

        private void btnBaglanti_Click(object sender, EventArgs e)
        {
            if (cmbPorts.SelectedIndex != -1)
            {
                if (btnBaglanti.Text == "Bağlan")
                {
                    btnBaglanti.Enabled = false;
                    serialPort1.PortName = cmbPorts.SelectedItem.ToString();
                    serialPort1.Open();
                    pboxBaglanti.BackColor = Color.Green;
                    btnBaglanti.Text = "Bağlantıyı Kes";
                    btnBaglanti.Enabled = true;
                    groupBox1.Enabled = true;
                }
                else
                {
                    btnBaglanti.Enabled = false;
                    pboxBaglanti.BackColor = Color.Red;
                    serialPort1.Close();
                    cmbPorts.Items.Clear();
                    cmbPorts.Items.AddRange(SerialPort.GetPortNames());
                    btnBaglanti.Text = "Bağlan";
                    btnBaglanti.Enabled = true;
                    groupBox1.Enabled = false;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Islem(pboxDurum, () => {
                pboxBaglanti.BackColor = Color.Red;
            });
            serialPort1.Close();
        }

        private void btnDurum_Click(object sender, EventArgs e)
        {
            string text = string.Empty;
            Islem(btnDurum, () => {
                text = btnDurum.Text;
            });
            serialPort1.Write((text == "Çalıştır") ? "1" : "0");
            Islem(btnDurum, () => {
                btnDurum.Enabled = false;
            });
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadExisting();
            if (data.Contains("1"))
            {
                Islem(btnDurum, () => {
                    btnDurum.Enabled = true;
                    btnDurum.Text = "Durdur";
                });
                Islem(pboxDurum, () => {
                    pboxDurum.BackColor = Color.Green;
                });
            }
            else if(data.Contains("2"))
            {
                Islem(btnDurum, () => {
                    btnDurum.Enabled = true;
                    btnDurum.Text = "Çalıştır";
                });
                Islem(pboxDurum, () => {
                    pboxDurum.BackColor = Color.Red;
                });
            }
        }

        public static void Islem(Control ctrl, Action islemler)
        {
            if (ctrl != null)
            {
                if (ctrl.InvokeRequired)
                {
                    try { ctrl.Invoke((MethodInvoker)delegate { islemler(); }); }
                    catch (ObjectDisposedException) { }
                    catch (Exception ex) { throw ex; }
                }
                else { islemler(); }
            }
        }
    }
}
