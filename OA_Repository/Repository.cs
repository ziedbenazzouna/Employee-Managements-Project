using Microsoft.EntityFrameworkCore;
using OA_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> entity;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            entity = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entity.AsEnumerable();
        }

        public T GetById(int Id)
        {
            return entity.FirstOrDefault(x => x.Id == Id);
        }

        public virtual void Add(T record)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (record.Id != 0)
            { 
            entity.Update(record);
            }
            else
            { 
            entity.Add(record);
            }
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var record = entity.FirstOrDefault(x => x.Id == Id);
            entity.Remove(record);
            _context.SaveChanges();
        }
    }
}
