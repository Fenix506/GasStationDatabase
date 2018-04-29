using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using GasStation.Models;

namespace GasStation.ViewModels
{
    class LoginViewModel: Screen
    {
        private Personal _personal;
        private string _password;
        private string _personalNum;

        public LoginViewModel()
        {
            DisplayName = "Login";
            
        }


        public bool CanLogIn
        {
             get { return !String.IsNullOrWhiteSpace(Password) && !String.IsNullOrWhiteSpace(PersonalNum); }

        }

        public void LogIn()
        {
            int id;
            if (Int32.TryParse(PersonalNum, out id))
            {
                using (GasStationModel db = new GasStationModel())
                {
                  

                    if (db.Personal.Count(x => x.Personal_Num == id && x.Password == Password) == 1)
                    {
                        Connecting = "Вхід";
                        _personal = db.Personal.Single(x => x.Personal_Num == id && x.Password == Password);
                      
                    }
                    else
                    {
                        Connecting = "Така особа не зареєстрована";
                    }

                }
            }
           
           
        }
        private string _connecting;

        public string Connecting
        {
            get { return _connecting; }
            set
            {
                _connecting = value;
                NotifyOfPropertyChange(() => Connecting);
            }
        }


        public string PersonalNum
        {
            get { return _personalNum; }
            set
            {
                _personalNum = value; 
                NotifyOfPropertyChange(() => PersonalNum);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value; 
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

       


    }
}
