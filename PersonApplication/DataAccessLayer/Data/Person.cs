using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Data
{
    public class Person
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string? FirstName { get; set; }

        [StringLength(20)]
        public string? LastName { get; set; }
        public List<SocialSkill>? SocialSkills { get; set; }
        public List<SocialAccount>? SocialAccounts { get; set; }
    }
}
