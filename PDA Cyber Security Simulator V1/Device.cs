using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    public class Device
    {
        private string name;
        private string ipAddress;
        private string macAddress;
        private string status;
        private List<Device> neighbors;
        private string notes;

        public string Status { get; set; }
        public string IP { get; set; }
        public Device(string name, string ipAddress, string macAddress, string notes)
        {
            this.name = name;
            this.ipAddress = ipAddress;
            this.macAddress = macAddress;
            this.notes = notes;
            
        }

        public Device(string name, string ipAddress, string macAddress)
        {
            this.name = name;
            this.ipAddress = ipAddress;
            this.macAddress = macAddress;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetIPAddress()
        {
            return this.ipAddress;
        }

        public void SetIPAddress(string ipAddress)
        {
            this.ipAddress = ipAddress;
        }

        public string GetMacAddress()
        {
            return this.macAddress;
        }

        public void SetMacAddress(string macAddress)
        {
            this.macAddress = macAddress;
        }

        public string GetNotes()
        {
            return this.notes;
        }

        public void SetNotes(string notes)
        {
            this.notes = notes;
        }

       

    }

}
