using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace URLShortener.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Usage { get; set; }
        [ForeignKey("userID")]
        public int UserID { get; set; }
        public List<Category> Categories { get; set; }
    }
}
