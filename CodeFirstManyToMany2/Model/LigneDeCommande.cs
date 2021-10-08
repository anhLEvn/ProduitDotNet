using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstManyToMany2.Model
{
    class LigneDeCommande
    {
        public int Id { get; set; }
    
        public int NbArticle { get; set; }
        public double TotalLigne { get; set; }

        //Propriete de Navigation
        //command
        public int CommandId { get; set; }
        public Command Command { get; set; }

        //produit
        public int ProduitId { get; set; }
        public Produit Produit { get; set; }


    }

}
