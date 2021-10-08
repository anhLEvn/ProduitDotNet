using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLINQ5.Model
{
    public class LigneDeCommande
    {
        public int Id { get; set; }
        public int Qte { get; set; }

        public int CommandeId { get; set; }
        public Categorie Categorie { get; set;}

        public int ProduitId { get; set; }
        public Produit Produit { get; set; }

    }
}
