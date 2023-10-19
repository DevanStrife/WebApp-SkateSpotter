using Microsoft.AspNetCore.Identity;

namespace SkateSpotter_MVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Spot>? Spots { get; set; }
        public ICollection<Brand>? FavBrands { get; set; }
    }
}
