using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Windows.Forms;
namespace PDA_Cyber_Security_Simulator_V1
{
   public class NetworkTester
    {
       public void TestDevice(string ipAddress, TextBox tb)
        {
            Boolean status = false;
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(ipAddress);

            if (reply.Status == IPStatus.Success)
            {
                status = true;

                tb.AppendText("Address: " + reply.Address.ToString() + "\n");
                tb.AppendText("RoundTrip time: " + reply.RoundtripTime + "\n");
                tb.AppendText("Time to live: " + reply.Options.Ttl + "\n");
                tb.AppendText("Don't fragment: " + reply.Options.DontFragment + "\n");
                tb.AppendText("Buffer size: " + reply.Buffer.Length + "\n");
                tb.AppendText("Device is available!" + "\n");
            }
            else
            {
                Console.WriteLine(reply.Status);
            }

           
        }
    }
}
