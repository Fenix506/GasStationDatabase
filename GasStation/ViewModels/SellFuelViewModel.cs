using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using GasStation.Models;

namespace GasStation.ViewModels
{
    sealed class SellFuelViewModel : Screen
    {

        private Personal _personal;
        private Client _client = null;
        private List<Type_Fuel> _infoFuel;
        private string _clientInfo;
        private string _clientNum;
        private bool[] _column = new bool[4];
        private bool[] _type = new bool[6];
        private string _count;
        private string _money;
        private DataTable _information;


        public SellFuelViewModel(Personal personal)
        {
            DisplayName = "Sell Fuell";
            _personal = personal;

            CreateInformation();
        }

        #region Methods

      

        private void CreateInformation()
        {
            using (GasStationModel db = new GasStationModel())
            {
                _infoFuel = db.Type_Fuel.ToList();
            }

            var infoTable = new DataTable();
            infoTable.Columns.Add("Назва", typeof(string));
            infoTable.Columns.Add("Ціна грн\\л", typeof(float));
            infoTable.Columns.Add("Запаси", typeof(float));
            if(_client != null)infoTable.Columns.Add("Ціна клієнта", typeof(float));


            for (int i = 0; i < _infoFuel.Count; i++)
            {
                var row = infoTable.NewRow();
                row[0] = _infoFuel[i].Name_Fuel;
                row[1] = _infoFuel[i].Price;
                row[2] = _infoFuel[i].Count_Fuel;
                if (_client != null) row[3] = _infoFuel[i].Price-_client.Personal_Discount;
                infoTable.Rows.Add(row);
            }
            Information = infoTable;
        }

        private bool IsDigitF(string str)
        {
            return float.TryParse(str, out var tmp);
        }

        private bool IsDigitI(string str)
        {
            return Int32.TryParse(str, out var tmp);
        }

        #endregion

        #region Property

        public string PersonalInfo
        {
            get => String.Format("За касовим апаратом {0}: {1} {2} {3}.", _personal.Work_Position.Position_Work, _personal.Surname, _personal.Name, _personal.Middle_Name);
        }

        public string ClientNum
        {
            get => _clientNum;
            set
            {
                _clientNum = value;
                NotifyOfPropertyChange(() => ClientNum);
                NotifyOfPropertyChange(() => CanSearchClient);
            }
        }

        public string ClientInfo
        {
            get => _clientInfo;
            set
            {
                _clientInfo = value;
                NotifyOfPropertyChange(() => ClientInfo);
            }
        }

        public bool Column1
        {
            get => _column[0];
            set
            {
                if (value.Equals(_column[0])) return;
                _column[0] = value;
                NotifyOfPropertyChange(() => Column1);
                NotifyOfPropertyChange(() => CanSell);
            }
        }

        public bool Column2
        {
            get => _column[1];
            set
            {
                if (value.Equals(_column[1])) return;
                _column[1] = value;
                NotifyOfPropertyChange(() => Column2);
                NotifyOfPropertyChange(() => CanSell);
            }
        }

        public bool Column3
        {
            get => _column[2];
            set
            {
                if (value.Equals(_column[2])) return;
                _column[2] = value;
                NotifyOfPropertyChange(() => Column3);
                NotifyOfPropertyChange(() => CanSell);
            }
        }

        public bool Column4
        {
            get => _column[3];
            set
            {
                if (value.Equals(_column[3])) return;
                _column[3] = value;
                NotifyOfPropertyChange(() => Column4);
                NotifyOfPropertyChange(() => CanSell);
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
                NotifyOfPropertyChange(() => CanSell);
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
                NotifyOfPropertyChange(() => CanSell);
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
                NotifyOfPropertyChange(() => CanSell);
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
                NotifyOfPropertyChange(() => CanSell);
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
                NotifyOfPropertyChange(() => CanSell);
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
                NotifyOfPropertyChange(() => CanSell);
            }
        }

        public string Count
        {
            get => _count;
            set
            {
                _count = value;
                NotifyOfPropertyChange(() => Count);
                NotifyOfPropertyChange(() => CanSell);
            }
        }

        public string Money
        {
            get => _money;
            set
            {
                _money = value;
                NotifyOfPropertyChange(() => Money);
                NotifyOfPropertyChange(() => CanSell);
            }
        }

        public DataTable Information
        {
            get => _information;
            set
            {
                _information = value;
                NotifyOfPropertyChange(() => Information);
            }
            //get
            //{
            //    string inform = "";
            //    foreach (var info in _infoFuel)
            //    {
            //        inform += String.Format("{0}: {1}грн. Запаси:{2}\n",info.Name_Fuel,info.Price,info.Count_Fuel);
            //    }
            //    return inform;
            //}
        }

        #endregion

        #region Buttons

        public bool CanSearchClient
        {
            get => !String.IsNullOrWhiteSpace(ClientNum);
        }

        public void SearchClient()
        {
            if (Int32.TryParse(ClientNum, out var identificator))
            {
                using (GasStationModel db = new GasStationModel())
                {
                    _client = db.Client.Find(identificator);
                }
            }

            if (_client != null)
            {
                ClientInfo = String.Format("{0} {1} {2} \nПерсональна знижка: {3} \nКуплено палива: {4} \nКількість бонусів {5}", _client.Surname, _client.Name, _client.Middle_Name, _client.Personal_Discount, _client.Liters_Sold, _client.Bonus);
                CreateInformation();
            }
        }

        public bool CanSell
        {
            get
            {
                bool check1 = false, check2 = false;
                foreach (var col in _column)
                {
                    if (col) check1 = true;
                }
                foreach (var type in _type)
                {
                    if (type) check2 = true;
                }

                return check1 && check2 && !String.IsNullOrWhiteSpace(Count) && !String.IsNullOrWhiteSpace(Money) && IsDigitF(Count) && IsDigitF(Money);
            }

        }

        public void Sell()
        {
            
        }
        #endregion

    }
}
