using MongoDB.Driver;
using PhotoStudio.DAL.Interfaces;
using PhotoStudio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.DAL.RepositoriesMongo
{
    public class UserRepositoryMongo : IRepositoryUser
    {
        private PhotoStudioMongoContext db;

        public UserRepositoryMongo(PhotoStudioMongoContext db)
        {
            this.db = db;
        }

        public bool CanRegister(string username, string email, string passport, string phonenumber)
        {
            throw new NotImplementedException();
        }

        public void Create(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(User item)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            var builder = new FilterDefinitionBuilder<User>();
            var filter = builder.Empty;
            return new List<User>(db.UserCollection.Find(filter).ToListAsync().Result);
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetLoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
