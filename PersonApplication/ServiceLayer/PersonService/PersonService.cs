using DataAccessLayer.Data;
using RepositoryLayer;

namespace ServiceLayer
{
    public class PersonService : IPersonService
    {
        private readonly IGenericRepository<Person> _repo;

        public PersonService(IGenericRepository<Person> repo)
        {
            _repo = repo;
        }

        public async Task CreatePerson(Person person)
        {
            await _repo.Insert(person);
            await _repo.Save();
        }
    }
}
