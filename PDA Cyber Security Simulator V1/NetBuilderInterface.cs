﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDA_Cyber_Security_Simulator_V1
{
    interface NetBuilderInterface
    {
        event Action CanvasPaint;
        event Action CanvasMouseDown;
        event Action BtnSaveClick;
        event Action BtnClearNetworkClick;
        event Action EnableLineDrawClick;
        event Action RootCrumbClick;

        PaintEventArgs PaintEventArgs { get; set; }
        MouseEventArgs MouseEventArgs { get; set; }

        HomeView Form1 { get; }
        HomeViewPresenter Form1Presenter { get; }
    }
}
