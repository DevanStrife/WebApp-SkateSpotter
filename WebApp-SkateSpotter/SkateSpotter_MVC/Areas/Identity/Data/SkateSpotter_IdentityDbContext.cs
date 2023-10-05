using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SkateSpotter_MVC.Areas.Identity.Data;

public class SkateSpotter_IdentityDbContext : IdentityDbContext<IdentityUser>
{
    public SkateSpotter_IdentityDbContext(){}
    public SkateSpotter_IdentityDbContext(DbContextOptions<SkateSpotter_IdentityDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DS-Asus-Laptop\\SQLEXPRESS;Database=SkateSpotter_PI4;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }
}
