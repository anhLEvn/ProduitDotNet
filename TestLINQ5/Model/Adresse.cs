using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLINQ5.Model
{
   public class Adresse
    {
        public int Id { get; set; }
        public string Rue { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
