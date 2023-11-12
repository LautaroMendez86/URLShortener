using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models
{
    public class CategoryForCreation
    {
        [Required]
        public string Name { get; set; }

    }
}
