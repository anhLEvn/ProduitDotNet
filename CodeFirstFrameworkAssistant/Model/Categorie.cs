using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstFrameworkAssistant.Model
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        
        
        public virtual ICollection<Produit> Produits { get; set; }
        //public int MyProperty { get; set; }
    }
}
