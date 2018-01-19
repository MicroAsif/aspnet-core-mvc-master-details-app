using aspnetcoremaster.core.Interface.BaseRepository;
using aspnetcoremaster.core.Model.Base;
using aspnetcoremaster.data.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aspnetcoremaster.data.Repository.Base
{
    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly AppDataContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public BaseRepository(AppDataContext AppDataContext)
        {
            context = AppDataContext;
            entities = context.Set<T>();
        }
        public IEnumerable<T> All()
        {
            return entities.AsEnumerable();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public T Find(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }
    }
}
