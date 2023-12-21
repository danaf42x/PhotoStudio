using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PhotoStudio.DAL.Other
{
    public class ScheduleHour
    {
        private static Brush color_yes = new SolidColorBrush(Colors.Gray);
        private static Brush color_no = new SolidColorBrush(Colors.DarkBlue);

        public bool IsAvailable { get; set; }
        public int Hour { get; set; }
        public Brush Background { get => IsAvailable ? color_yes : color_no; }
    }
}
