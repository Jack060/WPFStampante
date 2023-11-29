using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace torsani.giacomo._4i.stampante
{
/*

*/
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
            Ciano = c;
            Magenta = m;
            Yellow = y;
            Black = b;
        }
        
        //crea una Pagina con colori random
        public Pagina()
        {
            Random rnd = new Random();
            Ciano = rnd.Next(0, 4);
            Black = rnd.Next(0, 4);
            Yellow = rnd.Next(0, 4);
            Magenta = rnd.Next(0, 4);
        }
    }
}
