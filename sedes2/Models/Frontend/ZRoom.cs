using System;
using System.ComponentModel.DataAnnotations;

namespace sedes.Models.Frontend
{
    public class ZRoom
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100), Required]
        public int Floor { get; set; }

        [MaxLength(100), Required]
        public string Name { get; set; }
        public ZSeat[] Seats { get; set; }
        private int myVar;

        public int MyProperty
        {
            get { return myVar = Random.Shared.Next(); }
            set { myVar = value; }
        }
    }
}