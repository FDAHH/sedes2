using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sedes.Models
{
    [Table("Person", Schema = "Sedes")]
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100), Required]
        public string ExtRef { get; set; }

    }
}