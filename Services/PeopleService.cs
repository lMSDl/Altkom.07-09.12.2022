using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services
{
    public class PeopleService : IPeopleService
    {
        private readonly DbContext context;

        public PeopleService(DbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(Person entity)
        {
            await context.Set<Person>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            context.Set<Person>().Remove(new Person { Id = id });
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> ReadAsync()
        {
            return await context.Set<Person>().AsNoTracking().ToListAsync();
        }

        public async Task<Person?> ReadAsync(int id)
        {
            //return await context.Set<Person>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return await context.Set<Person>().FindAsync(id);
        }

        public async Task UpdateAsync(int id, Person entity)
        {
            entity.Id = id;
            context.Set<Person>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}