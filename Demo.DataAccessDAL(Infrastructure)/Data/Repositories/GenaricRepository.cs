using Demo.DataAccessDAL_Infrastructure_.Data.Contexts;
using Demo.DataAccessDAL_Infrastructure_.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessDAL_Infrastructure_.Data.Repositories
{
    public class GenaricRepository<T>(AppDbContext _dbContext) : IGenaricRepository<T> where T : BaseEntity
    {
        //5 CRUD Operations

        // GET ALL
        public IEnumerable<T> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
                return _dbContext.Set<T>().ToList();
            return _dbContext.Set<T>().AsNoTracking().ToList();

        }

        // GET BY ID
        public T? GetById(int id) => _dbContext.Set<T>().Find(id);

        // ADD
        public int Add(T t)
        {
            _dbContext.Set<T>().Add(t);
            return _dbContext.SaveChanges();
        }

        // UPDATE
        public int Update(T t)
        {
            _dbContext.Set<T>().Update(t);
            return _dbContext.SaveChanges();
        }

        // REMOVE
        public int Remove(T t)
        {
            _dbContext.Set<T>().Remove(t);
            return _dbContext.SaveChanges();
        }
    }
}
