using System;
using System.Net;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using PDA_Cyber_Security_Simulator_V1.Domain;

namespace PDA_Cyber_Security_Simulator_V1
{
    public partial class DeviceProperties : Form
    {
        public Device Device { get; set; }
        private bool CancelPopup = false;
        private bool MacValid = false;

        public DeviceProperties(Device device)
        {
            InitializeComponent();
            InitializeDeviceProperties(device);
            this.ControlBox = false;
            btnSaveDeviceProperties.DialogResult = DialogResult.OK;
            btnCancelPopup.DialogResult = DialogResult.Cancel;
            Device = device;
        }

        private void InitializeDeviceProperties(Device device)
        {
            txtDeviceName.Text = device.Name;
            txtDeviceIP.Text = device.IpAddress;
            txtDeviceMac.Text = device.MacAddress;
            txtDeviceDescription.Text = device.Description;
            txtDeviceNotes.Text = device.Notes;
        }

        private void DeviceProperties_Load(object sender, EventArgs e)
        {
            txtDeviceMac.ValidatingType = typeof(PhysicalAddress);
            txtDeviceMac.TypeValidationCompleted += new TypeValidationEventHandler(txtDeviceMac_TypeValidationCompleted);
        }

        private void btnSaveDeviceProperties_Click(object sender, EventArgs e)
        {
            if (Device.Configured != true)
            {
                Device = new Device(txtDeviceName.Text, txtDeviceIP.Text, txtDeviceMac.Text, txtDeviceDescription.Text, txtDeviceNotes.Text);
                Device.Configured = true;
            }

            else
            {
                MacValid = true;

                Device.Name = txtDeviceName.Text;
                Device.IpAddress = txtDeviceIP.Text;
                Device.MacAddress = txtDeviceMac.Text;
                Device.Description = txtDeviceDescription.Text;
                Device.Notes = txtDeviceNotes.Text;
            }
        }

        private void txtDeviceMac_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!CancelPopup)
            {
                if (e.IsValidInput)
                {
                    MacValid = true;
                }
                else
                {
                    MacValid = false;
                    MessageBox.Show("Error! Invalid MAC address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelPopup_Click(object sender, EventArgs e)
        {
            CancelPopup = true;
        }

        private void DeviceProperties_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CancelPopup)
            {
                if (MacValid)
                {
                    if (string.IsNullOrEmpty(txtDeviceIP.Text))
                    {
                        
                    }
                    else
                    {

                        IPAddress address;

                        if (IPAddress.TryParse(txtDeviceIP.Text, out address))
                        {
                            switch (address.AddressFamily)
                            {
                                case System.Net.Sockets.AddressFamily.InterNetwork:
                                    if (txtDeviceIP.Text.Length > 6 && txtDeviceIP.Text.Contains("."))
                                    {
                                        string[] s = txtDeviceIP.Text.Split('.');
                                        if (s.Length == 4 && s[0].Length > 0 && s[1].Length > 0 && s[2].Length > 0 && s[3].Length > 0)
                                        {
                                            //we have a valid IP
                                            break;
                                        }
                                        else
                                        {
                                            e.Cancel = true;
                                            MessageBox.Show("Error! Invalid IPv4 address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        e.Cancel = true;
                                        MessageBox.Show("Error! Invalid IPv4 address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    break;


                                case System.Net.Sockets.AddressFamily.InterNetworkV6:
                                    //We are IPv6, throw error
                                    e.Cancel = true;
                                    MessageBox.Show("Error! Invalid IPv4 address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;

                                default:
                                    e.Cancel = true;
                                    MessageBox.Show("Error! Invalid IPv4 address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                            }
                        }
                        else
                        {
                            e.Cancel = true;
                            MessageBox.Show("Error! Invalid IPv4 address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("Error! Invalid MAC address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
