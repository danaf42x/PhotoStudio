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
    public class PhotographerRepositoryMongo : IRepository<Photographer>
    {
        private PhotoStudioMongoContext db;

        public PhotographerRepositoryMongo(PhotoStudioMongoContext db)
        {
            this.db = db;
        }

        public void Create(Photographer item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Photographer item)
        {
            throw new NotImplementedException();
        }

        public List<Photographer> GetAll()
        {
            var builder = new FilterDefinitionBuilder<Photographer>();
            var filter = builder.Empty;
            return new List<Photographer>(db.PhotographerCollection.Find(filter).ToListAsync().Result);
        }

        public Photographer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Photographer> Query(Func<Photographer, bool> f)
        {
            throw new NotImplementedException();
        }

        public void Update(Photographer item)
        {
            throw new NotImplementedException();
        }
    }
}
