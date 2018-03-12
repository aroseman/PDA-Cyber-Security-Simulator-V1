﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDA_Cyber_Security_Simulator_V1
{
    public class NetBuilderPresenter
    {
        private NetBuilder view;

        public NetBuilderPresenter(NetBuilder newView)
        {
            this.view = newView;
            this.view.RootCrumbClick += ShowHomeView;
            this.view.CanvasPaint += OnCanvasPaintClick;
            this.view.CanvasMouseDown += OnCanvasMouseDown;
            this.view.EnableLineDrawClick += OnEnableLineDrawClick;
            this.view.BtnSaveClick += OnBtnSaveClick;
            this.view.BtnClearNetworkClick += OnBtnClearNetworkClick;
        }

        public void OnCanvasPaintClick()
        {
            this.view.canvas_Paint(this.view.PaintEventArgs);
        }

        public void OnCanvasMouseDown()
        {
            this.view.canvas_MouseDown(this.view.MouseEventArgs);
        }

        public void OnEnableLineDrawClick()
        {
            this.view.enableLineDraw_MouseClick();
        }

        public void OnBtnSaveClick()
        {
            btnSave_Click();
        }

        public void OnBtnClearNetworkClick()
        {
            this.view.btnClearNetwork_Click();
        }

        public void ShowHomeView()
        {
            this.view.ShowHomeView();
        }

        public void btnSave_Click()
        {
            var netName = this.view.NetName;
            Network network = this.view.Network;
            Panel canvas = this.view.Canvas;

            if (string.IsNullOrWhiteSpace(netName))
            {
                MessageBox.Show(this.view, "ERROR: Empty Network Name");
            }
            else
            {
                MessageBox.Show(this.view, "Saved");
                //Algorithm for neighbor checking
                for (int i = 0; i < this.view.ActiveDevices.Count; i++)
                {
                    for (int j = 0; j < this.view.Pt1.Count; j++)
                    {
                        if (InBounds(this.view.ActiveDevices[i], this.view.Pt1[j]))
                        {
                            for (int k = 0; k < this.view.ActiveDevices.Count; k++)
                            {
                                if (InBounds(this.view.ActiveDevices[k], this.view.Pt2[j]))
                                {
                                    Device d1 = (Device)this.view.ActiveDevices[k].Tag;
                                    Device d2 = (Device)this.view.ActiveDevices[i].Tag;
                                    d1.Neighbors.Add(d2);
                                    d2.Neighbors.Add(d1);
                                    this.view.ActiveDevices[k].Tag = d1;
                                    this.view.ActiveDevices[i].Tag = d2;
                                }
                            }
                        }
                    }
                }

                //Now we want to push these devices into the network
                foreach (Control c in canvas.Controls)
                {
                    if (c is PictureBox)
                    {
                        if (c.Name != "picTrashCan")
                            //Grab the device object from the tag
                            //Push object into device list
                            network.Devices.Add((Device)c.Tag);
                    }
                }

                network.Name = netName;

                //Push network to db
                Network.addNetwork(network);

                //Grab the network Id generated by the DB
                network.Id = Network.getNetworkIdByName(network.Name);

                //assign the network ID to all devices inside the network
                for (int i = 0; i < network.Devices.Count; i++)
                {
                    network.Devices[i].NetID = network.Id;
                    Device.addDevice(network.Devices[i]);
                }


                var devices = Device.getDevicesByNetworkID(network.Id);
                network.Devices = devices;

                /*
                    PUSH NEIGHBORS INTO DB HERE 
                */
            }
        }

        private bool InBounds(PictureBox box, Point x)
        {
            //bool inBounds = true;

            //if ((x.X < box.Location.X || x.X > (box.Width + box.Location.X)) && (x.Y < box.Location.Y || x.Y > (box.Height + box.Location.Y)))
            //    inBounds = false;
            bool inBounds = false;

            if (x.X > box.Location.X && x.X < (box.Location.X + box.Width) && x.Y > box.Location.Y && x.Y < (box.Location.Y + box.Height))
                inBounds = true;

            return inBounds;
        }

    }
}