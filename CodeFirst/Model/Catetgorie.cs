using System.Collections.Generic;

namespace CodeFirst.Model
{
    public class Catetgorie
    {
        
        public int Id { get; set; }
        public string Libelle { get; set; }

       //public List<Produit> ListeProduits { get; set; }
        public ICollection<Produit> Produits { get; set; }
    }

    
}