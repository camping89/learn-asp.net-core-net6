using Microsoft.EntityFrameworkCore;
using Sample.ASPNETCore.MVC.App.Models;

namespace Sample.ASPNETCore.MVC.App.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Sample.ASPNETCore.MVC.App.Models.Product>? Product { get; set; }
}