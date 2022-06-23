using DataAccessLayer.Data;
using ServiceLayer.ServiceHelpers;

namespace ServiceLayer.DTOs
{
    /// <summary>
    /// DTO used as returning result for saved person.
    /// </summary>
    public class PersonResultDTO
    {
        /// <summary>
        /// Number of vowels in full name of a person.
        /// </summary>
        public int NumberOfVowels { get; set; }

        /// <summary>
        /// Number of consonants in full name of a person.
        /// </summary>
        public int NumberOfConsonants { get; set; }

        /// <summary>
        /// Reversed full name of a person.
        /// </summary>
        public string ReversedName  { get; set; } = string.Empty;

        /// <summary>
        /// Saved person object.
        /// </summary>
        public Person? Person { get; set; }

        /// <summary>
        /// PersonResultDTO parametrized constructor used for DTO conversion.
        /// </summary>
        /// <param name="person">Person entity.</param>
        public PersonResultDTO(Person person)
        {
            string fullName = string.Join(" ", person.FirstName, person.LastName);
            NumberOfVowels = StringAnalyzer.GetNumberOfVowels(fullName);
            NumberOfConsonants = StringAnalyzer.GetNumberOfConsonants(fullName);
            ReversedName = StringAnalyzer.GetReversedString(fullName);
            Person = person;
        }
    }
}
