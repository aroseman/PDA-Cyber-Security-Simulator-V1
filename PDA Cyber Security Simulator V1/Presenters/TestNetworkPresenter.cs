using PDA_Cyber_Security_Simulator_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDA_Cyber_Security_Simulator_DAL.Common;
using PDA_Cyber_Security_Simulator_V1.Views;

namespace PDA_Cyber_Security_Simulator_V1.Presenters
{
    public class TestNetworkPresenter
    {
        private TestNetworkView view;
        private UnitOfWork unitOfWork = new UnitOfWork();
        private NetworkTester PingTool = new NetworkTester();
        private int ExceptionIndex;
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
            try
            {
                for (int i = 0; i < view.DeviceDataSource.Count; i++)
                {
                    if (view.TestNetworkListBox1.GetSelected(i))
                    {
                        ExceptionIndex = i;
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
                            if (PingTool.PingResult.RoundtripTime == 0)
                            {
                                view.PingTime[i].Text = "< 1 ms";
                            }
                            else
                            {
                                view.PingTime[i].Text = PingTool.PingResult.RoundtripTime + " ms";
                            }
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                view.DeviceNames[ExceptionIndex].Text = view.Devices[ExceptionIndex].Name;
                view.DeviceNames[ExceptionIndex].Show();
                view.RedDots[ExceptionIndex].Show();
                view.GreenDots[ExceptionIndex].Hide();
                view.IpLabels[ExceptionIndex].Show();
                view.DeviceIp[ExceptionIndex].Text = view.Devices[ExceptionIndex].IpAddress;
                view.DeviceIp[ExceptionIndex].Show();
                view.PingLabels[ExceptionIndex].Show();
            }            
        }

        public void OnNetworkComboClicked()
        {
            view.NetworkDataSource?.Clear();
            var netwWorkNames = unitOfWork.NetworkManager.GetAllNetworks();

            foreach (var networkName in netwWorkNames)
            {
                if (view.NetworkDataSource != null) view.NetworkDataSource.Add(new Language(networkName, networkName));
                else Console.Error.WriteLine("Network Data Source not initialized.");
            }

            view.TestNetworkComboBox1.DataSource = null;
            view.TestNetworkComboBox1.DataSource = view.NetworkDataSource;
        }

        public void OnNetworkSelected()
        {
            var name = view.TestNetworkComboBox1.GetItemText(view.TestNetworkComboBox1.SelectedItem);
            var netid = unitOfWork.NetworkManager.GetNetworkIdByName(name);
            var dlist = unitOfWork.DeviceManager.GetDevicesByNetworkId(netid);
            view.Devices?.Clear();

            view.Devices = dlist;
            view.DeviceDataSource.Clear();
            foreach (var device in dlist) 
            {
                view.DeviceDataSource.Add(new Language(device.Name, device.IpAddress));
            }

            view.TestNetworkListBox1.DataSource = null;
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
