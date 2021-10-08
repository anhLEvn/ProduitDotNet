using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLINQ4.Model
{
   public class Client
    {
        public int Id { get; set; }
        public string NomClient { get; set; }

        public ICollection<Adresse> Adresses { get; set; }

        public ICollection<Commande> Commandes { get; set; }
    }
}
