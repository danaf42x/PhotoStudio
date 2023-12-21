using PhotoStudio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.DAL.Interfaces
{
    public interface IDbRepositories
    {
        IRepositoryOrder Orders { get; }
        IRepository<Person> Persons { get; }
        IRepository<Photographer> Photographers { get; }
        IRepositoryUser Users { get; }
        int Save();
    }
}
