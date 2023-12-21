using PhotoStudio.DAL.Interfaces;
using PhotoStudio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.DAL.Repositories
{
    public class DbRepositories : IDbRepositories
    {
        private PhotoStudioContext db;

        private OrderRepository _orders;
        private UserRepository _users;
        private PersonRepository _persons;
        private PhotographerRepository _photographers;

        public DbRepositories()
        {
            db = new PhotoStudioContext();
        }

        public IRepositoryOrder Orders
        {
            get
            {
                if (_orders == null)
                    _orders = new OrderRepository(db);
                return _orders;
            }
        }

        public IRepository<Person> Persons
        {
            get
            {
                if (_persons == null)
                    _persons = new PersonRepository(db);
                return _persons;
            }
        }

        public IRepository<Photographer> Photographers
        {
            get
            {
                if (_photographers == null)
                    _photographers = new PhotographerRepository(db);
                return _photographers;
            }
        }

        public IRepositoryUser Users
        {
            get
            {
                if (_users == null)
                    _users = new UserRepository(db);
                return _users;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
