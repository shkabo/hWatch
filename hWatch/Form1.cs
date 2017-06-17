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

        }

        // Get number of seconds between checks
        private void numericSeconds_ValueChanged(object sender, EventArgs e)
        {
            this.pingTimer = Decimal.ToInt32( numericSeconds.Value );
        }

        
    }

    class WatchStatus
    {
        public static string PingDevice(string ipAddr)
        {
            Ping pingSender = new Ping();
            IPAddress address = IPAddress.Parse(ipAddr);
            PingReply reply = pingSender.Send(address);

            if (reply.Status == IPStatus.Success)
            {
                return reply.RoundtripTime.ToString();
            } else
            {
                return reply.Status.ToString();
            }
        }
    }
}
