using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sedes.Models
{
    [Table("Building", Schema = "Sedes")]
    public class Building
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100), Required]
        public string Name { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }

}