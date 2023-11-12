using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using System.Diagnostics.Contracts;

namespace URLShortener.Entities
{
    public class XYZ
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string URL { get; set; }

        public int Visit { get; set; }

        public string Hash { get; set; }

        public List<Category> Categories { get; set; }

    }
}
