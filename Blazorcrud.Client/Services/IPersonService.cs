using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;

namespace VendingOperator.Client.Services
{
    public interface IPersonService
    {
        Task<PagedResult<Person>> GetPeople(string? name, string page);
        Task<Person> GetPerson(int id);

        Task DeletePerson(int id);

        Task AddPerson(Person person);

        Task UpdatePerson(Person person);
    }
}