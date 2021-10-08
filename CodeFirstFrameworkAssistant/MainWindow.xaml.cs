using CodeFirstFrameworkAssistant.Model;
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

namespace CodeFirstFrameworkAssistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Produit2Entities db = new Produit2Entities(); 
        public MainWindow()
        {
            InitializeComponent();

            Init();

         
        }

        private void Init()
        {
            dgPrincipale.ItemsSource = db.Produits.ToList();

            //var obj1 = new { attri1 = "Hello", nom = "Oj anonyme", prix = 11.11 };

            //MessageBox.Show(obj1.attri1 + " " + obj1.prix);
            //string s = "02 Rue Berzue 67000, Lyon";
            //var adresse = new { numero = s.Substring(0, 2), rue = s.Substring(6, 6), cp = s.Substring(12, 5) };

            //MessageBox.Show(adresse.rue);
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            var listeTotal = from list in db.Produits select list;
            dgResultat.ItemsSource = listeTotal.ToList(); 
        }

        private void SelectLambda_Click(object sender, RoutedEventArgs e)
        {
            //var listTotal = db.Produits.Select(x => x).ToList();
            var listTotal = db.Produits; // var listTotal = db.Produits.ToList(); //

            dgResultat.ItemsSource = listTotal.ToList();  // listTotal;
        }

        private void Select3_Click(object sender, RoutedEventArgs e)
        {
            var liste = from item in db.Produits select new { item.Designation, item.Prix };

            dgResultat.ItemsSource = liste.ToList(); 
        }

        private void SelectLambda2_Click(object sender, RoutedEventArgs e)
        {
            var list4 = db.Produits.Select(i => new { i.Prix, i.Description });

            dgResultat.ItemsSource = list4.ToList(); 
        }

        private void Join_Click(object sender, RoutedEventArgs e)
        {
            var liste = from p in db.Produits
                        join c in db.Categories
                        on p.CategorieId equals c.Id
                        select new { p.Description, p.Prix, c.Nom };
            dgResultat.ItemsSource = liste.ToList(); 
        }

        private void JoinLambda_Click(object sender, RoutedEventArgs e)
        {
            var liste = db.Produits.Join(db.Categories, p => p.CategorieId, c => c.Id,
                (p, c) => new { p.Designation, c.Nom });
            dgResultat.ItemsSource = liste.ToList(); 
        }

        private void JoinMulti_Click(object sender, RoutedEventArgs e)
        {
            var liste = from p in db.Produits
                        join c in db.Categories
                        on p.CategorieId equals c.Id
                        join s in db.Seasons
                        on p.SeasonId equals s.Id
                        select new { p.Description, p.Prix, c.Nom , s.NomSeason};
            dgResultat.ItemsSource = liste.ToList();



        }

        private void JoinMultiLambda_Click(object sender, RoutedEventArgs e)
        {
            //var liste = db.Produits.Join(db.Categories, p => p.CategorieId, c => c.Id,
            //    (p, c) => new {p.SaisonId, p.Designation, p.Prix, Categ=c.Nom }
            //    )
            //    .Join(db.Saisons,s1=> s1.SaisonId, s=>s.Id,
            //    (s1,s) => new { s1.Designation, s1.Prix,s1.Categ, s.NomSaison }
            //    );
            // enregistrement = lignes = tuples 
            //var liste = db.Produits.Join(db.Seasons, x => x.SeasonId, y => y.Id, (x, y) 
            //    => new { x.CategorieId, x.Designation, x.Prix, y.NomSeason })
            //    .Join(db.Categories, t => t.CategorieId, c => c.Id, (t, c) 
            //    => new { t.Designation, t.Prix, t.NomSeason, c.Nom })
            //    ;

            //dgResultat.ItemsSource = liste.ToList();

            var liste = db.Seasons.Join(db.Produits, x => x.Id, y => y.SeasonId, (x, y)
                => new { y.CategorieId, y.Designation, y.Prix, x.NomSeason })
                .Join(db.Categories, t => t.CategorieId, c => c.Id, (t, c)
                => new { t.Designation, t.Prix, t.NomSeason, c.Nom })
                ;

            dgResultat.ItemsSource = liste.ToList();

        }

        private void DisctintSQL_Click(object sender, RoutedEventArgs e)
        {
            var liste = (from item in db.Produits select new { item.CategorieId }).Distinct();
            dgResultat.ItemsSource = liste.ToList();

            //// afficher les catégories utilisés
            //var liste = (from elt in db.Produits select new { elt.CategorieId }).Distinct();

            //// sans doudlon
            //dgResultat.ItemsSource = liste.ToList();

        }

        private void DisctintMultiLambda_Click(object sender, RoutedEventArgs e)
        {
            var liste = db.Produits.Select(p => p.CategorieId).Distinct();
            dgResultat.ItemsSource = liste.ToList();
        }

        private void GroupBySQL_Click(object sender, RoutedEventArgs e)
        {
            // liste des produits par saison en utilisant la syntaxe fonctionnelle


            // liste par categorie et par saison
            var liste = from x in db.Produits
                        group x by x.CategorieId into gpProduit
                        join cat in db.Categories on gpProduit.Key equals cat.Id
                        select new
                        {
                            Cat = gpProduit.Key,
                            CatNom = cat.Nom,
                            Total = gpProduit.Count()
                        };
                        


            //var liste = from x in db.Produits
            //            group x by x.SeasonId
            //            into gpProduitParSeason
            //            select new { Season = gpProduitParSeason.Key, Total = gpProduitParSeason.Count() };
            //dgResultat.ItemsSource = liste.ToList();

            var liste2 = from x in db.Produits
                        group x by new { x.SeasonId, x.CategorieId }
                        into gpProduitParSeasonCategory
                        select new { Cat = gpProduitParSeasonCategory.Key.CategorieId, 
                            Season = gpProduitParSeasonCategory.Key.SeasonId, Total = gpProduitParSeasonCategory.Count() }               ;
            dgResultat.ItemsSource = liste.ToList();



        }

        private void GroupByLambda_Click(object sender, RoutedEventArgs e)
        {
            var liste = db.Produits.GroupBy(x => x.SeasonId).Select(groupSeason => new { groupSeason.Key, Total = groupSeason.Count()});

            var liste2 = db.Produits.GroupBy(x => new { x.SeasonId, x.CategorieId }).Select(gp1 => new { gp1.Key.CategorieId,gp1.Key.SeasonId, Total = gp1.Count() });

        }

        private void ExoGroup_Click(object sender, RoutedEventArgs e)
        {
            var liste = from p in db.Produits
                        group p by new { p.CategorieId, p.SeasonId }
                        into pgroupe
                        join c in db.Categories on pgroupe.Key.CategorieId equals c.Id
                        join s in db.Seasons on pgroupe.Key.SeasonId equals s.Id
                        select new { CatNom = c.Nom, s.NomSeason, Total = pgroupe.Count() };

            dgResultat.ItemsSource = liste.ToList();
        }

        private void Where_SQL_Click(object sender, RoutedEventArgs e)
        {
            var liste = from item in db.Produits where item.CategorieId == 2 select item;
            dgResultat.ItemsSource = liste.ToList(); 
        }

        private void WhereLambda_Click(object sender, RoutedEventArgs e)
        {
            var liste = db.Produits.Where(p => p.CategorieId == 2);

            // le produit dont l'id == 18 ?

            // var liste = db.Produits.Where(p => p.Id == 18);

            dgPrincipale.ItemsSource = liste.ToList();
            //var liste = db.Produits.Where(p => p.Id == 18);
            //if (liste != null)
            //{
            //    Produit produiteRechercher = liste.ToList().ElementAt(0);
            //}
            // plusieurs solution pour éviter la création de la liste et le if
            //

        }

        private void Single_Click(object sender, RoutedEventArgs e)
        {
            // on utilise le single si on est sûr que le produit recherché existe
            // et s'il est unique '

            Produit produitRecherche = db.Produits.Single(x => x.Id == 18);
            MessageBox.Show(produitRecherche.Designation);
            // si le produit n'existe pas une Exception sera levée
            // pour eviter l'exception, on utilise SingleOrDefault

            Produit produitRecherche2 = db.Produits.SingleOrDefault(x => x.Id == 18);
            if (produitRecherche2 != null)
            {
                MessageBox.Show(produitRecherche2.Designation);

            }

            // l'unique produit dont la catégorie est 2
            // Produit produitRecherche3 = db.Produits.SingleOrDefault(x => x.CategorieId == 1);


        }

        private void First_Click(object sender, RoutedEventArgs e)
        {

            // le premier element dont l'ID = 18
            Produit produitRecherche = db.Produits.First(x => x.CategorieId == 2);

            MessageBox.Show(produitRecherche.Designation);

            // Mais s'il ne trouve pas, une exception sera lévée
            // pur eviter l'exception FirstOrDefault

            Produit produitRecherche2 = db.Produits.FirstOrDefault(x => x.CategorieId == 12);

            // Le dernier produit de la catégorie 2 qui a été ajouté : LAST/LASTORDefault

            Produit DernierProduit = db.Produits.LastOrDefault(x => x.Id == 2);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            Produit lastProduit = db.Produits.ToList().LastOrDefault(x => x.CategorieId == 3);
            
            MessageBox.Show(lastProduit.Designation);


        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            Produit produitToFind = db.Produits.Find(17);
            MessageBox.Show(produitToFind.Description); 
        }
    }
}
