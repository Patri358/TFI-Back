using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T? GetById(int id);
        T Add(T entity);
        //T Update(T entity);
        T? Delete(int id);
    }
}