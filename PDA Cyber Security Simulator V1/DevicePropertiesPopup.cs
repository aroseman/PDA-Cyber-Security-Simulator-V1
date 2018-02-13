using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDA_Cyber_Security_Simulator_V1
{
    public partial class DeviceProperties : Form
    {
        public Device Device { get; set; }
        public DeviceProperties(Device device)
        {
            InitializeComponent();
            InitializeDeviceProperties(device);
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

        private void btnSaveDeviceProperties_Click(object sender, EventArgs e)
        {
            if( Device.Configured != true)
            {
                Device = new Device(txtDeviceName.Text, txtDeviceIP.Text, txtDeviceMac.Text, txtDeviceDescription.Text, txtDeviceNotes.Text);
                Device.Configured = true;
            }
            
            else
            {
                Device.Name = txtDeviceName.Text;
                Device.IpAddress = txtDeviceIP.Text;
                Device.MacAddress = txtDeviceMac.Text;
                Device.Description = txtDeviceDescription.Text;
                Device.Notes = txtDeviceNotes.Text;
            }
            


            


            

        }
    }
}
