using System;
using System.Net.NetworkInformation;
using System.Windows.Forms;
namespace PDA_Cyber_Security_Simulator_V1
{
    public class NetworkTester
    {

       public void TestDevice(string ipAddress)
        {
            Boolean status = false;
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(ipAddress);

            if (reply.Status == IPStatus.Success)
            {
                status = true;

                Console.WriteLine("Address: " + reply.Address.ToString() + "\n");
                Console.WriteLine("RoundTrip time: " + reply.RoundtripTime + "\n");
                Console.WriteLine("Time to live: " + reply.Options.Ttl + "\n");
                Console.WriteLine("Don't fragment: " + reply.Options.DontFragment + "\n");
                Console.WriteLine("Buffer size: " + reply.Buffer.Length + "\n");
                Console.WriteLine("Device is available!" + "\n");
            }
            else
            {
                Console.WriteLine(reply.Status);
            }

           
        }
    }
}
