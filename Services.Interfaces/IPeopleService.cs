using Models;

namespace Services.Interfaces
{
    public interface IPeopleService
    {
        Task<int> CreateAsync(Person entity);
        Task<IEnumerable<Person>> ReadAsync();
        Task<Person?> ReadAsync(int id);
        Task UpdateAsync(int id, Person entity);
        Task DeleteAsync(int id);
    }
}