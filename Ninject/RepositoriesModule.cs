using Ninject.Modules;
using PhotoStudio.DAL.Interfaces;
using PhotoStudio.DAL.Repositories;
using PhotoStudio.DAL.RepositoriesMongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.Ninject
{
    public class RepositoriesModule : NinjectModule
    {
        private string connectionString;

        public RepositoriesModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IDbRepositories>().To<DbRepositories>().InSingletonScope().WithConstructorArgument(connectionString);
            //Bind<IDbRepositories>().To<DbRepositoriesMongo>().InSingletonScope().WithConstructorArgument(connectionString);
        }
    }
}
