using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Si vuole progettare un’applicazione in grado di gestire un’agenzia immobiliare. 
            Gli immobili sono caratterizzati da un codice alfanumerico, indirizzo, cap, città e da una superficie espressa 
            in mq attraverso un numero intero. L’agenzia gestisce diverse tipologie di immobili: Box, Appartamenti e Ville.

Per i box è riportato il numero di posti auto. Per gli appartamenti è riportato in numero di vani e il numero di bagni, 
            e per le ville è previsto, in aggiunta, la dimensione in mq di giardino rispetto all’appartamento.

Per gli immobili è necessario definire un metodo che restituisca, in un formato stringa a piacere, il tipo di immobile e 
            tutte le corrispondenti proprietà.

L’agenzia deve poter eseguire delle ricerche specificando una chiave. Per le ricerche si considera l’operatore di contenimento, 
            cioè si verifica se la chiave di ricerca è contenuta all’interno di una proprietà dell’oggetto. 
            Il risultato della ricerca è visualizzato a video stampando la scheda dell’immobile corrispondente.
            */

            //
            var app = new Appartamento("cagliari", "via col vento", "09090", 34, 4, 2);
            var box = new Box("olbia", "via degli olmi", "09010", 56, 12);
            var agenzia = new Agenzia();
            agenzia.Immobili.Add(app);
            agenzia.Immobili.Add(box);

            Console.ReadLine();
        }
    }
    public class Agenzia
    {
        public List<Immobile> Immobili { get; set; } = new List<Immobile>();
        public Immobile SearcByKey(string value)
        {

        }

    }
    public abstract class Immobile
    {
        //public Guid Codice { get; set; } = new Random Guid();
        public string Città { get; set; }
        public string Indirizzo { get; set; }
        public string Cap { get; set; }
        public int Superficie { get; set; }
        protected abstract string Type { get; }

        public Immobile(string città, string indirizzo, string cap, int superficie)
        {
            Città = città;
            Indirizzo = indirizzo;
            Cap = cap;
            Superficie = superficie;
        }
        public virtual void PrintDescription()
        {
            Console.WriteLine($"Tipologia: {Type}");
            Console.WriteLine($"Città: {Città}");
            Console.WriteLine($"Indirizzo: {Indirizzo}");
            Console.WriteLine($"Cap: {Cap}");
            Console.WriteLine($"Metri quadri superificie: {Superficie}");
        }


    }

    public class Box : Immobile
    {
        public int PostiAuto { get; set; }
        protected override string Type { get { return "Box"; } }
        public Box(string città, string indirizzo, string cap, int superficie, int postiAuto) : base(città, indirizzo, cap, superficie)
        {
            PostiAuto = postiAuto;
        }

        public override void PrintDescription()
        {
            base.PrintDescription();
            Console.WriteLine($"Numero posti auto: {PostiAuto}");
        }

    }

    public class Appartamento : Immobile
    {
        public int Vani { get; set; }
        public int Bagni { get; set; }
        protected override string Type { get { return "Appartamento"; } }

        public Appartamento(string città, string indirizzo, string cap, int superficie, int vani, int numeroBagni)
            : base(città, indirizzo, cap, superficie)
        {
            Vani = vani;
            Bagni = numeroBagni;
        }

        public override void PrintDescription()
        {
            base.PrintDescription();
            Console.WriteLine($"Numero vani: {Vani}");
            Console.WriteLine($"Numero Bagni: {Bagni}");
        }
    }

}
