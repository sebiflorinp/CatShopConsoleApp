using CatShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CatShop.DbContexts;

public class CatDbContext : DbContext
{
    public DbSet<Cat?> Cats { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=viaduct.proxy.rlwy.net;Port=26344;Database=railway;Uid=root;Pwd=QliUragrZDYbVOXuhrNugkeLyEKlwFRt");
    }
}