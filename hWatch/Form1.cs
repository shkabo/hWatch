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
                    this.PingDevice(i);
                }
            }
        }

        // Get number of seconds between checks
        private void numericSeconds_ValueChanged(object sender, EventArgs e)
        {
            this.pingTimer = Decimal.ToInt32( numericSeconds.Value );
        }

        private async void PingDevice(int row)
        {
            
            Ping pingSender = new Ping();
            String addr = addressGridView.Rows[row].Cells[0].EditedFormattedValue.ToString().Trim();
            addressGridView.Rows[row].Cells[2].ReadOnly = false;
            addressGridView.Rows[row].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.Red };
            try
            {
                PingReply reply = await pingSender.SendPingAsync(addr, 2000);

                if (reply.Status == IPStatus.Success)
                {
                    
                    addressGridView.Rows[row].Cells[2].Value = reply.RoundtripTime.ToString() + " ms";
                    addressGridView.Rows[row].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.Green };
                }
                else
                {
                    addressGridView.Rows[row].Cells[2].Value = reply.Status.ToString();
                    addressGridView.Rows[row].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.Black };
                }
                
            }
            catch (System.Net.NetworkInformation.PingException)
            {

                MessageBox.Show("Invalid IP or bad address: " + addr);
            }
            finally
            {
                if (pingSender != null)
                {
                    pingSender.Dispose();
                }
                addressGridView.Rows[row].Cells[2].ReadOnly = true;
            }

            
        }
    }
}
