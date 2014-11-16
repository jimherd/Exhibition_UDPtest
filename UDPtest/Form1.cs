//
// Test program to send UDP packets to Robokid exhibition lighting system.
//
// @author  Jim Herd
// @date    May 2014
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;               // jth
using System.Net.Sockets;       // jth

namespace UDPtest {
    public partial class Form1 : Form {

        const int MBED_TO_PORT = 52000;             // jth
        const int MDEB_LISTEN_PORT = 52001;         // jth
        const string MBED1_IP = "10.10.10.149";     // jth

        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);  // jth
        IPAddress broadcast = IPAddress.Parse(MBED1_IP);                                        // jth

        UdpClient listener = new UdpClient(MDEB_LISTEN_PORT);                                   // jth
        IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, MDEB_LISTEN_PORT);                   // jth

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();    // jth
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool done = false;

            IPEndPoint ep = new IPEndPoint(broadcast, MBED_TO_PORT);            // jth
            string command = textBox1.Text;                                     // jth
            textBox2.AppendText("Command=" + command + Environment.NewLine);    // jth
            byte[] sendbuf = Encoding.ASCII.GetBytes(command);                  // jth
            s.SendTo(sendbuf, ep);                                              // jth
            textBox2.AppendText("Command sent" + Environment.NewLine);          // jth

/*            try {
                while (!done) {
                    textBox2.AppendText("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);

                    textBox2.AppendText("Received broadcast from " + groupEP.ToString() 
                        + " :\n" +  Encoding.ASCII.GetString(bytes, 0, bytes.Length) + "\n");
                }
            } catch (Exception ex) {
                textBox2.AppendText(ex.ToString());
            }  finally {
                listener.Close();
            }  */
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
