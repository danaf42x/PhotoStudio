﻿using PhotoStudio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> Query(Func<T, bool> f);
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
