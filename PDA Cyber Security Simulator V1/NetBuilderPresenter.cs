using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.view.btnSave_Click();
        }

        public void OnBtnClearNetworkClick()
        {
            this.view.btnClearNetwork_Click();
        }

        public void ShowHomeView()
        {
            this.view.ShowHomeView();
        }
    }
}
