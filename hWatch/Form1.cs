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
using System.Configuration;

namespace hWatch
{
    public partial class Form1 : Form
    {
        private int pingTimer;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_Closing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // set max and min values for our timer
            // we don't want to get negative value !
            numericSeconds.Maximum = 600;
            numericSeconds.Minimum = 0;

            // load config file if exists
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count != 0 )
                {
                    foreach ( var key in appSettings.AllKeys)
                    {
                        if (key.Contains("IPADRESA"))
                        {
                            // last char of config key - number
                            string lastChar = key.Replace("IPADRESA_Trax", "");

                            // hack to get config params
                            string addr = appSettings[key];
                            string name = appSettings["NAME_Trax" + lastChar] ?? "";

                            addressGridView.Rows.Add(addr, name);
                        }
                    }
                }


            } catch (ConfigurationException)
            {
                MessageBox.Show("Error reading application settings");
            }
        }

        // Handle closing event and save current data to config file
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            this.SaveConfig();
        }

        // Add or update key in the config file
        private void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (value == null)
                {
                    return;
                }
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationException)
            {

                MessageBox.Show("Error saving application settings");
            }
        }

        // Save addresses to the config file
        private void SaveConfig()
        {

            for (int i = 0; i < addressGridView.Rows.Count - 1; i++)
            {
                try
                {
                    string addr = addressGridView.Rows[i].Cells[0].Value.ToString();
                    //string name = addressGridView.Rows[i].Cells[1].Value.ToString();
                    if (String.IsNullOrEmpty(addr))
                    {
                        return;
                        
                    }
                    // check if we have value for name cell or not ?
                    string name = !String.IsNullOrEmpty(addressGridView.Rows[i].Cells[1].EditedFormattedValue.ToString()) ? addressGridView.Rows[i].Cells[1].EditedFormattedValue.ToString() : "";

                    // save data in config file
                    this.AddUpdateAppSettings("IPADRESA_Trax" + i.ToString(), addr);
                    this.AddUpdateAppSettings("NAME_Trax" + i.ToString(), name);
                }
                catch (NullReferenceException)
                {
                    
                }
            }
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


        // Ping device method
        private async void PingDevice(int row)
        {
            
            Ping pingSender = new Ping();
            String addr = addressGridView.Rows[row].Cells[0].EditedFormattedValue.ToString().Trim();
            
            // Enable cell to be edited, and set text color to red
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
                    addressGridView.Rows[row].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.Blue };
                }
                
            }
            catch (PingException)
            {
                MessageBox.Show("Invalid IP/address: " + addr);
            }
            finally
            {
                if (pingSender != null)
                {
                    pingSender.Dispose();
                }

                // disable editing of this cell
                addressGridView.Rows[row].Cells[2].ReadOnly = true;
            }

            
        }
    }
}
