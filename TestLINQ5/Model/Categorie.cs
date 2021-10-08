using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLINQ5.Model
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Libelle { get; set; }

        public ICollection<Produit> Produits { get; set; }
    }
}
