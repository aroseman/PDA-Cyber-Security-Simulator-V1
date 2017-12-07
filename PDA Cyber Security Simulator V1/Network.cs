using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    class Network
    {
        //string name;

        Device[][] adjacenyList;

        public Network(string name)
        {
                Name = name;
        }

        public Network(string name, Device[][] adjacenyList)
        {
            Name = name;
            this.adjacenyList = adjacenyList;
        }

        //public void SetName(string name)
        //{
        //    this.name = name;
        //}

        //public string GetName()
        //{
        //    return this.name;
        //}
        public string Name { get; set; }    // Auto property.
        /*
         * Description: This will add a device to a network
         * Input: A Device
         * Output: N/A
         * */

            /// <summary>
            /// 
            /// </summary>
            /// <param name="dev"></param>
        public void AddDevice(Device dev)
        {
            // This will add a device to the adjaceny list(matrix) list[x][0].
            // Append value to first index of a new row in the list(matrix)
        }

        /*
         * Description: Adds two devices to each of their adjacency lists.
         * Input: Two Devices
         * Output:
         * */
        public void AddLink(Device a, Device b)
        {
            
        }


        /*
         * Description: Removes a device from the network.
         * Input: A single device.
         * Output:
         * */
        public void RemoveDevice(Device dev)
        {
            // Search Matrix for all instances of the device (Rows and Columns).
        }

        public void RemoveLink(Device a, Device b)
        {
            // Search a for b and remove it.
            // Search b for a and remove it.
        }

        // Build network
    }
}
