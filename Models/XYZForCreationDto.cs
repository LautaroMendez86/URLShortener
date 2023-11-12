using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models
{
    public class XYZForCreationDto
    {
        [Required]
        public required string URL { get; set; }
        public int? CategoryID { get; set; }
    }
}
