using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SkateSpotter_MVC.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Adress { get; set; }
        public string? ZipCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }

        public virtual IdentityUser? Owner { get; set; }
        public virtual int? OwnerId { get; set; }

        public ICollection<Brand>? Brands { get; set; }
    }
}
