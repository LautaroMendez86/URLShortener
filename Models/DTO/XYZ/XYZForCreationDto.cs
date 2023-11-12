using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models.DTO.XYZ
{
    public class XYZForCreationDto
    {
        [Required]
        public required string URL { get; set; }
        public int CategoryID { get; set; }
    }
}
