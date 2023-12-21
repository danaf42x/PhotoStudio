using PhotoStudio.BLL.Base;
using PhotoStudio.DAL.Interfaces;
using PhotoStudio.DAL.Models;
using PhotoStudio.DAL.Other;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhotoStudio.BLL.ViewModels.Pages.Sub
{
    public class OrderViewModel : BaseViewModel
    {
        IDbRepositories db;

        public DateTime DisplayDateStart { get; set; }
        public DateTime DisplayDateEnd { get; set; }

        private DateTime _dateselected = DateTime.Today;
        public DateTime DateSelected
        {
            get
            {
                return _dateselected;
            }
            set
            {
                _dateselected = value;
                OnPropertyChanged("DateSelected");
                RecalcTimes();
            }
        }

        public ICommand DateSelectedCommand { get; }
        public ICommand HourCommand { get; }
        public ICommand HireCommand { get; }

        public ObservableCollection<ScheduleHour> Times { get; }
        private List<Photographer> available;
        private Dictionary<Photographer, bool[]> calced;
        public ObservableCollection<Photographer> ListHour { get; }
        private int selectedhour;
        public Photographer SelectedPhotographer { get; set;  }

        public OrderViewModel(MainViewModel p, User user, BaseViewModel pp)
        {
            db = p.db;
            available = db.Photographers.GetAll();
            ListHour = new ObservableCollection<Photographer>();

            DisplayDateStart = DateTime.Today;
            DisplayDateEnd = DateTime.Today.AddDays(14);

            Times = new ObservableCollection<ScheduleHour>();
            for (int i = 0; i < 24; i++)
                Times.Add(new ScheduleHour() { IsAvailable = false, Hour = i } );

            HourCommand = new ViewModelCommand(o =>
            {
                int hour = ((ScheduleHour)o).Hour;
                selectedhour = hour;
                ListHour.Clear();
                foreach (var ph in calced.Keys)
                {
                    if (calced[ph][hour])
                    {
                        ListHour.Add(ph);
                    }
                }
            });

            HireCommand = new ViewModelCommand(o =>
            {
                var tday = DateSelected;
                DateTime start = tday.AddHours(-tday.Hour).AddHours(selectedhour).AddMinutes(-tday.Minute).AddSeconds(-tday.Minute);
                var ord = new Order()
                {
                    Customer = p.LoggedInAs.Customer,
                    Start = start,
                    End = start.AddHours(1),
                    Photographer = SelectedPhotographer,
                    Paid = 350
                };
                db.Orders.Create(ord);
                db.Save();
                ((HomeViewModel)pp).SubViewModel = new ProfileViewModel(p, user, pp);
            });

            RecalcTimes();
        }

        public void RecalcTimes()
        {
            var ch = DateTime.Now.Hour;

            var orders = db.Orders.Query(o =>
            {
                return DateTime.Compare(o.End, DateTime.Now)>0;
            });

            var dic = new Dictionary<Photographer, bool[]>();

            foreach (var ph in available)
            {
                dic[ph] = new bool[24];
                for (int i = 0; i < 24; i++)
                {
                    dic[ph][i] = (i>=ph.DayStartHour && i<=ph.DayEndHour) && i>ch;
                }
            }

            for (int i = 0; i < 24; i++)
            {
                foreach (var o in orders)
                {
                    if (DateTime.Now.DayOfYear < o.End.DayOfYear || ch <= o.End.Hour)
                    {
                        dic[o.Photographer][i] = false;
                    }
                }
            }

            for (int i = 0; i<24; i++)
            {
                Times[i].IsAvailable = false;
                foreach (var ph in dic.Keys)
                {
                    if (dic[ph][i] == true)
                    {
                        Times[i].IsAvailable = true;
                        break;
                    }
                }
            }

            calced = dic;
        }
    }
}
