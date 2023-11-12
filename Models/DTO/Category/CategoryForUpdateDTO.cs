using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models.DTO.Category
{
    public class CategoryForUpdateDTO
    {
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
