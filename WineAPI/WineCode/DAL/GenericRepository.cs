using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCode.Data;

namespace WineCode.DAL
{
    public class GenericRepository<T> : IRepository<T> where T:class
    {
        private WineContext _context;
        private DbSet<T> _table;

        public GenericRepository(WineContext context) { 
            _context = context;
            _table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetByID(int id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Delete(int id)
        {
            T existing = _table.Find(id);
            if (existing != null)
            {
                _table.Remove(existing);
            }
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

    }
}
