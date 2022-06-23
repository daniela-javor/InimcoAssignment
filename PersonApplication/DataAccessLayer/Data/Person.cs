using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Data
{
    public class Person
    {
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string? LastName { get; set; }

        public List<string>? SocialSkills { get; set; }

        public List<SocialAccount>? SocialAccounts { get; set; }
    }
}
