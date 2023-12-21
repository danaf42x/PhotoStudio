using PhotoStudio.BLL.Base;
using PhotoStudio.BLL.ViewModels.Pages.Sub;
using PhotoStudio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhotoStudio.BLL.ViewModels.Pages
{
    public class HomeViewModel : BaseViewModel
    {
        private BaseViewModel _subViewModel;
        public BaseViewModel SubViewModel
        {
            get
            {
                return _subViewModel;
            }
            set
            {
                _subViewModel = value;
                OnPropertyChanged();
            }
        }

        public User User { get; set; }

        public ICommand SignOutCommand { get; }
        public ICommand SwitchSubCommand { get; }

        public HomeViewModel(MainViewModel p)
        {
            User = p.LoggedInAs;
            SubViewModel = new InfoViewModel(p, User, this);

            SwitchSubCommand = new ViewModelCommand(o =>
            {
                string arg = (string)o;
                switch (arg)
                {
                    case "info":
                        SubViewModel = new InfoViewModel(p, User, this);
                        break;
                    case "order":
                        SubViewModel = new OrderViewModel(p, User, this);
                        break;
                    case "photographers":
                        SubViewModel = new PhotographersViewModel(p, User, this);
                        break;
                    case "profile":
                        SubViewModel = new ProfileViewModel(p, User, this);
                        break;
                }
            });

            SignOutCommand = new ViewModelCommand(o =>
            {
                User = null;
                p.LogOut();
                p.CurrentViewModel = new LoginViewModel(p);
            });
        }
    }
}
