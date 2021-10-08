using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestLINQ5.Model;

namespace TestLINQ5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClientDBContext db = new ClientDBContext(); 

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            dgPrincipale.ItemsSource = db.Produits.ToList(); 
        }

        private void ListClient_SQL_Click(object sender, RoutedEventArgs e)
        {
            //var liste = from c in db.Clients 
            //            where c.Id 
                        
        }

 

    private void ListClient_Lbd_Click(object sender, RoutedEventArgs e)
        {


            

        }

        private void ListCMD_SQL_Click(object sender, RoutedEventArgs e)
        {
            var liste = from c in db.Clients
                        join cmd in db.Commandes
                        on c.Id equals cmd.ClientId
                        join ldc in db.LigneDeCommandes
                        on cmd.Id equals ldc.CommandeId
                        join p in db.Produits             
                        on ldc.ProduitId equals p.Id
            select new { c.NomClient, cmdId = cmd.Id, p.NomProduit, ldc.Qte};

            dgResultat.ItemsSource = liste.ToList(); 
        }

        private void ListCMD_Lbd_Click(object sender, RoutedEventArgs e)
        {
            var liste = db.Commandes.Join(db.Clients, cmd => cmd.ClientId, c => c.Id, (cmd, c)
                 => new { NomClient = c.NomClient, cmdId = cmd.Id });
        }

        //var liste = db.Produits.Join(db.Categories, p => p.CategorieId, c => c.Id,
        //       (p, c) => new { p.Designation, c.Nom });
        //dgResultat.ItemsSource = liste.ToList(); 

        private void NbTotalCMD_SLQ_Click(object sender, RoutedEventArgs e)
        {
            var liste = from cmd in db.Commandes
                        group cmd by cmd.ClientId into grpCmd
                        join c in db.Clients
                        on grpCmd.Key equals c.Id
                        select new { Id = grpCmd.Key, c.NomClient, total = grpCmd.Count() };

            //MessageBox.Show(liste.ToString());

            dgResultat.ItemsSource = liste.ToList();
        }

        private void NbTotalCMD_Lbd_Click(object sender, RoutedEventArgs e)
        {
            //var liste = db.Commandes.Join(db.Clients, cmd => cmd.ClientId, c => c.Id, 
            //    (cmd,c) => new {cmd.Id, c.NomClient})
            //     .GroupBy(cc => new {cc.NomClient, cc.Id})
            //    .Select(grpCC => new { cmdId = grpCC.Key.Id, Total = grpCC.Count(), grpCC.Key.NomClient}); 
              
            //dgResultat.ItemsSource = liste.ToList();

            var liste = db.Clients.Join(db.Commandes, c => c.Id, cmd => cmd.ClientId,
               (c, cmd) => new { cmd, c })
                .GroupBy(cc => new { cc.c.NomClient, cc.c.Id, cc.cmd.ClientId })
               .Select(grpCC => new {Total = grpCC.Count(), grpCC.Key.NomClient });

            dgResultat.ItemsSource = liste.ToList();
        }

    }
}
