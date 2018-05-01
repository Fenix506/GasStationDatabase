using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;
using GasStation.Models;

namespace GasStation.ViewModels
{
    class AddWorkerViewModel:Screen
    {
        private string _name;
        private string _surname;
        private string _middleName;
        private string _password;
        private bool _trainee;
        private bool _operator;

        public AddWorkerViewModel()
        {
            DisplayName = "Додати працівника";
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

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanRegistration);
            }
        }

        public bool Operator
        {
            get => _operator;
            set
            {
                if (value.Equals(_operator)) return;
                _operator = value;
               
                NotifyOfPropertyChange(() => Operator);
                NotifyOfPropertyChange(() => CanRegistration);
            }
        }

        public bool Trainee
        {
            get => _trainee;
            set
            {
                if (value.Equals(_trainee)) return;
                _trainee = value;

                NotifyOfPropertyChange(() => Trainee);
                NotifyOfPropertyChange(() => CanRegistration);
            }
        }
        #endregion

        #region Buttons


        public bool CanRegistration
        {
            get => !string.IsNullOrWhiteSpace(Name) && 
                !string.IsNullOrWhiteSpace(Surname) && 
                !string.IsNullOrWhiteSpace(MiddleName) && 
                !string.IsNullOrWhiteSpace(Password) && 
                HasDigit(Name) && 
                HasDigit(Surname) && 
                HasDigit(MiddleName) &&
                (Trainee || Operator);
        }

        public void Registration()
        {
            using (var db = new GasStationModel())
            {
                if (db.Personal.Count(x => x.Name == Name && x.Surname == Surname) < 1)
                {
                    int Pos_id = 0;
                    if (Trainee) Pos_id = 1;
                    if (Operator) Pos_id = 2;
                    db.Personal.Add(new Personal()
                    {
                        Name = Name,
                        Surname = Surname,
                        Middle_Name = MiddleName,
                        Password = Password,
                        Position_Id = Pos_id
 
                    });
                    db.SaveChanges();
                }
            }
        }
        #endregion
    }
}
