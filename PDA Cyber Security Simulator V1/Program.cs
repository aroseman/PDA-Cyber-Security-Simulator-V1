using PDA_Cyber_Security_Simulator_Domain;
using System;
using System.Windows.Forms;
using PDA_Cyber_Security_Simulator_DAL.Common;

namespace PDA_Cyber_Security_Simulator_V1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Makes tables on first install
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.DeviceManager.CreateDeviceTable();
            unitOfWork.NetworkManager.CreateTable();
            unitOfWork.NeighborManager.MakeNeighborsTable();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HomeView homeView = new HomeView();
            HomeViewPresenter homeViewPresenter = new HomeViewPresenter(homeView);
            Application.Run(homeView);
        }
    }
}
