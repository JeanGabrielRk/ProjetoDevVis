using System;
using API.modelos;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class AppDataContext : DbContext
{
    public DbSet<Planta> Plantas { get; set; }

    public DbSet<Origem> Origens { get; set; }

    public DbSet<Tipo> Tipo { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Planta>()
            .HasOne(p => p.Origem)
            .WithMany(o => o.Plantas)
            .HasForeignKey(p => p.OrigemId); 
    }
}