using ProcedureStockee.Model;
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

namespace ProcedureStockee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Produit2DBEntities db = new Produit2DBEntities(); 

        public MainWindow()
        {
            InitializeComponent();
            Init(); 
        }

        private void Init()
        {
            dgView.ItemsSource = db.VRequetes.ToList(); 
        }

        private void Procedure_Click(object sender, RoutedEventArgs e)
        {
            db.AjoutCategorie("my new categorie");
            MessageBox.Show("Create ok!"); 
        }
    }
}
