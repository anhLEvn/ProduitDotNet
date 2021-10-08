using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLINQ2.Model
{
    public class LingeDeCommande
    {
        public int Id { get; set; }
        public int Qte { get; set; }

        public int CommandeId { get; set; }
        public Categorie Categorie { get; set;}

        public int ProduitId { get; set; }
        public Produit Produit { get; set; }

    }
}
