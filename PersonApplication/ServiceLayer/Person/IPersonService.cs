using DataAccessLayer.Data;

namespace ServiceLayer
{
    public interface IPersonService
    {
        Task CreatePerson(Person person);
    }
}
