using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpClient.Model
{
    class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public ICollection<Commande> Commandes { get; set; }
    }
}
