using System;
using System.Net.NetworkInformation;
using System.Windows.Forms;
namespace PDA_Cyber_Security_Simulator_V1
{
    public class NetworkTester
    {
        public PingReply PingResult { get; set; }

       public void TestDevice(string ipAddress)
        {
            Boolean status = false;
            Ping pingSender = new Ping();

            for (int i = 0; i < 4; i++)
            {
                PingResult = pingSender.Send(ipAddress);
            }

            if (PingResult.Status == IPStatus.Success)
            {
                status = true;

                Console.WriteLine("Address: " + PingResult.Address.ToString() + "\n");
                Console.WriteLine("RoundTrip time: " + PingResult.RoundtripTime + "\n");
                Console.WriteLine("Time to live: " + PingResult.Options.Ttl + "\n");
                Console.WriteLine("Don't fragment: " + PingResult.Options.DontFragment + "\n");
                Console.WriteLine("Buffer size: " + PingResult.Buffer.Length + "\n");
                Console.WriteLine("Device is available!" + "\n");
            }
            else
            {
                Console.WriteLine(PingResult.Status);
            }

           
        }
    }
}
