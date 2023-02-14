using Conduit.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ConduitCoreDbContext _context;
        private readonly DbSet<T> _table;
        public BaseRepository(ConduitCoreDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public void Create(T obj)
        {
            _table.Add(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(object id)
        {
            return _table.Find(id);
        }

        public void Update(T obj)
        {
            _table.Update(obj);
        }

        public void Delete(object id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool IsExist(object id)
        {
            return _table.FirstOrDefault(id) != null;
        }
    }
}

