using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models.DTO.Category
{
    public class CategoryForCreation
    {
        [Required]
        public string Name { get; set; }

    }
}
