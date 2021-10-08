using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstFrameworkSansAssistant.Model
{
    public class Categorie
    {
        public int MyProperty { get; set; }
        public string Nom { get; set; }
        
        
        public virtual ICollection<Produit> Produits { get; set; }
        //public int MyProperty { get; set; }
    }
}
