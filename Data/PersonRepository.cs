using System.Threading.Tasks;
using EntityFrameworkSequence.Data.DB;
using EntityFrameworkSequence.Models.Entities;

namespace EntityFrameworkSequence.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly NorthwindDbContext _dbContext;

        public PersonRepository(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            var personFromDB = await _dbContext.Person.AddAsync(person);
            await _dbContext.SaveChangesAsync();
            return personFromDB.Entity;
        }
    }
}
