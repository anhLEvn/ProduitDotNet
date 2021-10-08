using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLINQ4.Model
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime DateCmd { get; set; }

        public ICollection<LingeDeCommande> LingeDeCommandes { get; set; }
    }
}
