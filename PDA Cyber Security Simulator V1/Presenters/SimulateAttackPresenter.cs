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
    public class SimulateAttackPresenter
    {
        //private SimulateAttackView view { get; set; }
        private SimulateAttackView view;
        private UnitOfWork unitOfWork = new UnitOfWork();
        private NetworkTester PingTool = new NetworkTester();
        private AttackFactory attackFactory = new AttackFactory();
        private int ExceptionIndex;

        public SimulateAttackPresenter(SimulateAttackView newView)
        {
            this.view = newView;

            this.view.RootCrumbClick += OnRootCrumbClick;
            this.view.NetworkSelected += OnNetworkSelected;
            this.view.ComboBoxClick += OnNetworkComboClicked;
            this.view.AttackNetworkClick += OnAttackNetworkClicked;
            this.view.AttackComboBoxClick += OnAttackComboBoxClicked;

            //this.view.BreadCrumbClick += OnBreadCrumbClick;
        }

        public void OnBreadCrumbClick()
        {
            this.view.Hide();
            this.view.Form1.Show();
        }

        public void OnRootCrumbClick()
        {
            this.view.Form1.SimulateAttackPresenter = this;
            this.view.Form1.Show();
            this.view.Hide();
        }

        public void OnAttackNetworkClicked()
        {
            try
            {
                int input = this.view.AttacksComboBox1.SelectedIndex;
                string str = this.view.AttackDataSource[input].Value;
                IAttack attack = attackFactory.GetAttack(str);

                for (int i = 0; i < view.DeviceDataSource.Count; i++)
                {
                    if (view.AttackNetworkListBox1.GetSelected(i))
                    {
                        ExceptionIndex = i;
                        PingTool.TestDevice(view.Devices[i].IpAddress);
                        attack.AttackDevice(view.Devices[i].IpAddress, view.Devices[i].MacAddress);

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

            view.AttackNetworkComboBox1.DataSource = null;
            view.AttackNetworkComboBox1.DataSource = view.NetworkDataSource;
        }

        public void OnNetworkSelected()
        {
            var name = view.AttackNetworkComboBox1.GetItemText(view.AttackNetworkComboBox1.SelectedItem);
            var netid = unitOfWork.NetworkManager.GetNetworkIdByName(name);
            var dlist = unitOfWork.DeviceManager.GetDevicesByNetworkId(netid);
            view.Devices?.Clear();

            view.Devices = dlist;
            view.DeviceDataSource.Clear();
            foreach (var device in dlist)
            {
                view.DeviceDataSource.Add(new Language(device.Name, device.IpAddress));
            }

            view.AttackNetworkListBox1.DataSource = null;
            view.AttackNetworkListBox1.DataSource = view.DeviceDataSource;
        }

        public void OnAttackComboBoxClicked()
        {
            view.AttackDataSource.Add(new Language("Syn Flood", "SynFlood"));
            view.AttackDataSource.Add(new Language("ARP Flood", "ArpFlood"));
            view.AttackDataSource.Add(new Language("MAC Flood", "MacFlood"));
            view.AttacksComboBox1.DataSource = view.AttackDataSource;
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
