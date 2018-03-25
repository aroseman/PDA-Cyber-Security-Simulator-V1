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
        private Network LoadedNetwork { get; set; }

        public ViewNetworkPresenter(ViewNetwork newView)
        {
            view = newView;
            view.ComboViewNetworkClick += OnComboViewNetworkClick;
            view.BtnLoadNetworkClick += OnBtnLoadNetworkClick;
            view.FormPaint += OnFormPaint;
            view.RootCrumbClick += OnRootCrumbClick;
            view.BtnResetViewNetworkClick += OnBtnResetViewNetworkClick;
        }

        public void OnRootCrumbClick()
        {
            view.ShowHomeView();
        }

        public void OnBtnLoadNetworkClick()
        {
            LoadNetworkClick();
        }

        public void OnComboViewNetworkClick()
        {
            ComboViewNetworkClick();
        }

        public void OnBtnResetViewNetworkClick()
        {
            ResetViewNetworkClick();
        }

        public void OnFormPaint()
        {
            if (view.NetworkLoaded)
            {
                for (var j = 0; j < LoadedNetwork.Devices.Count; j++)
                {
                    var deviceCenterX = view.DevicePictures[j].Location.X + (view.DevicePictures[j].Width / 2);
                    var deviceCenterY = view.DevicePictures[j].Location.Y + (view.DevicePictures[j].Height / 2);

                    for (var k = 0; k < LoadedNetwork.Devices[j].Neighbors.Count; k++)
                    {
                        var neighborCenterX = 0;
                        var neighborCenterY = 0;
                        for (var l = 0; l < view.DevicePictures.Count; l++)
                        {
                            if (LoadedNetwork.Devices[j].Neighbors[k].Name == ((Device)view.DevicePictures[l].Tag).Name)
                            {
                                neighborCenterX = view.DevicePictures[l].Location.X +
                                                  (view.DevicePictures[l].Width / 2);
                                neighborCenterY = view.DevicePictures[l].Location.Y +
                                                  (view.DevicePictures[l].Height / 2);

                                //We have our location, break this loop, start next loop
                                break;
                            }
                        }

                        view.PaintEventArgs.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        view.PaintEventArgs.Graphics.DrawLine(view.Pen, deviceCenterX, deviceCenterY, neighborCenterX, neighborCenterY);

                    }
                }
            }
        }

        public void LoadNetworkClick()
        {
            try
            {
                //Load in the specified network
                var network = unitOfWork.NetworkManager.GetNetworkByName(view.ComboNetworkNames.Text);
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
                    view.DeviceNames[i].Text = network.Devices[network.Devices.Count - i - 1].Name;
                    view.IpAddresses[i].Text = network.Devices[network.Devices.Count - i - 1].IpAddress;
                    view.DeviceNames[i].Visible = true;
                    view.IpLabels[i].Visible = true;
                    view.IpAddresses[i].Visible = true;
                    view.DevicePictures[i].Visible = true;

                    view.DevicePictures[i].Tag = network.Devices[i];
                }

                LoadedNetwork = network;
                view.NetworkLoaded = true;
                view.PanelViewNetwork.Invalidate();
                view.BtnLoadNetwork.Visible = false;
                view.BtnResetViewNetwork.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void ComboViewNetworkClick()
        {
            view.ComboNetworkNames.Items.Clear();

            var networkNames = unitOfWork.NetworkManager.GetAllNetworks();

            foreach (var name in networkNames)
            {
                view.ComboNetworkNames.Items.Add(name);
            }
        }

        public void ResetViewNetworkClick()
        {
            view.NetworkLoaded = false;
            view.PanelViewNetwork.Invalidate();

            for (var i = 0; i < LoadedNetwork.Devices.Count; i++)
            {
                view.DevicePictures[i].Visible = false;
                view.DeviceNames[i].Visible = false;
                view.IpAddresses[i].Visible = false;
                view.IpLabels[i].Visible = false;
            }

            view.BtnLoadNetwork.Visible = true;
        }
    }
}
