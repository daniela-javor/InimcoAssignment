using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Data
{
    public class SocialAccount
    {
        [StringLength(20)]
        public string? Type { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }
    }
}
