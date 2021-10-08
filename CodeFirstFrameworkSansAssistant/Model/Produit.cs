using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstFrameworkSansAssistant.Model
{
    public class Produit
    {
        public int Id { get; set; }
        public string Designation { get; set; }

        public int CategorieId { get; set; }
        public virtual Categorie Categorie { get; set; }

    }
}
