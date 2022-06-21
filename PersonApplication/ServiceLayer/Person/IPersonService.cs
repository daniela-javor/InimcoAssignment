using DataAccessLayer.Data;

namespace ServiceLayer
{
    internal interface IPersonService
    {
        Task CreatePerson(Person person);
    }
}
