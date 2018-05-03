using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using GasStation.Models;

namespace GasStation.ViewModels
{
    sealed class SellFuelViewModel : Screen
    {
        private int _relevantCashbox = 1;
        private Personal _personal;
        private Client _client;
        private List<Type_Fuel> _infoFuel;
        private string _clientInfo;
        private string _clientNum;
        private bool[] _column = new bool[4];
        private bool[] _type = new bool[6];
        private string _count = string.Empty;
        private string _money = string.Empty;
        private int _width = 200;
        private DataTable _information;


        public SellFuelViewModel(Personal personal)
        {
            DisplayName = "Продаж";
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
            if (_client != null) infoTable.Columns.Add("Ціна клієнту", typeof(float));


            for (int i = 0; i < _infoFuel.Count; i++)
            {
                var row = infoTable.NewRow();
                row[0] = _infoFuel[i].Name_Fuel;
                row[1] = _infoFuel[i].Price;
                row[2] = _infoFuel[i].Count_Fuel;
                if (_client != null) row[3] = _infoFuel[i].Price - _client.Personal_Discount;
                infoTable.Rows.Add(row);
            }
            Information = infoTable;
        }

        private bool IsDigitF(string str) => float.TryParse(str, out var tmp) && tmp > 0;

        private bool IsDigitI(string str) => int.TryParse(str, out var tmp);

        private float GetRelevantPrice()
        {
            for (int i = 0; i < _type.Length; i++)
            {
                if (_type[i])
                    return _client != null
                      ? (float)(_infoFuel[i].Price - _client.Personal_Discount)
                      : (float)_infoFuel[i].Price;
            }
            return 0;
        }

        private int GetNumberColumn()
        {
            for (int i = 0; i < _column.Length; i++)
            {
                if (_column[i]) return i + 1;
            }
            return 0;
        }

        private int GetTypeFuel()
        {
            for (int i = 0; i < _type.Length; i++)
            {
                if (_type[i]) return i + 1;
            }
            return 0;
        }

        private void Recalculate()
        {
            Count = Count;
            Money = Money;
        }

        private void ResetAll()
        {
            _client = null;
            ClientNum = string.Empty;
            ClientInfo = string.Empty;
            Column1 = false;
            Column2 = false;
            Column3 = false;
            Column4 = false;
            Type1 = false;
            Type2 = false;
            Type3 = false;
            Type4 = false;
            Type5 = false;
            Type6 = false;
            Count = string.Empty;
            Money = string.Empty;
            Width = 200;
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
                Recalculate();
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
                Recalculate();
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
                Recalculate();
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
                Recalculate();
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
                Recalculate();
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
                Recalculate();
                NotifyOfPropertyChange(() => Type6);
                NotifyOfPropertyChange(() => CanSell);
            }
        }

        public string Count
        {
            get => _count;
            set
            {


                if (IsDigitF(value))
                {
                    if (GetTypeFuel() != 0)
                        _count = float.Parse(value) > _infoFuel[GetTypeFuel() - 1].Count_Fuel
                            ? _infoFuel[GetTypeFuel() - 1].Count_Fuel.ToString()
                            : value;
                    else _count = value;
                    _money = Math.Round((float.Parse(_count) * GetRelevantPrice()), 2).ToString();
                }
                else
                {
                    _count = value;
                }

                NotifyOfPropertyChange(() => Count);
                NotifyOfPropertyChange(() => CanSell);
                NotifyOfPropertyChange(() => Money);
            }
        }

        public string Money
        {
            get => _money;
            set
            {

                if (IsDigitF(value))
                {
                    if (GetTypeFuel() != 0)
                    {
                        _money = float.Parse(value) / GetRelevantPrice() > _infoFuel[GetTypeFuel() - 1].Count_Fuel
                            ? Math.Round(_infoFuel[GetTypeFuel() - 1].Count_Fuel * GetRelevantPrice(), 2).ToString()
                            : value;
                        _count = Math.Round((double.IsPositiveInfinity((Convert.ToDouble(_money) / GetRelevantPrice()))
                            ? 0
                            : (Convert.ToDouble(_money) / GetRelevantPrice())), 2).ToString();
                    }
                    else _money = value;
                }
                else _money = value;
                NotifyOfPropertyChange(() => Money);
                NotifyOfPropertyChange(() => CanSell);
                NotifyOfPropertyChange(() => Count);
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
        }

        public int Width
        {
            get => _width;
            set
            {
                _width = value;
                NotifyOfPropertyChange(() => Width);
            }
        }


        #endregion

        #region Buttons

        public bool CanSearchClient => !string.IsNullOrWhiteSpace(ClientNum) && IsDigitI(ClientNum);

        public void SearchClient()
        {

            if (int.TryParse(ClientNum, out var identificator))
            {
                if (identificator == 0)
                {
                    ClientInfo = string.Empty;
                    _client = null;
                    CreateInformation();
                    Recalculate();
                    return;
                }
                using (var db = new GasStationModel())
                {
                    _client = db.Client.Find(identificator);
                }
            }

            if (_client != null)
            {
                ClientInfo =
                    $"{_client.Surname} {_client.Name} {_client.Middle_Name} \nПерсональна знижка: {_client.Personal_Discount} \nКуплено палива: {_client.Liters_Sold} \nКількість бонусів {_client.Bonus}";
                CreateInformation();
                Recalculate();
                Width = 270;
            }
            else
            {
                MessageBox.Show("Такий користувач не зареєстрований", "Дисконт", MessageBoxButton.OK);
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

                return check1 && check2 && !string.IsNullOrWhiteSpace(Count) && !string.IsNullOrWhiteSpace(Money) && IsDigitF(Count) && IsDigitF(Money) && float.Parse(Count) >= 1;
            }

        }

        public void Sell()
        {
            var clientNum = _client != null ? new SqlParameter("@Client_Num", _client.Client_Num) : null;

            var personalNum = new SqlParameter("@Personal_Num", _personal.Personal_Num);
            var numberColumn = new SqlParameter("@Number_Column", GetNumberColumn());
            if (!float.TryParse(Count, out var count)) return;
            var countSell = new SqlParameter("@Count_Sell", count);
            var fuelId = new SqlParameter("@Fuel_Id", GetTypeFuel());
            var cashbox = new SqlParameter("@Cashbox", _relevantCashbox);

            using (var db = new GasStationModel())
            {
                if (clientNum != null)
                    db.Database.ExecuteSqlCommand("Sell_Operation_Procedure @Personal_Num, @Number_Column, @Count_Sell, @Fuel_Id, @Cashbox, @Client_Num",
                        personalNum, numberColumn, countSell, fuelId, cashbox, clientNum);
                else
                    db.Database.ExecuteSqlCommand("Sell_Operation_Procedure @Personal_Num, @Number_Column, @Count_Sell, @Fuel_Id, @Cashbox",
                        personalNum, numberColumn, countSell, fuelId, cashbox);
            }

            ResetAll();
            CreateInformation();
        }

        public void Clear()
        {
            ResetAll();
            CreateInformation();
        }

        public void LogOut()
        {
            Out?.Invoke(this, null);
        }
        #endregion

        public delegate void EventHendler(object sender, EventArgs args);

        public event EventHendler Out;
    }
}
