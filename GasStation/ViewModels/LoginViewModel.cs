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
       
        private string _password;
        private string _personalNum;
        private string _connecting;

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
            if (Int32.TryParse(PersonalNum, out var id))
            {
                using (GasStationModel db = new GasStationModel())
                {
                  

                    if (db.Personal.Count(x => x.Personal_Num == id && x.Password == Password) == 1)
                    {
                        Connecting = "Вхід";
                        var personal = db.Personal.Single(x => x.Personal_Num == id && x.Password == Password);

                        SignIn?.Invoke(this, new PersonalEventArgs()
                        {
                            Personal = personal
                            
                        });
                    }
                    else
                    {
                        Connecting = "Така особа не зареєстрована";
                    }

                }
            }
           
           
        }
   

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


        public delegate void EventHendler(object sender, EventArgs args);

        public event EventHendler SignIn;

        public class PersonalEventArgs : EventArgs
        {
            public Personal Personal { get; set; }
        }
    }
}
