using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Repositories.Base
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Create(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
        bool IsExist(object id);

    }
}


