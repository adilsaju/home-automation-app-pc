using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace WindowsFormsApplication1sabin
{
    public partial class Form1 : Form
    {
        bool isConnected = false;
        String[] ports;
        SerialPort port;
        public Form1()
        {
            InitializeComponent();
         //   disableControls();
            getAvailableComPorts();

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();
            }
            else
            {
                disconnectFromArduino();
            }
        }

        void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
        }

        private void connectToArduino()
        {
            isConnected = true;
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            port.Write("#STAR\n");
            button1.Text = "Disconnect";
          //  enableControls();
        }
     /*   private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (checkBox1.Checked)
                {
                    port.Write("#LED1ON\n");
                }
                else
                {
                    port.Write("#LED1OF\n");
                }
            }
        }*/
        private void disconnectFromArduino()
        {
            isConnected = false;
            port.Write("#STOP\n");
            port.Close();
            button1.Text = "Connect";
         //   disableControls();
           // resetDefaults();
        }

    /*    private void enableControls()
        {
            checkBox1.Enabled = true;
          
        }

        private void disableControls()
        {
            checkBox1.Enabled = false;
           
        }

        private void resetDefaults()
        {
            checkBox1.Checked = false;
           

        }*/

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                
                    port.Write("#LED1ON\n");
               
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {

                port.Write("#LED1OF\n");


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {

                port.Write("#LED2ON\n");


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {

                port.Write("#LED2OF\n");


            }
        }
    }
}
