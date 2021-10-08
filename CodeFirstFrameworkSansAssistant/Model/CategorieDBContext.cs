using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstFrameworkSansAssistant.Model
{
    public class CategorieDBContext : DbContext
    {
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        // Dans la version core le nom de la base était dans
        // la méthode OnConfiguring, ce nom sera mis plus tard dans uun fichier JSON
        //Car on n'a pas le fichier app.config dans la version core

        //Avec la version .NET Framework on garde le fichier app.config qui doit contenir la chaine
        //de connexion vers la base
        // pour faire le lien avec ce fichier app.config on utilise la construteur de la classe
        public CategorieDBContext() : base("DBVentesConnexionString") 
        { 
        }
    }
    //
    
}
