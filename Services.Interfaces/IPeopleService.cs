using Models;

namespace Services.Interfaces
{
    public interface IPeopleService : ICrudService<Person>
    {
        Task<IEnumerable<Person>> ReadByFirstName(string firstName);
        Task<IEnumerable<Person>> ReadByFirstNameAsync(string firstName, CancellationToken cancellation);
    }
}