using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Data
{
    public class Person
    {
        [StringLength(20)]
        public string? FirstName { get; set; }
        [StringLength(20)]
        public string? LastName { get; set; }
        public List<string>? SocialSkills { get; set; }
        public List<SocialAccount>? SocialAccounts { get; set; }
    }
}
