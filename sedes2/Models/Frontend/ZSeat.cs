using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace sedes.Models.Frontend
{
    public class ZSeat
    {
        [Key]
        public int Id { get; set; }
        

        [MaxLength(100), Required]
        public string Name { get; set; }
        public bool isAvailable { get; set; }
        private int myVar;

        public int MyProperty
        {
            get { return myVar = Random.Shared.Next(); }
            set { myVar = value; }
        }

        //public string SecretPin { get; set; }


    }
}