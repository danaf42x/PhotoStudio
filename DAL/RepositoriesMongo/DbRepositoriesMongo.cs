using PhotoStudio.DAL.Interfaces;
using PhotoStudio.DAL.Models;
using PhotoStudio.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.DAL.RepositoriesMongo
{
    public class DbRepositoriesMongo : IDbRepositories
    {
        private PhotoStudioMongoContext db;

        private OrderRepositoryMongo repositoryOrders;
        private PersonRepositoryMongo repositoryPersons;
        private PhotographerRepositoryMongo repositoryPhotographers;
        private UserRepositoryMongo repositoryUsers;

        public DbRepositoriesMongo()
        {
            db = new PhotoStudioMongoContext("MongoDBCS");
            
            repositoryOrders = new OrderRepositoryMongo(db);
            repositoryPersons = new PersonRepositoryMongo(db);
            repositoryPhotographers = new PhotographerRepositoryMongo(db);
            repositoryUsers = new UserRepositoryMongo(db);
        }

        public IRepository<Order> Orders => repositoryOrders;

        public IRepository<Person> Persons => repositoryPersons;

        public IRepository<Photographer> Photographers => repositoryPhotographers;

        public IRepositoryUser Users => repositoryUsers;

        public int Save()
        {
            return 1;
        }
    }
}
