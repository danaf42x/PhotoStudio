using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PhotoStudio.DAL.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronym { get; set; }
        public string PhoneNumber { get; set; }
        public string Passport { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Surname + " " + Name + " " + Patronym;
        }
    }
}
