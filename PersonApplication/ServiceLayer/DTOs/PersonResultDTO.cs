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
            NumberOfVowels = StringAnalyzer.GetNumberOfVowels(fullName);
            NumberOfConsonants = StringAnalyzer.GetNumberOfConsonants(fullName);
            ReversedName = StringAnalyzer.GetReversedName(fullName);
            SavedPerson = person;
        }
    }
}
