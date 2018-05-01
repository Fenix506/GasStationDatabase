
using Caliburn.Micro;


namespace GasStation.ViewModels
{
    public sealed class MainViewModel : Conductor<object> {

        public MainViewModel()
        {
            DisplayName = "";

            var login = new LoginViewModel();
            var statistic = new StatisticViewModel();
          
            login.SignIn += (sender, args) =>
            {
                Items.Remove(login);
                var personal = (args as LoginViewModel.PersonalEventArgs)?.Personal;
                var sellFuel = new SellFuelViewModel(personal);
                var registration = new RegistrationClientViewModel();
                var income = new IncomeFuelViewModel();
                var addworker = new AddWorkerViewModel();
                Items.Add(sellFuel);
                Items.Add(income);
                Items.Add(registration);
                Items.Add(addworker);
                Select(sellFuel);
            };
       
            Items.Add(login);
           Items.Add(statistic);
         

            Select(statistic);
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
