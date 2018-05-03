using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.Windows;
using Caliburn.Micro;
using GasStation.Models;

namespace GasStation.ViewModels
{
    sealed class IncomeFuelViewModel : Screen
    {
        private bool[] _type = new bool[6];
        private string _count;

        public IncomeFuelViewModel()
        {
            DisplayName = "Привіз";
        }

        #region Methods

        private int GetTypeFuel()
        {
            for (int i = 0; i < _type.Length; i++)
            {
                if (_type[i]) return i + 1;
            }
            return 0;
        }

        private bool IsDigitF(string str) => float.TryParse(str, out var tmp) && tmp > 0;

        private void ResetAll()
        {
            Type1 = false;
            Type2 = false;
            Type3 = false;
            Type4 = false;
            Type5 = false;
            Type6 = false;
            Count = string.Empty;
        }

        #endregion

        #region Property

        public string Count
        {
            get => _count;
            set
            {
                _count = value;
                NotifyOfPropertyChange(Count);
                NotifyOfPropertyChange(() => CanIncome);
            }
        }

        public bool Type1
        {
            get => _type[0];
            set
            {
                if (value.Equals(_type[0])) return;
                _type[0] = value;

                NotifyOfPropertyChange(() => Type1);
                NotifyOfPropertyChange(() => CanIncome);
            }
        }

        public bool Type2
        {
            get => _type[1];
            set
            {
                if (value.Equals(_type[1])) return;
                _type[1] = value;

                NotifyOfPropertyChange(() => Type2);
                NotifyOfPropertyChange(() => CanIncome);
            }
        }

        public bool Type3
        {
            get => _type[2];
            set
            {
                if (value.Equals(_type[2])) return;
                _type[2] = value;

                NotifyOfPropertyChange(() => Type3);
                NotifyOfPropertyChange(() => CanIncome);
            }
        }

        public bool Type4
        {
            get => _type[3];
            set
            {
                if (value.Equals(_type[3])) return;
                _type[3] = value;

                NotifyOfPropertyChange(() => Type4);
                NotifyOfPropertyChange(() => CanIncome);
            }
        }

        public bool Type5
        {
            get => _type[4];
            set
            {
                if (value.Equals(_type[4])) return;
                _type[4] = value;

                NotifyOfPropertyChange(() => Type5);
                NotifyOfPropertyChange(() => CanIncome);
            }
        }

        public bool Type6
        {
            get => _type[5];
            set
            {
                if (value.Equals(_type[5])) return;
                _type[5] = value;

                NotifyOfPropertyChange(() => Type6);
                NotifyOfPropertyChange(() => CanIncome);
            }
        }

        #endregion


        #region Buttons

        public bool CanIncome
        {
            get
            {
                var check = false;

                foreach (var type in _type)
                {
                    if (type) check = true;
                }

                return check && !string.IsNullOrWhiteSpace(Count) && IsDigitF(Count);
            }
        }

        public void Income()
        {
            using (var db = new GasStationModel())
            {
                db.Income_Fuel.Add(new Income_Fuel()
                {
                    Count_Income = float.Parse(Count),
                    Date_Income = DateTime.Now,
                    Fuel_Id = GetTypeFuel()
                });

                db.Type_Fuel.Find(GetTypeFuel()).Count_Fuel += float.Parse(Count);

                db.SaveChanges();
            }
            MessageBox.Show($"Добавлено палива: {Count}", "Прихід палива", MessageBoxButton.OK);
            ResetAll();
        }

        #endregion



    }

}
