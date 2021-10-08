using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstFrameworkAssistant.Model
{
    public class Produit
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public DateTime DateAchat { get; set; }
        public int QteMin { get; set; }
        public double  Prix { get; set; }
        public bool IsBio { get; set; }
        public string Fournisseur { get; set; }
        public string Description { get; set; }


        public int CategorieId { get; set; }
        public virtual Categorie Categorie { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; }
    }
}
