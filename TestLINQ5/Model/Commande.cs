using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLINQ5.Model
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime DateCmd { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<LigneDeCommande> LigneDeCommandes { get; set; }
    }
}
