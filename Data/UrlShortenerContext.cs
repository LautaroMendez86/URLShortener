﻿using URLShortener.Entities;
using Microsoft.EntityFrameworkCore;

namespace URLShortener.Data
{
    public class UrlShortenerContext : DbContext
    {
        public DbSet<XYZ> XYZs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>()
                .HasMany(c => c.XYZs)
                .WithOne(x => x.Category);

            modelBuilder.Entity<User>()
                .HasMany(x => x.XYZs)
                .WithOne(u => u.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}
