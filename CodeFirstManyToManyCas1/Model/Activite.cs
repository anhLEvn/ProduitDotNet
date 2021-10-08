using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstManyToManyCas1.Model
{
    public class Activite
    {
        /*public Activite()
        {
            this.Adherents = new HashSet<Adherent>(); 
        }*/

        public int Id { get; set; }
        public string Nom { get; set; }

        public ICollection<Adherent> Adherents { get; set; }
    }
}
