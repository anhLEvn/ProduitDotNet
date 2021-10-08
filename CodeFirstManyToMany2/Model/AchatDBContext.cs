using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstManyToMany2.Model
{
    class AchatDBContext : DbContext 
    {
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<LigneDeCommande> LigneDeCommandes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0F7BAM4\SQLEXPRESS;Initial Catalog=AchatDB;integrated security=true");
        }
    }
}
