using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services
{
    public class PeopleService : CrudService<Person>, IPeopleService
    {
        //private readonly DbContext context;

        public PeopleService(DbContext context) : base(context)
        {
            //this.context = context;
        }

        public async Task<IEnumerable<Person>> ReadByFirstName(string firstName)
        {
            return await context.Set<Person>().Where(x => x.FirstName == firstName).ToListAsync();
        }
    }
}