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
            var box = new Box("olbia", "via cagliari", "09010", 56, 12);
            var app1 = new Appartamento("sinnai", "via col venticello", "09090", 50, 4, 2);
            var agenzia = new Agenzia();
            agenzia.Immobili.Add(app);
            agenzia.Immobili.Add(box);
            agenzia.Immobili.Add(app1);
            Console.WriteLine("inserisci la chiave");
            var key = Console.ReadLine();
            var immobiliTrovati = agenzia.SearcByKey(key);
            foreach (var item in immobiliTrovati)
            {
                item.PrintDescription();
            }

            Console.ReadLine();
        }
    }
    public class Agenzia
    {
        public List<Immobile> Immobili { get; set; } = new List<Immobile>();
        public List<Immobile> SearcByKey(string value)
        {
            return Immobili.Where(a => a.ContainsKey(value)).ToList();
        }

        public List<Immobile> SearchByCittà(string città)
        {
            return Immobili.Where(x => x.Città.Contains(città)).ToList();
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

        public virtual bool ContainsKey(string value)
        {
            if (Città.Contains(value)) return true;
            if (Indirizzo.Contains(value)) return true;
            if (Cap.Contains(value)) return true;
            if (Superficie.ToString().Contains(value)) return true;
            return false;
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

        public override bool ContainsKey(string value)
        {
            if(base.ContainsKey(value)) return true;
            if (PostiAuto.ToString().Contains(value)) return true;
            return false;
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

        public override bool ContainsKey(string value)
        {
            if (base.ContainsKey(value)) return true;
            if (Vani.ToString().Contains(value)) return true;
            if (Bagni.ToString().Contains(value)) return true;
            return false;
        }
    }

}
