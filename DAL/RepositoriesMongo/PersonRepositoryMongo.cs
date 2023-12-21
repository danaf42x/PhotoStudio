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
    public class PersonRepositoryMongo : IRepository<Person>
    {
        private PhotoStudioMongoContext db;

        public PersonRepositoryMongo(PhotoStudioMongoContext db)
        {
            this.db = db;
        }

        public void Create(Person item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Person item)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            var builder = new FilterDefinitionBuilder<Person>();
            var filter = builder.Empty;
            return new List<Person>(db.PersonCollection.Find(filter).ToListAsync().Result);
        }

        public Person GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> Query(Func<Person, bool> f)
        {
            throw new NotImplementedException();
        }

        public void Update(Person item)
        {
            throw new NotImplementedException();
        }
    }
}
