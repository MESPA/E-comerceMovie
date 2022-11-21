using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Etiket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Etiket.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        //injection data base
        private readonly AppDbContext _appdbContext;

        public EntityBaseRepository(AppDbContext appdbContext)
        {
            _appdbContext = appdbContext;
        }

        //---------------------------------------//


        //create repository
        public async Task AddAsync(T entity)
        {
            await _appdbContext.Set<T>().AddAsync(entity);
            await _appdbContext.SaveChangesAsync();

        }

        //---------------------------------------//


        //Delete repository
        public async Task DeleteAsync(int id)
        {
            var entity = await _appdbContext.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            EntityEntry entityEntry = _appdbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _appdbContext.SaveChangesAsync();
        }
        //---------------------------------------//

        //get all repository
        public async Task<IEnumerable<T>> GetAllAsync() =>  await _appdbContext.Set<T>().ToListAsync();
        //---------------------------------------//

        //Get for Id repository
        public async Task<T> GetByIdAsync(int id) => await _appdbContext.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
        //---------------------------------------//

        //update repository 
        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _appdbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _appdbContext.SaveChangesAsync();
        }
        //---------------------------------------//
    }
}

