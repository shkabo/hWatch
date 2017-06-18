using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hWatch
{
    public partial class Form1 : Form
    {
        private int pingTimer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // set max and min values for our timer
            // we don't want to get negative value !
            numericSeconds.Maximum = 600;
            numericSeconds.Minimum = 0;
        }

        // We started ping check
        private void btnWatch_Click(object sender, EventArgs e)
        {
            int rows = addressGridView.RowCount;

            if (rows > 1)
            {
                for ( int i = 0; i < rows - 1; i++)
                {
                    //PingDevice(addressGridView.Rows[i].Cells["IPAddress"].Value.ToString(), i);
                    Ping pingSender = new Ping();
                    //String addr = addressGridView.Rows[i].Cells["IPAddress"].Value.ToString();
                    String addr = addressGridView.Rows[i].Cells[0].EditedFormattedValue.ToString().Trim();

                    string ip = (Convert.ToInt16(addr.Replace(",", ".").Split('.')[0])).ToString();
                    ip += "." + (Convert.ToInt16(addr.Replace(",", ".").Split('.')[1])).ToString();
                    ip += "." + (Convert.ToInt16(addr.Replace(",", ".").Split('.')[2])).ToString();
                    ip += "." + (Convert.ToInt16(addr.Replace(",", ".").Split('.')[3])).ToString();

                    IPAddress address = System.Net.IPAddress.Parse(ip);
                    PingReply reply = pingSender.Send(address);

                    if (reply.Status == IPStatus.Success)
                    {
                        addressGridView.Rows[i].Cells[2].ReadOnly = false;
                        
                        addressGridView.Rows[i].Cells[2].Value = reply.RoundtripTime.ToString() + " ms";
                        addressGridView.Rows[i].Cells[2].ReadOnly = true;
                    }
                    else
                    {
                        addressGridView.Rows[i].Cells[2].Value = reply.Status.ToString();
                    }
                }
            }
        }

        // Get number of seconds between checks
        private void numericSeconds_ValueChanged(object sender, EventArgs e)
        {
            this.pingTimer = Decimal.ToInt32( numericSeconds.Value );
        }

        private void PingDevice(string ipAddr, int row)
        {
            Ping pingSender = new Ping();
            IPAddress address = System.Net.IPAddress.Parse(ipAddr);
            PingReply reply = pingSender.Send(address);

            if (reply.Status == IPStatus.Success)
            {
                addressGridView.Rows[row].Cells[2].Value = reply.RoundtripTime.ToString();
            }
            else
            {
                addressGridView.Rows[row].Cells[2].Value = reply.Status.ToString();
            }
        }
    }
}
