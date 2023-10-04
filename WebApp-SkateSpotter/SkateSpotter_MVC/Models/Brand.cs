using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SkateSpotter_MVC.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Website { get; set; }
        // has no key attribute
        public ICollection<string>? ProductCategories { get; set; }
        public int? NumberOfFavourites { get; set; }

        public virtual ICollection<IdentityUser>? Fan { get; set; }
        public virtual ICollection<int>? FanId { get; set; }

        public ICollection<Stores>? Stores { get; set; }
        public ICollection<int>? StoresId { get; set; }


    }
}
