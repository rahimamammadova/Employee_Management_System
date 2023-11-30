using EMS_DAL.Data;
using EMS_DAL.Models;
using EMS_DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbIdentityContext _dbContext;
        protected readonly DbSet <TEntity> _entities;
        public GenericRepository(AppDbIdentityContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity item)
        {

            await _entities.AddAsync(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(Guid id)
        {
            var dbItem = _entities.Find(id);
            _entities.Remove(dbItem);
            _dbContext.SaveChanges();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var dbItem = await _entities.FindAsync(id);
            return dbItem;
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            var dbItem = await _entities.ToListAsync();
            return dbItem;
        }

        public TEntity Update(TEntity item)
        {
            var dbEntity = _entities.Find(item.Id);
            item.CreatedDate = dbEntity.CreatedDate;
            // item.UpdateDate = DateTime.Now;        
            _entities.Update(item);
            _dbContext.SaveChanges();
            return item;
        }
    }
}
