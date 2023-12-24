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
            "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
        });
        public string MonthSelected { get; set; }

        public Photographer PhotographerSelected { get; set; }

        public ICommand SignOutCommand { get; }
        public ICommand StatisticsCommand { get; }
        public ICommand SaveCommand { get; }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }

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

            SaveCommand = new ViewModelCommand(
            o => {
                p.db.Save();
            });

            AddCommand = new ViewModelCommand(
            o => {
                var arg = (string)o;
                if (arg == "photographer")
                {
                    var ph = new Photographer();
                    ListPhotographers.Add(ph);
                    p.db.Photographers.Create(ph);
                }
            });

            RemoveCommand = new ViewModelCommand(
            o => {
                var arg = (string)o;
                if (arg == "photographer")
                {
                    p.db.Photographers.Delete(PhotographerSelected);
                    ListPhotographers.Remove(PhotographerSelected);
                }
            }, o => {
                var arg = (string)o;
                if (arg == "photographer")
                {
                    return PhotographerSelected != null;
                }
                return false;
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
                    using (StreamWriter of = new StreamWriter(Path.Combine(docPath, "PhotoStudioStatistic_" + Months[mIndex] + ".csv"), false, Encoding.GetEncoding(1251)))
                    {
                        /*of.WriteLine("=== " + Months[mIndex] + " PhotoStudio Report ===");
                        of.WriteLine(" * Total Revenue\t\t" + st.totalmade.ToString("N0"));
                        of.WriteLine(" * Orders Taken\t\t" + (st.successful + st.failed).ToString("N0"));
                        of.WriteLine(" \t | Completed:\t" + (st.successful).ToString("N0"));
                        of.WriteLine(" \t | Failed:\t" + (st.failed).ToString("N0"));
                        of.WriteLine("\n--- Photographer statistics --- ");

                        foreach (Photographer ph in st.totalmade_photographers.Keys)
                        {
                            of.WriteLine(ph.Surname + " " + ph.Name + " " + ph.Patronym);
                            of.WriteLine("| Earned: " + st.totalmade_photographers[ph].ToString("N0") + " from " + st.successful_photographers[ph].ToString("N0") + " orders;");
                        }*/

                        of.WriteLine("-, Полная выручка, , Заказов принято, Успешных, Возвращённых");
                        of.WriteLine("Всего" + ", " + st.totalmade + ", ," + (st.successful + st.failed) + ", " + st.successful + ", " + st.failed);
                        of.WriteLine(",");
                        foreach (Photographer ph in st.totalmade_photographers.Keys)
                        {
                            of.WriteLine(ph.Surname + " " + ph.Name + " " + ph.Patronym + ", " + st.totalmade_photographers[ph] + ", "
                                + ", " + (st.successful_photographers[ph] + st.failed_photographers[ph])
                                + ", " + st.successful_photographers[ph]
                                + ", " + st.failed_photographers[ph]
                            );
                        }
                    }
                }
            }, o => MonthSelected!=null && MonthSelected.Length>0);
        }
    }
}
