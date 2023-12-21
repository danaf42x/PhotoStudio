using PhotoStudio.DAL.Other;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PhotoStudio.DAL.Models
{
    public class Photographer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronym { get; set; }
        public string PhoneNumber { get; set; }
        public string Passport { get; set; }
        public int DayStartHour { get; set; }
        public int DayEndHour { get; set; }
        public DateTime VacationUntil { get; set; }

        [NotMapped]
        private ImageSource _imgsrc;
        [NotMapped]
        public ImageSource ImageSource
        {
            get
            {
                if (_imgsrc == null)
                {
                    var converter = new ImageSourceConverter();
                    _imgsrc = (ImageSource)converter.ConvertFromString("pack://application:,,,/PL/Images/Employees/" + PhoneNumber + ".jpg");
                }
                return _imgsrc;
            }
        }

        [NotMapped]
        private ScheduleHour[] _schedule;
        [NotMapped]
        public ScheduleHour[] Schedule
        {
            get
            {
                if (_schedule == null)
                {
                    var s = new ScheduleHour[24];

                    for (int i=0; i<s.Length; i++)
                    {
                        s[i] = new ScheduleHour()
                        {
                            IsAvailable = (DayEndHour > DayStartHour ? (i >= DayStartHour && i <= DayEndHour) : !(i >= DayEndHour && i <= DayStartHour)),
                            Hour = i
                        };
                    }

                    _schedule = s;
                }
                return _schedule;
            }
        }
    }
}
