using System.Threading.Tasks;
using EntityFrameworkSequence.Models.Entities;

namespace EntityFrameworkSequence.Data
{
    public interface IPersonRepository
    {
        Task<Person> CreatePersonAsync(Person person);
    }
}
