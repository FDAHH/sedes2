using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sedes.Models
{
    [Table("Reservation", Schema = "Sedes")]
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Person Person { get; set; }
        [Required]
        public Seat Seat { get; set; }
        [Required]
        public Building Building { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }


        public TimeSpan Duration
        {
            get { return End - Start; }
        }
    }

}