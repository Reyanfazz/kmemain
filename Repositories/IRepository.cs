using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using kme.Models;
namespace kme.Repositories
{
  
    public interface IRepository<T> where T : class
        {
            IEnumerable<T> GetAll();
            T GetById(int id);
            void Insert(T obj);
            void Update(T obj);
            void Delete(int obj);
            void Save();

        }
    
}

