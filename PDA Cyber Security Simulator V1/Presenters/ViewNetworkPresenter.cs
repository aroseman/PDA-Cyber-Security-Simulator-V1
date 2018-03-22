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
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
