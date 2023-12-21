using PhotoStudio.DAL.Interfaces;
using PhotoStudio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.DAL.Repositories
{
    public class UserRepository : IRepositoryUser
    {
        private PhotoStudioContext db;

        public List<User> GetAll()
        {
            return db.Users.Select(i => i).ToList();
        }

        public User GetLoginUser(string username, string password)
        {
            return db.Users.Where(u => u.Username==username && u.Password==password).SingleOrDefault();
        }

        public bool CanRegister(string username, string email, string passport, string phonenumber)
        {
            var found = db.Users.FirstOrDefault(u =>
                (u.Username == username || u.Customer.Email == email || u.Customer.Passport == passport || u.Customer.PhoneNumber == phonenumber)
            );
            return found == null;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(User item)
        {
            db.Users.Remove(item);
        }

        public User GetById(int id)
        {
            return db.Users.FirstOrDefault(c => c.Id == id);
        }

        public void Update(User item)
        {
            var found = db.Users.Find(item.Id);
            if (found != null)
            {
                db.Entry(found).CurrentValues.SetValues(item);
            }
        }

        public UserRepository(PhotoStudioContext db)
        {
            this.db = db;
        }
    }
}
