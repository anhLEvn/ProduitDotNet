using System;
using System.Data.Entity;
using System.Linq;

namespace CodeFirstFrameworkAssistant.Model
{
    public class Produit2Entities : DbContext
    {
        // Your context has been configured to use a 'Produit2Entities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CodeFirstFrameworkAssistant.Model.Produit2Entities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Produit2Entities' 
        // connection string in the application configuration file.
        public Produit2Entities()
            : base("name=Produit2Entities")
        {

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}