using System.Windows;
using Caliburn.Micro;
using GasStation.ViewModels;

namespace GasStation
{
  public class Bootstrapper:BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
