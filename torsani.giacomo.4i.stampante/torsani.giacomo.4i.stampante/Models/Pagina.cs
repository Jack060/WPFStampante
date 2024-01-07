using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Xml.Linq;

namespace torsani.giacomo._4i.stampante
{
    internal class Pagina
    {
        //- 4 attributi CMYB che, se usata per stampare, consuma i serbatoi della stampante.
        public int Ciano { get; set; }
        public int Magenta { get; set; }
        public int Yellow { get; set; }
        public int Black { get; set; }
        //accetta colori specifici al massimo di valore 3
        public Pagina(int c, int b, int y, int m)
        {
            if (c >= 0 && c < 4 &&
                b >= 0 && b < 4 &&
                y >= 0 && y < 4 &&
                m >= 0 && m < 4)
            {
                this.Ciano = c;
                this.Magenta = m;
                this.Yellow = y;
                this.Black = b;
            }
            else
            {
                MessageBox.Show("ERRORE!! Quantità di colore richiesta troppo alta o negativa.");
            }
        }
        
        //crea una Pagina con colori random
        public Pagina()
        {
            Random rnd = new Random();
            Ciano = rnd.Next(4);
            Black = rnd.Next(4);
            Yellow = rnd.Next(4);
            Magenta = rnd.Next(4);
        }
    }
}
