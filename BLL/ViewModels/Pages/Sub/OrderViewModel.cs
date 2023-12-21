using PhotoStudio.BLL.Base;
using PhotoStudio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.BLL.ViewModels.Pages.Sub
{
    public class OrderViewModel : BaseViewModel
    {
        public DateTime DisplayDateStart;
        public DateTime DisplayDateEnd;

        public OrderViewModel(MainViewModel p, User user, BaseViewModel pp)
        {
            DisplayDateStart = DateTime.Today;
            DisplayDateEnd = DateTime.Today.AddDays(14);
        }
    }
}
