using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Data
{
    /// <summary>
    /// Represents social account entity class.
    /// </summary>
    public class SocialAccount
    {
        /// <summary>
        /// Social account type.
        /// </summary>
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Social account address.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Address { get; set; } = string.Empty;
    }
}
