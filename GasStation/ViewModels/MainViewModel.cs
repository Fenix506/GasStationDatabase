using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using GasStation.Models;

namespace GasStation.ViewModels
{
    public class MainViewModel : Conductor<object> {

        public MainViewModel()
        {
            DisplayName = "";

            var Login = new LoginViewModel();
            var SellFuel = new SellFuelViewModel();

            Items.Add(Login);
            Items.Add(SellFuel);
         

            Select(Login);
        }

        public BindableCollection<IScreen> Items { get; protected set; } = new BindableCollection<IScreen>();

        public void Select(object datacontext)
        {
            if (datacontext is IScreen vm && Items.Contains(vm))
            {
                if (vm.IsActive)
                    return;
                ActivateItem(vm);
                vm.Refresh();
            }
            else
            {
                if (datacontext is Screen vm2)
                {
                    (vm2.Parent as IConductActiveItem)?.ActivateItem(vm2);
                    vm2.Refresh();
                }
            }
        }
    }
}
