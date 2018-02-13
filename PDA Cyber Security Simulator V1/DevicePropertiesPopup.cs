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

        public DeviceProperties()
        {
            InitializeComponent();
            btnSaveDeviceProperties.DialogResult = DialogResult.OK;
            btnCancelPopup.DialogResult = DialogResult.Cancel;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveDeviceProperties_Click(object sender, EventArgs e)
        {
            Device = new Device(txtDeviceName.Text, txtDeviceIP.Text, txtDeviceMac.Text, txtDeviceDescription.Text, txtDeviceNotes.Text);







            

        }
    }
}
