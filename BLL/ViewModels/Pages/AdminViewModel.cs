using PhotoStudio.BLL.Base;
using PhotoStudio.DAL.Models;
using PhotoStudio.DAL.Other;
using PhotoStudio.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhotoStudio.BLL.ViewModels.Pages
{
    public class AdminViewModel : BaseViewModel
    {
        public ObservableCollection<Order> ListOrdersActive { get; set; }
        public ObservableCollection<Order> ListOrdersExpired { get; set; }
        public ObservableCollection<Person> ListPersons { get; set; }
        public ObservableCollection<Photographer> ListPhotographers { get; set; }
        public ObservableCollection<User> ListUsers { get; set; }

        public ObservableCollection<string> Months { get; set; } = new ObservableCollection<string>(new List<string>()
        {
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
        });
        public string MonthSelected { get; set; }

        public ICommand SignOutCommand { get; }
        public ICommand StatisticsCommand { get; }

        public AdminViewModel(MainViewModel p)
        {
            DateTime now = DateTime.Now;
            ListOrdersActive = new ObservableCollection<Order>(p.db.Orders.Query(c => DateTime.Compare(c.End, now)>0));
            ListOrdersExpired = new ObservableCollection<Order>(p.db.Orders.Query(c => DateTime.Compare(c.End, now) <= 0));
            ListPersons = new ObservableCollection<Person>(p.db.Persons.GetAll());
            ListPhotographers = new ObservableCollection<Photographer>(p.db.Photographers.GetAll());
            ListUsers = new ObservableCollection<User>(p.db.Users.GetAll());

            SignOutCommand = new ViewModelCommand(
            o => {
                p.CurrentViewModel = new LoginViewModel(p);
                p.LogOut();
            });

            StatisticsCommand = new ViewModelCommand(
            o => {
                int mIndex = -1;
                for (int i=0; i<Months.Count; i++)
                    if (Months[i] == MonthSelected) { mIndex = i; break; }

                if (mIndex >= 0)
                {
                    Statistic st = ((OrderRepository)p.db.Orders).GetMonthStatistics(mIndex);
                    string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    using (StreamWriter of = new StreamWriter(Path.Combine(docPath, "PhotoStudioStatistic_"+Months[mIndex]+".txt")))
                    {
                        of.WriteLine("=== " + Months[mIndex] + " PhotoStudio Report ===");
                        of.WriteLine(" * Total Revenue\t\t" + st.totalmade.ToString("N0"));
                        of.WriteLine(" * Orders Taken\t\t" + (st.successful + st.failed).ToString("N0"));
                        of.WriteLine(" \t | Completed:\t" + (st.successful).ToString("N0"));
                        of.WriteLine(" \t | Failed:\t" + (st.failed).ToString("N0"));
                        of.WriteLine("\n--- Photographer statistics --- ");
                    }
                }
            }, o => MonthSelected.Length>0);
        }
    }
}
