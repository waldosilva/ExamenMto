using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmvelTest.Entity.Entities;

namespace UmvelTest.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales{ get; set; }


        public DbSet<Product> Products { get; set; }

        public DbSet<Concept> Concepts { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
            .Property(t => t.Id)
            .HasColumnName("CustomerId"); 
                                      
            modelBuilder.Entity<Sale>()
            .Property(t => t.Id)
            .HasColumnName("SaleId");

            modelBuilder.Entity<Product>()
            .Property(t => t.Id)
            .HasColumnName("ProductId");

            modelBuilder.Entity<Concept>()
            .Property(t => t.Id)
            .HasColumnName("ConceptId");


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

