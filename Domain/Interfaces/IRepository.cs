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
        // Task <List<T>> GetAll();
        // Task <T?> GetById(int id)
        //Task AddAsync(T entity);
        //void Update(T entity);
        //void Delete(T entity);
    }
}