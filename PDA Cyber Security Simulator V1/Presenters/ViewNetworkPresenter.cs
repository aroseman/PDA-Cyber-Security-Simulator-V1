using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDA_Cyber_Security_Simulator_DAL.Common;
using PDA_Cyber_Security_Simulator_Domain;
using PDA_Cyber_Security_Simulator_V1.Views;

namespace PDA_Cyber_Security_Simulator_V1.Presenters
{
    public class ViewNetworkPresenter
    {
        private ViewNetwork view;
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ViewNetworkPresenter(ViewNetwork newView)
        {
            view = newView;
            view.BtnLoadNetworkClick += OnBtnLoadNetworkClick;
        }

        public void OnBtnLoadNetworkClick()
        {
            LoadNetworkClick();
        }

        public void LoadNetworkClick()
        {
            try
            {
                //Load in the specified network
                var network = unitOfWork.NetworkManager.GetNetworkByName(view.TxtNetworkName.Text);
                var devices = unitOfWork.DeviceManager.GetDevicesByNetworkId(network.Id);
                network.Devices = devices;
                foreach (var t in network.Devices)
                {
                    var neighbors = unitOfWork.NeighborManager.GetNeighbors(t.Id);

                    foreach (var t1 in neighbors)
                    {
                        var neighboringDevice = unitOfWork.DeviceManager.GetDeviceById(t1.NeighborId);
                        t.Neighbors.Add(neighboringDevice);
                    }
                }

                //Push device properties onto view
                for (var i = 0;  i < network.Devices.Count; i++)
                {
                    view.DeviceNames[view.DeviceNames.Count - i - 1].Text = network.Devices[network.Devices.Count - i - 1].Name;
                    view.IpAddresses[i].Text = network.Devices[network.Devices.Count - i - 1].IpAddress;
                    view.DeviceNames[view.DeviceNames.Count - i - 1].Visible = true;
                    view.IpLabels[view.IpLabels.Count - i - 1].Visible = true;
                    view.IpAddresses[i].Visible = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
