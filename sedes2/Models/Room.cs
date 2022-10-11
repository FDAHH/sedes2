using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sedes.Models
{
    [Table("Room", Schema = "Sedes")]
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100), Required]
        public int Floor { get; set; }

        [MaxLength(100), Required]
        public string Name { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }

}