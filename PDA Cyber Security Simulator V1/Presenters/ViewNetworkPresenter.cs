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
            view.DeviceDoubleClick += OnDeviceDoubleClick;
        }

        public void OnRootCrumbClick()
        {
            view.ShowHomeView();
        }

        public void OnDeviceDoubleClick()
        {
            DeviceProperties deviceProperties = new DeviceProperties((Device)view.CurrentDevice.Tag);
            DialogResult dialogResult = deviceProperties.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                unitOfWork.DeviceManager.UpdateDevice(deviceProperties.Device);
                for (var i = 0; i < view.DevicePictures.Count; i++)
                {
                    if ((Device) view.DevicePictures[i].Tag != null && ((Device) view.DevicePictures[i].Tag).Id == deviceProperties.Device.Id)
                    {
                        view.DeviceNames[i].Text = deviceProperties.Device.Name;
                        view.IpAddresses[i].Text = deviceProperties.Device.IpAddress;
                    }
                }
                view.CurrentDevice.Tag = deviceProperties.Device;
                deviceProperties.Dispose();
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                deviceProperties.Dispose();
            }
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
                DrawLines(LoadedNetwork.Devices.Count);
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
                    t.Configured = true;

                    foreach (var t1 in neighbors)
                    {
                        var neighboringDevice = unitOfWork.DeviceManager.GetDeviceById(t1.NeighborId);
                        t.Neighbors.Add(neighboringDevice);
                    }
                }

                switch (network.Devices.Count)
                {
                    case 2:
                        for (var i = 0; i < network.Devices.Count; i++)
                        {
                            view.DeviceNames[i * 6].Text = network.Devices[i].Name;
                            view.IpAddresses[i * 6].Text = network.Devices[i].IpAddress;
                            view.DeviceNames[i * 6].Visible = true;
                            view.IpLabels[i * 6].Visible = true;
                            view.IpAddresses[i * 6].Visible = true;
                            view.DevicePictures[i * 6].Visible = true;

                            view.DevicePictures[i * 6].Tag = network.Devices[i];
                        }
                        break;
                    case 3:
                        for (var i = 0; i < network.Devices.Count; i++)
                        {
                            view.DeviceNames[i * 4].Text = network.Devices[i].Name;
                            view.IpAddresses[i * 4].Text = network.Devices[i].IpAddress;
                            view.DeviceNames[i * 4].Visible = true;
                            view.IpLabels[i * 4].Visible = true;
                            view.IpAddresses[i * 4].Visible = true;
                            view.DevicePictures[i * 4].Visible = true;

                            view.DevicePictures[i * 4].Tag = network.Devices[i];
                        }
                        break;
                    case 4:
                        for (var i = 0; i < network.Devices.Count; i++)
                        {
                            view.DeviceNames[i * 3].Text = network.Devices[i].Name;
                            view.IpAddresses[i * 3].Text = network.Devices[i].IpAddress;
                            view.DeviceNames[i * 3].Visible = true;
                            view.IpLabels[i * 3].Visible = true;
                            view.IpAddresses[i * 3].Visible = true;
                            view.DevicePictures[i * 3].Visible = true;

                            view.DevicePictures[i * 3].Tag = network.Devices[i];
                        }
                        break;
                    case 5:
                        for (var i = 0; i < network.Devices.Count; i++)
                        {
                            view.DeviceNames[i * 2].Text = network.Devices[i].Name;
                            view.IpAddresses[i * 2].Text = network.Devices[i].IpAddress;
                            view.DeviceNames[i * 2].Visible = true;
                            view.IpLabels[i * 2].Visible = true;
                            view.IpAddresses[i * 2].Visible = true;
                            view.DevicePictures[i * 2].Visible = true;

                            view.DevicePictures[i * 2].Tag = network.Devices[i];
                        }
                        break;
                    default:
                        for (var i = 0; i < network.Devices.Count; i++)
                        {
                            view.DeviceNames[i].Text = network.Devices[i].Name;
                            view.IpAddresses[i].Text = network.Devices[i].IpAddress;
                            view.DeviceNames[i].Visible = true;
                            view.IpLabels[i].Visible = true;
                            view.IpAddresses[i].Visible = true;
                            view.DevicePictures[i].Visible = true;

                            view.DevicePictures[i].Tag = network.Devices[i];
                        }
                        break;
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

            switch (LoadedNetwork.Devices.Count)
            {
                case 2:
                    for (var i = 0; i < LoadedNetwork.Devices.Count; i++)
                    {
                        view.DevicePictures[i * 6].Visible = false;
                        view.DeviceNames[i * 6].Visible = false;
                        view.IpAddresses[i * 6].Visible = false;
                        view.IpLabels[i * 6].Visible = false;
                    }

                    break;
                case 3:
                    for (var i = 0; i < LoadedNetwork.Devices.Count; i++)
                    {
                        view.DevicePictures[i * 4].Visible = false;
                        view.DeviceNames[i * 4].Visible = false;
                        view.IpAddresses[i * 4].Visible = false;
                        view.IpLabels[i * 4].Visible = false;
                    }
                    break;
                case 4:
                    for (var i = 0; i < LoadedNetwork.Devices.Count; i++)
                    {
                        view.DevicePictures[i * 3].Visible = false;
                        view.DeviceNames[i * 3].Visible = false;
                        view.IpAddresses[i * 3].Visible = false;
                        view.IpLabels[i * 3].Visible = false;
                    }
                    break;
                case 5:
                    for (var i = 0; i < LoadedNetwork.Devices.Count; i++)
                    {
                        view.DevicePictures[i * 2].Visible = false;
                        view.DeviceNames[i * 2].Visible = false;
                        view.IpAddresses[i * 2].Visible = false;
                        view.IpLabels[i * 2].Visible = false;
                    }
                    break;
                default:
                    for (var i = 0; i < LoadedNetwork.Devices.Count; i++)
                    {
                        view.DevicePictures[i].Visible = false;
                        view.DeviceNames[i].Visible = false;
                        view.IpAddresses[i].Visible = false;
                        view.IpLabels[i].Visible = false;
                    }
                    break;
            }
            
            view.BtnLoadNetwork.Visible = true;
        }

        private void DrawLines(int deviceCount)
        {
            switch (deviceCount)
            {
                case 2:
                    for (var j = 0; j < deviceCount; j++)
                    {
                        var deviceCenterX = view.DevicePictures[j * 6].Location.X + (view.DevicePictures[j * 6].Width / 2);
                        var deviceCenterY = view.DevicePictures[j * 6].Location.Y + (view.DevicePictures[j * 6].Height / 2);

                        for (var k = 0; k < LoadedNetwork.Devices[j].Neighbors.Count; k++)
                        {
                            var neighborCenterX = 0;
                            var neighborCenterY = 0;
                            for (var l = 0; l < view.DevicePictures.Count; l++)
                            {
                                if (view.DevicePictures[l].Tag != null && LoadedNetwork.Devices[j].Neighbors[k].Name == ((Device)view.DevicePictures[l].Tag).Name)
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
                    break;
                case 3:
                    for (var j = 0; j < deviceCount; j++)
                    {
                        var deviceCenterX = view.DevicePictures[j * 4].Location.X + (view.DevicePictures[j * 4].Width / 2);
                        var deviceCenterY = view.DevicePictures[j * 4].Location.Y + (view.DevicePictures[j * 4].Height / 2);

                        for (var k = 0; k < LoadedNetwork.Devices[j].Neighbors.Count; k++)
                        {
                            var neighborCenterX = 0;
                            var neighborCenterY = 0;
                            for (var l = 0; l < view.DevicePictures.Count; l++)
                            {
                                if (view.DevicePictures[l].Tag != null && LoadedNetwork.Devices[j].Neighbors[k].Name == ((Device)view.DevicePictures[l].Tag).Name)
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
                    break;
                case 4:
                    for (var j = 0; j < deviceCount; j++)
                    {
                        var deviceCenterX = view.DevicePictures[j * 3].Location.X + (view.DevicePictures[j * 3].Width / 2);
                        var deviceCenterY = view.DevicePictures[j * 3].Location.Y + (view.DevicePictures[j * 3].Height / 2);

                        for (var k = 0; k < LoadedNetwork.Devices[j].Neighbors.Count; k++)
                        {
                            var neighborCenterX = 0;
                            var neighborCenterY = 0;
                            for (var l = 0; l < view.DevicePictures.Count; l++)
                            {
                                if (view.DevicePictures[l].Tag != null && LoadedNetwork.Devices[j].Neighbors[k].Name == ((Device)view.DevicePictures[l].Tag).Name)
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
                    break;
                case 5:
                    for (var j = 0; j < deviceCount; j++)
                    {
                        var deviceCenterX = view.DevicePictures[j * 2].Location.X + (view.DevicePictures[j * 2].Width / 2);
                        var deviceCenterY = view.DevicePictures[j * 2].Location.Y + (view.DevicePictures[j * 2].Height / 2);

                        for (var k = 0; k < LoadedNetwork.Devices[j].Neighbors.Count; k++)
                        {
                            var neighborCenterX = 0;
                            var neighborCenterY = 0;
                            for (var l = 0; l < view.DevicePictures.Count; l++)
                            {
                                if (view.DevicePictures[l].Tag != null && LoadedNetwork.Devices[j].Neighbors[k].Name == ((Device)view.DevicePictures[l].Tag).Name)
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
                    break;
                default:
                    for (var j = 0; j < deviceCount; j++)
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
                    break;
            }
        }
    }
}
