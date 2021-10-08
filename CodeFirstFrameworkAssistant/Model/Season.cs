using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstFrameworkAssistant.Model
{
    public class Season
    {
        public int Id { get; set; }
        public string NomSeason { get; set; }

        // navigate vers Produits
        public virtual  ICollection<Produit> Produits { get; set; }
    }
}
