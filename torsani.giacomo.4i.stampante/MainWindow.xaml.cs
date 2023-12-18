using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using torsani.giacomo._4i.stampante.Models;

namespace torsani.giacomo._4i.stampante
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stampante s = new Stampante();
        public MainWindow()

        {
            InitializeComponent();

        }
        private void Torsani_Window_Loaded(object sender, RoutedEventArgs e)
        {
            Serbblack.Text = Convert.ToString(s.serbatoioBlack) + "%";
            Serbmagenta.Text = Convert.ToString(s.serbatoioMagenta) + "%";
            Serbyellow.Text = Convert.ToString(s.serbatoioYellow) + "%";
            Serbciano.Text = Convert.ToString(s.serbatoioCiano) + "%";
            StatoCarta.Text = Convert.ToString(s.GetFogli());
        }

        private void InsCarta_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnStampa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int black = Convert.ToInt32(InsStampaBlack.Text);
                int magenta = Convert.ToInt32(InsStampaMagenta.Text);
                int yellow = Convert.ToInt32(InsStampaYellow.Text);
                int ciano = Convert.ToInt32(InsStampaCiano.Text);
                Pagina p = new Pagina(black, magenta, yellow, ciano);
                s.Stampa(p);
                Serbblack.Text = Convert.ToString(s.serbatoioBlack) + "%";
                Serbmagenta.Text = Convert.ToString(s.serbatoioMagenta) + "%";
                Serbyellow.Text = Convert.ToString(s.serbatoioYellow) + "%";
                Serbciano.Text = Convert.ToString(s.serbatoioCiano) + "%";
                StatoCarta.Text = Convert.ToString(s.GetFogli());
            }
            catch (Exception err) {
                MessageBox.Show($"GROSSO ERRORE {err}");
            }
        }

        private void BtnStampaRnd_Click(object sender, RoutedEventArgs e)
        {
            Pagina p = new Pagina();
            s.Stampa(p);
            Serbblack.Text = Convert.ToString(s.serbatoioBlack) + "%";
            Serbmagenta.Text = Convert.ToString(s.serbatoioMagenta) + "%";
            Serbyellow.Text = Convert.ToString(s.serbatoioYellow) + "%";
            Serbciano.Text = Convert.ToString(s.serbatoioCiano) + "%";
            StatoCarta.Text = Convert.ToString(s.GetFogli());
        }

        private void BtnInsCarta_Click(object sender, RoutedEventArgs e)
        {
            int nFogli = Convert.ToInt32(InsCarta.Text);
            if (nFogli + s.GetFogli() < 200)
            {
                s.AggiungiCarta(Convert.ToInt16(InsCarta.Text));
                StatoCarta.Text = Convert.ToString(s.GetFogli());
            }
            else
            {
                MessageBox.Show("LA CARTA CHE VUOI METTERE E' ECCESSIVA!");
            }
        }

        private void BtnSostNero_Click(object sender, RoutedEventArgs e)
        {
            s.SostituisciColore(Colore.black);
            Serbblack.Text = Convert.ToString(s.serbatoioBlack) + "%";
        }

        private void BtnSostMagenta_Click(object sender, RoutedEventArgs e)
        {
            s.SostituisciColore(Colore.magenta);
            Serbmagenta.Text = Convert.ToString(s.serbatoioMagenta) + "%";
        }

        private void BtnSostYellow_Click(object sender, RoutedEventArgs e)
        {
            s.SostituisciColore(Colore.yellow);
            Serbyellow.Text = Convert.ToString(s.serbatoioYellow) + "%";
        }

        private void BtnSostCiano_Click(object sender, RoutedEventArgs e)
        {
            s.SostituisciColore(Colore.ciano);
            Serbciano.Text = Convert.ToString(s.serbatoioCiano) + "%";
        }

        private void InsStampaMagenta_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}