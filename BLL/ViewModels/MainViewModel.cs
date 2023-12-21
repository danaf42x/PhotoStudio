using Ninject;
using PhotoStudio.BLL.Base;
using PhotoStudio.BLL.ViewModels.Pages;
using PhotoStudio.DAL.Interfaces;
using PhotoStudio.DAL.Models;
using PhotoStudio.Ninject;
using System;

namespace PhotoStudio.BLL.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        StandardKernel kernel;
        public IDbRepositories db;

        private User _loggedInAs;
        public User LoggedInAs { get => _loggedInAs; }

        private User admin;

        public MainViewModel() {
            kernel = new StandardKernel(new NinjectRegistrations(), new RepositoriesModule("PhotoStudioCS"));
            //kernel = new StandardKernel(new NinjectRegistrations(), new RepositoriesModule("MongoDBCS"));
            db = kernel.Get<IDbRepositories>();

            admin = new User();
            admin.Username = "admin";
            admin.Password = "admin";
            admin.IsAdmin = true;
            CurrentViewModel = new LoginViewModel(this);
        }

        public bool IsAdminCredintals(string username, string password)
        {
            return username == admin.Username && password == admin.Password;
        }

        public void TryLogInAs(string username, string password)
        {
            if (IsAdminCredintals(username, password))
            {
                _loggedInAs = admin;
                this.CurrentViewModel = new AdminViewModel(this);
            }
            else
            {
                User logged_in = db.Users.GetLoginUser(username, password);
                if (logged_in != null)
                {
                    this.CurrentViewModel = new HomeViewModel(this);
                }
            }
        }

        public void LogOut()
        {
            _loggedInAs = null;
        }
    }
}
