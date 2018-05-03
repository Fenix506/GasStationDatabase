using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using GasStation.Models;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace GasStation.ViewModels
{
    class StatisticViewModel : Screen
    {
        private SeriesCollection _resultSeries;
        private SeriesCollection _resultSeries1;
        private DataTable _resultTable = new DataTable();
        private DataTable _resultTable1 = new DataTable();

        public StatisticViewModel()
        {
            DisplayName = "Статистика";
            CreateTable(GetListStatistic());
            RefreshResultChart();
            CreateTable1(GetListStatistic1());
            RefreshResultChart1();
        }

        public Func<double, string> Formatter2 { get; set; } = value =>  "Працівники";
        public Func<double, string> Formatter { get; set; } = value => (value) + "л";
        public Func<double, string> FormatterType { get; set; } = value => "Тип палива";


       


        public SeriesCollection ResultSeries
        {
            get { return _resultSeries; }
            set
            {
                _resultSeries = value;
                NotifyOfPropertyChange(() => ResultSeries);
            }
        }

        public SeriesCollection ResultSeries1
        {
            get { return _resultSeries1; }
            set
            {
                _resultSeries1 = value;
                NotifyOfPropertyChange(() => ResultSeries1);
            }
        }

        public DataTable ResultTable
        {
            get { return _resultTable; }
        }
        public DataTable ResultTable1
        {
            get { return _resultTable1; }
        }

        public class TmpJoinClass
        {
            public string Name;
            public double Count;
        }

        public List<TmpJoinClass> GetListStatistic1()
        {
            List<TmpJoinClass> rez;

            using (var db = new GasStationModel())
            {
                rez = db.Sell_Fuel.Join(db.Personal, s => s.Personal_Num, t => t.Personal_Num,
                    (s, t) => new
                    {
                        Name = t.Name,
                        Count = s.Count_Sell
                    }).GroupBy(x => x.Name).Select(g => new TmpJoinClass { Name = g.Key, Count = g.Sum(x => x.Count) }).ToList();
            }
            return rez;
        }

        public List<TmpJoinClass> GetListStatistic()
        {
            List<TmpJoinClass> rez;

            using (var db = new GasStationModel())
            {
                rez = db.Sell_Fuel.Join(db.Type_Fuel, s => s.Fuel_Id, t => t.Fuel_Id,
                    (s, t) => new
                    {
                        Name = t.Name_Fuel,
                        Count = s.Count_Sell
                    }).GroupBy(x => x.Name).Select(g => new TmpJoinClass { Name = g.Key, Count = g.Sum(x => x.Count) }).ToList();
            }
            return rez;
        }

        private void CreateTable(List<TmpJoinClass> rez)
        {

            _resultTable = new DataTable();
            _resultTable.Columns.Add("Тип палива", typeof(string));
            _resultTable.Columns.Add("Продано", typeof(double));

            for (int i = 0; i < rez.Count; i++)
            {
                var row = _resultTable.NewRow();
                row[0] = rez[i].Name;
                row[1] = rez[i].Count;
                _resultTable.Rows.Add(row);


            }

            NotifyOfPropertyChange(() => ResultTable);
        }

        private void CreateTable1(List<TmpJoinClass> rez)
        {

            _resultTable1 = new DataTable();
            _resultTable1.Columns.Add("Продавець", typeof(string));
            _resultTable1.Columns.Add("Продано", typeof(double));

            for (int i = 0; i < rez.Count; i++)
            {
                var row = _resultTable1.NewRow();
                row[0] = rez[i].Name;
                row[1] = rez[i].Count;
                _resultTable1.Rows.Add(row);


            }

            NotifyOfPropertyChange(() => ResultTable1);
        }

        private void RefreshResultChart()
        {


            _resultSeries = new SeriesCollection();

            for (int i = 0; i < _resultTable.Rows.Count; i++)
            {
                var val = new ChartValues<ObservableValue>();

                for (int j = 1; j < _resultTable.Columns.Count; j++)
                    val.Add(new ObservableValue(Math.Round((double)_resultTable.Rows[i][j], 2)));

                _resultSeries.Add(new ColumnSeries
                {
                    Values = val,
                    DataLabels = true,
                    Title = _resultTable.Rows[i][0].ToString()
                });
            }

            NotifyOfPropertyChange(() => ResultSeries);
        }

        private void RefreshResultChart1()
        {


            _resultSeries1 = new SeriesCollection();

            for (int i = 0; i < _resultTable1.Rows.Count; i++)
            {
                var val = new ChartValues<ObservableValue>();

                for (int j = 1; j < _resultTable1.Columns.Count; j++)
                    val.Add(new ObservableValue(Math.Round((double)_resultTable1.Rows[i][j], 2)));

                _resultSeries1.Add(new ColumnSeries
                {
                    Values = val,
                    DataLabels = true,
                    Title = _resultTable1.Rows[i][0].ToString()
                });
            }

            NotifyOfPropertyChange(() => ResultSeries1);
        }

        public void Update()
        {
            CreateTable(GetListStatistic());
            RefreshResultChart();
            CreateTable1(GetListStatistic1());
            RefreshResultChart1();
        }
    }
}
