using DataAccessLayer.Data;
using RepositoryLayer;
using ServiceLayer.DTOs;

namespace ServiceLayer
{
    public class PersonService : IPersonService
    {
        private readonly IGenericRepository<Person> _repo;

        public PersonService(IGenericRepository<Person> repo)
        {
            _repo = repo;
        }

        public async Task<PersonResultDTO> CreatePerson(Person person)
        {
            await _repo.CreateEntity(person);
            return new PersonResultDTO(person);
        }
    }
}
