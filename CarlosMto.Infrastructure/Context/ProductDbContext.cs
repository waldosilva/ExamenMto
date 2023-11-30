using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarlosMto.Entity.Entities;

namespace CarlosMto.Infrastructure.Context
{
    public class ProductDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }


        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Product>()
            .Property(t => t.Id)
            .HasColumnName("ProductId");



        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is EntityBase && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            return base.SaveChanges();
        }


    }
}

