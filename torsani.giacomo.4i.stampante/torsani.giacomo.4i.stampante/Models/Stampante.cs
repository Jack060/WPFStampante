using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace torsani.giacomo._4i.stampante.Models
{
    internal class Stampante
    {
        //- 4 serbatoi di colore: CMYB e un cassetto di fogli(tutte property int)
        public int serbatoioCiano {  get; set; }
        public int serbatoioMagenta { get; set; }
        public int serbatoioYellow { get; set; }
        public int serbatoioBlack { get; set; }
        public int Fogli {  get; set; }
        public Stampante()
        {
            serbatoioCiano = serbatoioMagenta = serbatoioYellow = serbatoioBlack = 100;
            Fogli = 200;
        }

        //torna false, se l'inchiostro non è sufficiente per stampare
        public bool Stampa(Pagina p)
        {
            if (Fogli > 1 &&
            serbatoioCiano >= p.Ciano &&
            serbatoioMagenta >= p.Magenta &&
            serbatoioYellow >= p.Yellow &&
            serbatoioBlack >= p.Black)
            {
                serbatoioCiano = serbatoioCiano - p.Ciano;
                serbatoioMagenta = serbatoioMagenta - p.Magenta;
                serbatoioYellow = serbatoioYellow - p.Yellow;
                serbatoioBlack = serbatoioBlack - p.Black;
                Fogli--;
                return true;
            }
            else
            {
                MessageBox.Show("ERRORE, MANCA QUALCOSA PER STAMPARE");
                return false;
            }      
        }

        //che aggiunge fogli fino ad un max di 200
        public bool AggiungiCarta(int addFogli)
        {
            if (Fogli + addFogli <= 200)
            {
                Fogli = Fogli + addFogli;
                return true;
            }
            else
            {
                return false;
            }
        }

        //rimpiazza un serbatoio di inchiostro e lo riporta a 100
        public void SostituisciColore(Colore c)
        {
            switch (c)
            {
                case Colore.ciano:
                    serbatoioCiano = 100;
                    break;
                case Colore.magenta:
                    serbatoioMagenta = 100;
                    break;
                case Colore.yellow:
                    serbatoioYellow = 100;
                    break;
                case Colore.black:
                    serbatoioBlack = 100;
                    break;
                default: throw (new Exception());
            }
        }
    }
}
