using System.ComponentModel.DataAnnotations;

namespace SkateSpotter_MVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? category { get; set; }

        public virtual ICollection<Brand>? Brand { get; set; }

    }
}
