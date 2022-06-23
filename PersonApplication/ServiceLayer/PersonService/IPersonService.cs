using DataAccessLayer.Data;
using ServiceLayer.DTOs;

namespace ServiceLayer
{
    /// <summary>
    /// Person operations service interface.
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Creates person.
        /// </summary>
        /// <param name="person">Person to create.</param>
        /// <returns>Returns result DTO object.</returns>
        Task<PersonResultDTO> CreatePerson(Person person);
    }
}
