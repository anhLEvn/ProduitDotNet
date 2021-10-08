using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;

namespace CodeFirstManyToManyCas1.Model
{
    class ClubDBContext : DbContext // Framwork Core

    {
        public DbSet<Adherent> Adherents { get; set; }
        public DbSet<Activite> Activites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0F7BAM4\SQLEXPRESS;Initial Catalog=ClubDB;integrated security=true");
        }
    }

    

}
