using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhotoStudio.DAL.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime End { get; set; } = DateTime.Now;
        public Person Customer { get; set; }
        public Photographer Photographer { get; set; }
        public int Paid { get; set; } = 0;

        public override string ToString()
        {
            return "Order #" + Id + " (" + Photographer + "->" + Customer + ")";
        }
    }
}
