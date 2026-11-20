using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Konyvek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Konyvek> konyvek = new List<Konyvek>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void konyvekbetoltese(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Összesen" + konyvek.Count() + "könyv van");
        }

        private void konyvekszama(object sender, RoutedEventArgs e)
        {
            konyvek.Add(new Konyvek("sas","sas",11,"sci-fi",true));
            konyvek.Add(new Konyvek("sas2", "sas2", 110, "sci-fi", false));
        }

        private void konyvhossz(object sender, RoutedEventArgs e)
        {
            Konyvek leghosszabb = konyvek[0];
            foreach (var item in konyvek)
            {
                if (item.oldalszam > leghosszabb.oldalszam)
                { 
                    leghosszabb = item;
                }
            }
            MessageBox.Show($"A leghosszabb könyv címe: {leghosszabb.cim}, oldalszáma: {leghosszabb.oldalszam}");
        }

        private void Atlag(object sender, RoutedEventArgs e)
        {
            int osszeg = 0;
            foreach (var item in konyvek)
            {
                osszeg += item.oldalszam;
            }
            double atlag = osszeg / (double)konyvek.Count();
            MessageBox.Show($"Átlagos könyvoldalak száma: {atlag}");
        }

        private void elerhetokonyvek(object sender, RoutedEventArgs e)
        {
            List<Konyvek> CsakElerheto = new List<Konyvek>();
            foreach (var item in CsakElerheto)
            {
                if (item.elerheto == true)
                {
                    CsakElerheto.Add(item);
                }
            }
            dGrid.ItemsSource = CsakElerheto;
        }

        private void csakcim(object sender, RoutedEventArgs e)
        {
            List<Cim> konyvcimek = new List<Cim>();
            foreach (var item in konyvek)
            {
                Cim c = new Cim(item.cim);
                konyvcimek.Add(c);
                dGrid.ItemsSource = konyvcimek;
            }
        }

        private void rendezesszerzoszerint(object sender, RoutedEventArgs e)
        {
            List<Konyvek> rendezett = konyvek.OrderBy(k => k.szerzo).ToList();
            dGrid.ItemsSource = rendezett;

        }
        private void selectedchange(object sender, SelectionChangedEventArgs e)
        {
            if (dGrid.SelectedItem is Konyvek)
            {
                progressbar.Value = ((Konyvek)dGrid.SelectedItem).oldalszam;

            }
            else 
            {
                MessageBox.Show($"A kiválasztott nem könyv");
            }
        }
    }
}