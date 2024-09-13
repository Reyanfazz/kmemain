using kme.Models;
//using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
namespace kme.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {

            public DB_Entities _context = null;
            public DbSet<T> table = null;
            public RepositoryBase()
            {

                this._context = new DB_Entities();
                this._context.Configuration.ValidateOnSaveEnabled = false;
                this.table = _context.Set<T>();
            }
            public RepositoryBase(DB_Entities _context)
            {
                this._context = _context;
                this.table = _context.Set<T>();
            }
            public IEnumerable<T> GetAll()
            {

                return table.ToList();
            }

            public T GetById(int id)
            {
                return table.Find(id);
            }
            public void Insert(T obj)
            {
                table.Add(obj);
            }
            public void Update(T obj)
            {
                table.Attach(obj);
                _context.Entry(obj).State = (EntityState)EntityState.Modified;
            }
            public void Delete(int id)
            {
                var data = table.Find(id);
                table.Remove(data);
            }
            public void Save()
            {
                _context.SaveChanges();
            }

        }
    }

