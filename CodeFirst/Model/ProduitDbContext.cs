using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.Model
{
    class ProduitDbContext : DbContext
    {
        DbSet<Produit> Produits { get; set; }
        DbSet<Catetgorie> Catetgories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0F7BAM4\SQLEXPRESS;Initial Catalog=ProduitDB;integrated security=true");
        }

    }
}
