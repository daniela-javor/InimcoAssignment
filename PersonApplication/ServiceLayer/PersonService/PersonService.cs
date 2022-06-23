using DataAccessLayer.Data;
using RepositoryLayer;
using ServiceLayer.DTOs;

namespace ServiceLayer
{
    /// <summary>
    /// Class used for person operations.
    /// </summary>
    public class PersonService : IPersonService
    {
        private readonly IGenericRepository<Person> _repo;

        /// <summary>
        /// PersonService consturctor.
        /// </summary>
        /// <param name="repo"></param>
        public PersonService(IGenericRepository<Person> repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Creates person.
        /// </summary>
        /// <param name="person">Person to create.</param>
        /// <returns>Returns result DTO object.</returns>
        public async Task<PersonResultDTO> CreatePerson(Person person)
        {
            await _repo.CreateEntity(person);
            return new PersonResultDTO(person);
        }
    }
}
