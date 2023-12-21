using PhotoStudio.DAL.Interfaces;
using PhotoStudio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.DAL.Repositories
{
    public class PhotographerRepository : IRepository<Photographer>
    {
        private PhotoStudioContext db;

        public List<Photographer> GetAll()
        {
            return db.Photographers.Select(i => i).ToList();
        }

        public List<Photographer> Query(Func<Photographer, bool> f)
        {
            return db.Photographers.Where(f).ToList();
        }

        public void Create(Photographer item)
        {
            db.Photographers.Add(item);
        }

        public void Delete(Photographer item)
        {
            db.Photographers.Remove(item);
        }

        public Photographer GetById(int id)
        {
            return db.Photographers.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Photographer item)
        {
            var found = db.Photographers.Find(item.Id);
            if (found != null)
            {
                db.Entry(found).CurrentValues.SetValues(item);
            }
        }

        public PhotographerRepository(PhotoStudioContext db)
        {
            this.db = db;
        }
    }
}
