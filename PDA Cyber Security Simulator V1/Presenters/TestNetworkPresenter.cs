using PDA_Cyber_Security_Simulator_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDA_Cyber_Security_Simulator_DAL.Common;

namespace PDA_Cyber_Security_Simulator_V1
{
    public class TestNetworkPresenter
    {
        private TestNetworkView view;
        private UnitOfWork unitOfWork = new UnitOfWork();

        public TestNetworkPresenter(TestNetworkView newView)
        {
            this.view = newView;

            this.view.RootCrumbClick += OnRootCrumbClick;
            this.view.NetworkSelected += OnNetworkSelected;
            view.ComboBoxClick += OnNetworkComboClicked;
            //this.view.LoadNetworkNames(Network.getNetworkNames());
            //this.view.LoadDevices(Device.getDevices());
        }

        public void OnRootCrumbClick()
        {
            this.view.Form1.TestNetworkPresenter = this;
            this.view.Form1.Show();
            this.view.Hide();
        }

        public void OnNetworkComboClicked()
        {

            
            List<string> netwWorkNames = unitOfWork.NetworkManager.GetAllNetworks();
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
            this.view.LoadDevices(dlist);
        }

        public void ShowView()
        {
            this.view.ShowView();
        }

        public void HideView()
        {
            this.view.HideView();
        }

        public void NetworkListClick()
        {
            
            

        }
    }
}
