using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirstManyToManyCas1.Model
{
   public class Adherent
    {
        /*public Adherent()
        {
            this.Activites = new HashSet<Activite>(); 
        }*/
        public int Id { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public ICollection<Activite> Activites { get; set; }
    }
}
