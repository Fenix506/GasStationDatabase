using System;
using System.Linq;
using System.Text.RegularExpressions;
using Caliburn.Micro;
using GasStation.Models;

namespace GasStation.ViewModels
{
    sealed class RegistrationClientViewModel:Screen
    {
        private string _name;
        private string _surname;
        private string _middleName;

        public RegistrationClientViewModel()
        {
            DisplayName = "Реєстрація користувача";

        }

        #region Methods

        public bool HasDigit(string str)
        {
            if (str == null) return true;
            var r = new Regex(@"[^\w|\ ]|\d");
            var m = r.Match(str);

            if (m.Success)
                return false;

            return true;

        }

        #endregion

        #region Property

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
                NotifyOfPropertyChange(() => CanRegistration);
            }
        }



        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                NotifyOfPropertyChange(() => Surname);
                NotifyOfPropertyChange(() => CanRegistration);
            }
        }


        public string MiddleName
        {
            get => _middleName;
            set
            {
                _middleName = value;
                NotifyOfPropertyChange(() => MiddleName);
                NotifyOfPropertyChange(() => CanRegistration);
            }
        }

        #endregion

        #region Buttons


        public bool CanRegistration
        {
            get => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Surname) && HasDigit(Name) && HasDigit(Surname) && HasDigit(MiddleName);
        }

        public void Registration()
        {
            using (var db = new GasStationModel())
            {
                if (db.Client.Count(x => x.Name == Name && x.Surname == Surname) < 1)
                {
                    db.Client.Add(new Client()
                    {
                        Name = Name,
                        Surname = Surname,
                        Middle_Name = MiddleName,
                        Bonus = 0,
                        Liters_Sold = 0,
                        Personal_Discount = 0,
                        Date_Registration = DateTime.Now
                    });
                    db.SaveChanges();
                }
            }
        }
        #endregion


    }
}
