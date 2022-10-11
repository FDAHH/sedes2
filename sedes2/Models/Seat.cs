using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace sedes.Models
{
    [Table("Seat", Schema = "Sedes")]
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(100), Required]
        public string Name { get; set; }
        public bool isAvailable { get; set; }

        //public string SecretPin { get; set; }

    }
}