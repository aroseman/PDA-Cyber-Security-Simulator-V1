using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDA_Cyber_Security_Simulator_Domain;
using PDA_Cyber_Security_Simulator_V1.Presenters;
using PDA_Cyber_Security_Simulator_V1.Views;

namespace PDA_Cyber_Security_Simulator_V1.Interfaces
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

        List<Point> Pt1 { get; }
        List<Point> Pt2 { get; }
        List<PictureBox> ActiveDevices { get; }
        Panel Canvas { get; }

        String NetName { get; }
        Network Network { get; }
    }
}
