using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLINQ5.Model
{
    public class Produit
    {
        public int Id { get; set; }
        public string NomProduit { get; set; }
        public double Prix { get; set; }
        public string  Description { get; set; }

        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }

        public ICollection<LigneDeCommande> LigneDeCommandes { get; set; }

    }
}
