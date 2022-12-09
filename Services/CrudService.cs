using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services
{
    public class CrudService<T> : ICrudService<T> where T : Entity
    {
        protected readonly DbContext context;

        public CrudService(DbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
                return;
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ReadAsync()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> ReadAsync(int id)
        {
            //return await context.Set<T>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return await context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(int id, T entity)
        {
            entity.Id = id;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}