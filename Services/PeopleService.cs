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

        public async Task<IEnumerable<Person>> ReadByFirstNameAsync(string firstName, CancellationToken cancellation)
        {
            var people =  await context.Set<Person>().Where(x => x.FirstName == firstName).ToListAsync(cancellation);

            
            if(cancellation.IsCancellationRequested)
            {
                return null;
            }

            try
            {

                foreach (var person in people)
                {
                    await Task.Delay(5000, cancellation);
                    person.PESEL = 00000000;
                    cancellation.ThrowIfCancellationRequested();
                }
                cancellation.ThrowIfCancellationRequested();
            }
            catch(Exception e)
            {
                return null;
            }

            return people;

        }
    }
}