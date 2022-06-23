using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Data
{
    /// <summary>
    /// Represents Person data entity class.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// First name of a person.
        /// </summary>
        [Required]
        [StringLength(50)]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Last name of a person.
        /// </summary>
        [Required]
        [StringLength(50)]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Social skills of a person.
        /// </summary>
        public List<string> SocialSkills { get; set; } = new List<string>();

        /// <summary>
        /// Social accounts of a person.
        /// </summary>
        public List<SocialAccount> SocialAccounts { get; set; } = new List<SocialAccount>();
    }
}
