using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstManyToMany2.Model
{
    class Command
    {
        public int Id { get; set; }
        public DateTime DateCommand { get; set; }

        public string Infos { get; set; }

        // List de ligne de commande

        public ICollection<LigneDeCommande> LigneDeCommandes { get; set; }


    }
}
