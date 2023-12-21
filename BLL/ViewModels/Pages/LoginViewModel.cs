using PhotoStudio.BLL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhotoStudio.BLL.ViewModels.Pages
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username = string.Empty;
        private string _password = string.Empty;

        public string Username { get => _username; set { OnPropertyChanged("Username"); _username = value; } }
        public string Password { get => _password; set { OnPropertyChanged("Password"); _password = value; } }

        public ICommand SignInCommand { get; }
        public ICommand SignUpCommand { get; }

        public LoginViewModel(MainViewModel p)
        {
            SignInCommand = new ViewModelCommand(
            o => {
                p.TryLogInAs(Username, Password);
            }, o => (_username.Length > 2) && (_password.Length > 3) );

            SignUpCommand = new ViewModelCommand(
            o => {
                p.CurrentViewModel = new RegisterViewModel(p);
            });
        }
    }
}
