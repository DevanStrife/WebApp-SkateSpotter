using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SkateSpotter_MVC.Models
{
    public class Spot
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public float x_cord { get; set; }
        public float y_cord { get; set; }

        // foreign key
        public virtual IdentityUser? Skaters { get; set; }

    }
}
