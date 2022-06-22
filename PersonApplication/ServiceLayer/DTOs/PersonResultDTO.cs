using DataAccessLayer.Data;
using ServiceLayer.ServiceHelpers;

namespace ServiceLayer.DTOs
{
    public class PersonResultDTO
    {
        public int NumberOfVowels { get; set; }
        public int NumberOfConsonants { get; set; }
        public string? ReversedName  { get; set; }
        public Person? SavedPerson { get; set; }

        public PersonResultDTO(Person person)
        {
            string fullName = string.Join(" ", person.FirstName, person.LastName);
            NumberOfVowels = NameAnalyzer.GetNumberOfVowels(fullName);
            NumberOfConsonants = NameAnalyzer.GetNumberOfConsonants(fullName);
            ReversedName = NameAnalyzer.GetReversedName(fullName);
            SavedPerson = person;
        }
    }
}
