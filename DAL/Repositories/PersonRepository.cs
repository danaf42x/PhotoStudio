using PhotoStudio.DAL.Interfaces;
using PhotoStudio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.DAL.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private PhotoStudioContext db;

        public List<Person> GetAll()
        {
            return db.Persons.Select(i => i).ToList();
        }

        public List<Person> Query(Func<Person, bool> f)
        {
            return db.Persons.Where(f).ToList();
        }

        public void Create(Person item)
        {
            db.Persons.Add(item);
        }

        public void Delete(Person item)
        {
            db.Persons.Remove(item);
        }

        public Person GetById(int id)
        {
            return db.Persons.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Person item)
        {
            var found = db.Persons.Find(item.Id);
            if (found != null)
            {
                db.Entry(found).CurrentValues.SetValues(item);
            }
        }

        public PersonRepository(PhotoStudioContext db)
        {
            this.db = db;
        }
    }
}
