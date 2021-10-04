using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirst.Model
{
    public class Produit
    {
        [Key]
        public int Id { get; set;  }

        [StringLength(100)]
        public string Designation { get; set; }

        public int CategorieId { get; set; }
        public Catetgorie Categorie { get; set; }
    }
}
