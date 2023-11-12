using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models.DTO.XYZ
{
    public class XYZForUpdateDTO
    {
        [Required]
        public int ID { get; set; }
        public string URL { get; set; }
        public int CategoryID { get; set; }

    }
}
