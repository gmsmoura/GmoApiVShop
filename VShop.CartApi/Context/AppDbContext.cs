using Microsoft.EntityFrameworkCore;
using VShop.CartApi.Models;

namespace VShop.CartApi.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product>? Products { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<CartHeader> CartHeaders { get; set; }

    //Fluent API - Uso do OnModelCreating para configurar as entidades
    protected override void OnModelCreating(ModelBuilder mb)
    {
        //Product
        mb.Entity<Product>()
            .HasKey(c => c.Id); // define a chave primaria

        //Product
        mb.Entity<Product>().
           Property(c => c.Id)
            .ValueGeneratedNever(); // desabilita o auto incremento

        mb.Entity<Product>().
           Property(c => c.Name).
             HasMaxLength(100).
               IsRequired(); // define como obrigatorio e tamanho maximo

        mb.Entity<Product>().
          Property(c => c.Description).
               HasMaxLength(255).
                   IsRequired();

        mb.Entity<Product>().
          Property(c => c.ImageURL).
              HasMaxLength(255).
                  IsRequired();

        mb.Entity<Product>().
           Property(c => c.CategoryName).
               HasMaxLength(100).
                IsRequired();

        mb.Entity<Product>().
           Property(c => c.Price).
             HasPrecision(12, 2); // define a precisao do decimal

        //CartHeader
        mb.Entity<CartHeader>().
             Property(c => c.UserId).
             HasMaxLength(255).
                 IsRequired();

        mb.Entity<CartHeader>().
           Property(c => c.CouponCode).
              HasMaxLength(100);
    }
}
