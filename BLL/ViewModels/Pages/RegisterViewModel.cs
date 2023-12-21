using PhotoStudio.BLL.Base;
using PhotoStudio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhotoStudio.BLL.ViewModels.Pages
{
    public class RegisterViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private string _email;
        private string _phone;
        private string _passport;
        private string _name;
        private string _surname;
        private string _patronym;

        public string Username { get => _username; set { OnPropertyChanged("Username"); _username = value; } }
        public string Password { get => _password; set { OnPropertyChanged("Password"); _password = value; } }
        public string Email { get => _email; set { OnPropertyChanged("Email"); _email = value; } }
        public string Phone { get => _phone; set { OnPropertyChanged("Phone"); _phone = value; } }
        public string Passport { get => _passport; set { OnPropertyChanged("Passport"); _passport = value; } }
        public string Name { get => _name; set { OnPropertyChanged("Name"); _name = value; } }
        public string Surname { get => _surname; set { OnPropertyChanged("Surname"); _surname = value; } }
        public string Patronym { get => _patronym; set { OnPropertyChanged("Patronym"); _patronym = value; } }

        public ICommand SignUpCommand { get; }
        public ICommand CancelCommand { get; }

        public RegisterViewModel(MainViewModel p)
        {
            CancelCommand = new ViewModelCommand(
            o => {
                p.CurrentViewModel = new LoginViewModel(p);
            });

            SignUpCommand = new ViewModelCommand(
            o => {
                if (p.db.Users.CanRegister(Username, Email, Passport, Phone))
                {
                    User nu = new User();
                    nu.Username = Username;
                    nu.Password = Password;

                    nu.Customer = new Person();
                    nu.Customer.PhoneNumber = Phone;
                    nu.Customer.Email = Email;
                    nu.Customer.PhoneNumber = Phone;
                    nu.Customer.Passport = Passport;
                    nu.Customer.Name = Name;
                    nu.Customer.Surname = Surname;
                    nu.Customer.Patronym = Patronym;

                    p.db.Users.Create(nu);
                    p.db.Persons.Create(nu.Customer);

                    p.db.Save();
                    p.CurrentViewModel = new LoginViewModel(p);
                }
            }, o => true);
        }
    }
}
