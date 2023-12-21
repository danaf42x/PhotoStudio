using Ninject.Modules;
using PhotoStudio.DAL.Interfaces;
using PhotoStudio.DAL.Models;
using PhotoStudio.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.Ninject
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Order>>().To<OrderRepository>();
            Bind<IRepository<Person>>().To<PersonRepository>();
            Bind<IRepository<Photographer>>().To<PhotographerRepository>();
            Bind<IRepositoryUser>().To<UserRepository>();
        }
    }
}
