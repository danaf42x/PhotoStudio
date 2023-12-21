using PhotoStudio.DAL.Interfaces;
using PhotoStudio.DAL.Models;
using PhotoStudio.DAL.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.DAL.Repositories
{
    public class OrderRepository : IRepositoryOrder
    {
        private PhotoStudioContext db;

        public List<Order> GetAll()
        {
            return db.Orders.Select(i => i).ToList();
        }

        public List<Order> Query(Func<Order,bool> f)
        {
            return db.Orders.Where(f).ToList();
        }

        public void Create(Order item)
        {
            db.Orders.Add(item);
        }

        public void Delete(Order item)
        {
            db.Orders.Remove(item);
        }

        public Order GetById(int id)
        {
            return db.Orders.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Order item)
        {
            var found = db.Orders.Find(item.Id);
            if (found != null)
            {
                db.Entry(found).CurrentValues.SetValues(item);
            }
        }

        public Statistic GetMonthStatistics(int month)
        {
            if (month < 0 || month >= 12)
                throw new IndexOutOfRangeException();

            Statistic stat = new Statistic();

            foreach (Order o in db.Orders.Where(o => o.End.Month == month))
            {
                stat.totalmade += o.Paid;
                stat.totalmade_photographers[o.Photographer] += o.Paid;

                if (o.Paid > 0)
                {
                    stat.successful++;
                    stat.successful_photographers[o.Photographer]++;
                }
                else
                {
                    stat.failed++;
                    stat.failed_photographers[o.Photographer]++;
                }
            }

            return stat;
        }

        public OrderRepository(PhotoStudioContext db)
        {
            this.db = db;
        }
    }
}
