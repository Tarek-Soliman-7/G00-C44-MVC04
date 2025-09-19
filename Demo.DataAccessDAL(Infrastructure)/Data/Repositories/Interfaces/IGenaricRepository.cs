using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessDAL_Infrastructure_.Data.Repositories.Interfaces
{
    public interface IGenaricRepository<T> where T : BaseEntity
    {
        int Add(T t);
        IEnumerable<T> GetAll(bool WithTracking = false);
        T? GetById(int id);
        int Remove(T t);
        int Update(T t);
    }
}
