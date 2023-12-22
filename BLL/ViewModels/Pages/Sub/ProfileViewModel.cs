using PhotoStudio.BLL.Base;
using PhotoStudio.DAL.Models;
using PhotoStudio.DAL.Other;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.BLL.ViewModels.Pages.Sub
{
    public class ProfileViewModel : BaseViewModel
    {
        public User MyUser { get; }
        public ObservableCollection<PendingOrder> MyPendingOrders { get; set; }

        public ProfileViewModel(MainViewModel p, User user, BaseViewModel pp)
        {
            MyUser = p.LoggedInAs;
            var orders = p.db.Orders.Query(o => o.Customer == MyUser.Customer && DateTime.Compare(o.End, DateTime.Now) > 0);
            var list = new List<PendingOrder>();

            foreach (var o in orders)
                list.Add(new PendingOrder(o));

            MyPendingOrders = new ObservableCollection<PendingOrder>(list);
        }
    }
}
