using PhotoStudio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.DAL.Interfaces
{
    public interface IRepositoryUser
    {
        List<User> GetAll();
        User GetById(int id);
        User GetLoginUser(string username, string password);
        bool CanRegister(string username, string email, string passport, string phonenumber);
        void Create(User item);
        void Update(User item);
        void Delete(User item);
    }
}