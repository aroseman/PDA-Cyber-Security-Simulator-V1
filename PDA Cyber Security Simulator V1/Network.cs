using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    public class Network
    {
        //string name;

        

        public Network(string name)
        {
                Name = name;
        }

        public Network(string name, Device[][] adjacenyList)
        {
            Name = name;
            
        }

        public List<Device> Devices { get; set; }
        public string Name { get; set; }    

        /// <summary>
        /// This will add a device to a network
        /// </summary>
        /// <param name="dev"></param>
        public void AddDevice(Device dev)
        {
            Devices.Add(dev);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void AddLink(Device a, Device b)
        {
            
        }

        /// <summary>
        /// Removes a device from the network.
        /// </summary>
        /// <param name="dev"></param>
        public void RemoveDevice(Device dev)
        {
            // Search Matrix for all instances of the device (Rows and Columns).
        }

        /// <summary>
        ///  Removes a link from two Devices.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void RemoveLink(Device a, Device b)
        {
           
        }

        
    }
}
