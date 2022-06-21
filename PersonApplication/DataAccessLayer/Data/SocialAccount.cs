using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Data
{
    public class SocialAccount
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string? Type { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }
        public int? PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
