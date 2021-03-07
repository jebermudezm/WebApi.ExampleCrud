using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.ExampleCrud.Model
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(6)")]
        public string LicencePlate { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Brand { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "varchar(4)")]
        public string Model { get; set; }
    }
}
