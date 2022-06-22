using DataAccessLayer.Data;
using ServiceLayer.DTOs;

namespace ServiceLayer
{
    public interface IPersonService
    {
        Task<PersonResultDTO> CreatePerson(Person person);
    }
}
