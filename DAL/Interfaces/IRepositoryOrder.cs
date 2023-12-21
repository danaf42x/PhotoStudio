using PhotoStudio.DAL.Models;
using PhotoStudio.DAL.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.DAL.Interfaces
{
    public interface IRepositoryOrder
    {
        List<Order> GetAll();
        List<Order> Query(Func<Order, bool> f);
        Order GetById(int id);
        Statistic GetMonthStatistics(int month);
        void Create(Order item);
        void Update(Order item);
        void Delete(Order item);
    }
}
