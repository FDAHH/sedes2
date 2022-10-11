using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sedes.Models.Frontend
{
    public class ZBuilding
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100), Required]
        public string Name { get; set; }
        public ICollection<ZRoom> Rooms { get; set; }
        private int myVar;

        public int MyProperty
        {
            get { return myVar = Random.Shared.Next(); }
            set { myVar = value; }
        }
    }

}