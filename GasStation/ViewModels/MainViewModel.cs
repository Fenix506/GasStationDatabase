
using System;
using Caliburn.Micro;
using GasStation.Models;


namespace GasStation.ViewModels
{
    public sealed class MainViewModel : Conductor<object>
    {

        public MainViewModel()
        {
            DisplayName = "";

            var login = new LoginViewModel();
           


            login.SignIn += (sender, args) =>
            {
                
                var personal = (args as LoginViewModel.PersonalEventArgs)?.Personal;

                var sellFuel = new SellFuelViewModel(personal);
                var registration = new RegistrationClientViewModel();
                var income = new IncomeFuelViewModel();
                var addworker = new AddWorkerViewModel();
                var statistic = new StatisticViewModel();

                switch (personal.Position_Id)
                 {
                    case 1:
                         Items.Add(sellFuel);
                        break;
                    case 2:
                        Items.Add(sellFuel);
                        Items.Add(income);
                        Items.Add(registration);
                        break;
                    case 3:
                        Items.Add(sellFuel);
                        Items.Add(income);
                        Items.Add(registration);
                        Items.Add(addworker);
                        Items.Add(statistic);
                        break;


                }
                Select(sellFuel);
                Items.Remove(login);

                sellFuel.Out += (sender1, args1) =>
                {
                    Items.Clear();
                    Items.Add(login);
                    Select(login);
                    login.Password = string.Empty;
                    login.PersonalNum = string.Empty;
                    login.Connecting = string.Empty;
                };
            };

      
            Items.Add(login);
            Select(login);
        }

        public BindableCollection<IScreen> Items { get; } = new BindableCollection<IScreen>();

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
