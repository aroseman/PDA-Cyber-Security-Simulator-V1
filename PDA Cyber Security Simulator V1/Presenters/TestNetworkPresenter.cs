using PDA_Cyber_Security_Simulator_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using PDA_Cyber_Security_Simulator_DAL.Common;
using PDA_Cyber_Security_Simulator_V1.Views;

namespace PDA_Cyber_Security_Simulator_V1.Presenters
{
    public class TestNetworkPresenter
    {
        private TestNetworkView view;
        private UnitOfWork unitOfWork = new UnitOfWork();
        private NetworkTester PingTool = new NetworkTester();
        public TestNetworkPresenter(TestNetworkView newView)
        {
            this.view = newView;

            this.view.RootCrumbClick += OnRootCrumbClick;
            this.view.NetworkSelected += OnNetworkSelected;
            this.view.ComboBoxClick += OnNetworkComboClicked;
            this.view.TestNetworkClick += OnTestNetworkClicked;
   
        }

        public void OnRootCrumbClick()
        {
            this.view.Form1.TestNetworkPresenter = this;
            this.view.Form1.Show();
            this.view.Hide();
        }

        public void OnTestNetworkClicked()
        {
           // List<string> selectedDevices = new List<string>();
            for (int i = 0; i < view.DeviceDataSource.Count; i++)
            {
                if (view.TestNetworkListBox1.GetSelected(i))
                {
                    PingTool.TestDevice(view.Devices[i].IpAddress);
                    if (PingTool.PingResult.Status == IPStatus.Success)
                    {
                        view.DeviceNames[i].Text = view.Devices[i].Name;
                        view.DeviceNames[i].Show();
                        view.GreenDots[i].Show();
                        view.RedDots[i].Hide();
                        view.IpLabels[i].Show();
                        view.DeviceIp[i].Text = view.Devices[i].IpAddress;
                        view.DeviceIp[i].Show();
                        view.PingLabels[i].Show();
                        view.PingTime[i].Text = PingTool.PingResult.RoundtripTime.ToString();
                        view.PingTime[i].Show();
                    }
                    else
                    {
                        view.DeviceNames[i].Text = view.Devices[i].Name;
                        view.DeviceNames[i].Show();
                        view.RedDots[i].Show();
                        view.GreenDots[i].Hide();
                        view.IpLabels[i].Show();
                        view.DeviceIp[i].Text = view.Devices[i].IpAddress;
                        view.DeviceIp[i].Show();
                        view.PingLabels[i].Show();
                    }
                }
            }
        }

        public void OnNetworkComboClicked()
        {

            
            var netwWorkNames = unitOfWork.NetworkManager.GetAllNetworks();
            
            foreach (var networkName in netwWorkNames)
            {
                if (view.NetworkDataSource != null) view.NetworkDataSource.Add(new Language(networkName, networkName));
                else Console.Error.WriteLine("Network Data Source not initialized.");
            }

            view.TestNetworkComboBox1.DataSource = view.NetworkDataSource;
        }

        public void OnNetworkSelected()
        {
            String name = this.view.SelectedNetwork;
            int netid = unitOfWork.NetworkManager.GetNetworkIdByName(name);
            List<Device> dlist = unitOfWork.DeviceManager.GetDevicesByNetworkId(netid);
            view.Devices = dlist;
            view.DeviceDataSource.Clear();
            foreach (var device in dlist) 
            {
                view.DeviceDataSource.Add(new Language(device.Name, device.IpAddress));
            }

            view.TestNetworkListBox1.DataSource = view.DeviceDataSource;
        }

        public void ShowView()
        {
            this.view.ShowView();
        }

        public void HideView()
        {
            this.view.HideView();
        }

        
    }
}
