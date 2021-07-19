using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class City
    {
        public City()
        {
            AddedDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "CityName is required")]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string CityName { get; set; }
        public DateTime? AddedDate
        {
            get;
            private set;
        }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

    }
}
