using CodeFirstManyToManyCas1.Model;
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

namespace CodeFirstManyToManyCas1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        private ClubDBContext db = new ClubDBContext(); 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TestInsertManyToMany_Click(object sender, RoutedEventArgs e)
        {
            Adherent adherent1 = new Adherent();
            adherent1.Nom = "Tom";
            adherent1.Adresse = "Adresse1";

            Adherent adherent2 = new Adherent{Nom = "Thomas", Adresse = "Adress 2" };
            adherent2.Nom = "Thomas";
            adherent2.Adresse = "Adresse2";

            Activite activite1 = new Activite();
            activite1.Nom = "Natation";

            Activite activite2 = new Activite{ Nom = "Foot" };
            Activite activite3 = new Activite{ Nom = "Basket" };

            List<Activite> listeActivities = new List<Activite>();
            listeActivities.Add(activite1);
            listeActivities.Add(activite2); 
            listeActivities.Add(activite3);

            adherent1.Activites = listeActivities; 

            adherent2.Activites = new List<Activite>();
            adherent2.Activites.Add(activite2);
            adherent2.Activites.Add(activite3);


            Adherent adh3 = new Adherent { Nom = "Adh3", Adresse = "Adresse3" };
            adh3.Activites = new List<Activite> { activite1, activite2 };

            Adherent adh4 = new Adherent { Nom = "Adh4", Adresse = "Adresse4", 
                                            Activites = new List<Activite> { activite1, activite2, activite3 } };
            db.Adherents.Add(adherent1);
            db.Adherents.Add(adherent2);
            db.Adherents.Add(adh3);
            db.Adherents.Add(adh4);

            db.SaveChanges(); 
            
        }
    }
}
