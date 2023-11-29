using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace torsani.giacomo._4i.stampante.Models
{
    internal class Stampante
    {

        //- 4 serbatoi di colore: CMYB e un cassetto di fogli(tutte property int)
        public int Ciano { get; set; }
        public int Magenta { get; set; }
        public int Yellow { get; set; }
        public int Black { get; set; }
        public int Fogli { get; set; }

        public Stampante()
        {

            Ciano = Magenta = Yellow = Black = 100;
            Fogli = 200;
        }

        //torna false, se l'inchiostro non è sufficiente per stampare
        public bool Stampa(Pagina p)
        {
            if (Fogli > 1 &&
                Ciano >= p.Ciano &&
                Magenta >= p.Magenta &&
                Yellow >= p.Yellow &&
                Black >= p.Black)
            {
                Ciano = -p.Ciano;
                Magenta = -p.Magenta;
                Yellow = -p.Yellow;
                Black = -p.Black;
                Fogli--;
                return true;
            }

            return false;
        }
        //che torna la quantità di inchiostro presente nei 4 serbatoi.
        public int StatoInchiostro(int colore)
        {
            switch (colore)
            {
                case 0: return Ciano;
                case 1: return Magenta;
                case 2: return Yellow;
                case 3: return Black;
                default: throw (new Exception());
            }
        }

        
        //che aggiunge fogli fino ad un max di 200
        public bool AggiungiCarta(int addFogli)
        {
            if (Fogli + addFogli <= 200)
            {
                Fogli = Fogli + addFogli;
            }
            else
            {
                return false;
            }
            return true;
        }
        //mi ritorna la quantità di fogli nel cassetto
        public int getFogli()
        {
            return Fogli;
        }
        //rimpiazza un serbatoio di inchiostro e lo riporta a 100
        public void SostituisciColore(int c)
        {
            switch (c)
            {
                case 0:
                    Ciano = 100;
                    break;
                case 1:
                    Magenta = 100;
                    break;
                case 2:
                    Yellow = 100;
                    break;
                case 3:
                    Black = 100;
                    break;
            }
        }
    }
}
