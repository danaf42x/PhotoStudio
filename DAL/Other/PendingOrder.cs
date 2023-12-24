using PhotoStudio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PhotoStudio.DAL.Other
{
    public class PendingOrder
    {
        private Brush color_yes = new SolidColorBrush(Colors.Green);
        private Brush color_no = new SolidColorBrush(Colors.Orange);

        public Order Order { get; set; }
        public bool IsActive { get => DateTime.Compare(DateTime.Now, Order.Start) > 0 && DateTime.Compare(DateTime.Now, Order.End) < 0; }
        public Brush TextColor { get => IsActive ? color_yes : color_no; }
        public string Text { get => IsActive ? "В процессе" : "В очереди"; }

        public PendingOrder(Order order)
        { 
            this.Order = order;
        }
    }
}
