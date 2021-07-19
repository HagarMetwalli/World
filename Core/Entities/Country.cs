using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Country
    {
        public Country()
        {
            AddedDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "CountryName is required")]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string CountryName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/DD/YYYY}")]
        public DateTime? AddedDate { get; set;}
        public virtual ICollection<City> Cities { get; set; }
    }
}
