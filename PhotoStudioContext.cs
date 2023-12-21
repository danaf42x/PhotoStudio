using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PhotoStudio.DAL.Models;

namespace PhotoStudio
{
    public class PhotoStudioContext : DbContext
    {
        public PhotoStudioContext() : base("PhotoStudioCS") { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Photographer> Photographers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
