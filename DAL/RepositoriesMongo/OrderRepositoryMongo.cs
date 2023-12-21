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
    public class OrderRepositoryMongo : IRepository<Order>
    {
        private PhotoStudioMongoContext db;

        public OrderRepositoryMongo(PhotoStudioMongoContext db)
        {
            this.db = db;
        }

        public void Create(Order item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order item)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            var builder = new FilterDefinitionBuilder<Order>();
            var filter = builder.Empty;
            return new List<Order>(db.OrderCollection.Find(filter).ToListAsync().Result);
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> Query(Func<Order, bool> f)
        {
            return GetAll();
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
