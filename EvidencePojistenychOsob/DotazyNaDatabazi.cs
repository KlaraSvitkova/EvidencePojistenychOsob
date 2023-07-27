using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojistenychOsob
{
    /// <summary>
    /// Dotazy na databázi pojištěných osob
    /// </summary>
    internal class DotazyNaDatabazi
    {
        /// <summary>
        /// List s pojištěnými osobami s proměnnými pro třídu
        /// </summary>
        private readonly List<PojistenaOsoba> pojisteneOsoby;

        /// <summary>
        /// Konstruktor pro použití databáze ze třídy DatabazePojistenychOsob
        /// </summary>
        /// <param name="databaze">Kolekce, kam se bude volat databáze</param>
        public DotazyNaDatabazi(DatabazePojistenychOsob databaze)
        {
            pojisteneOsoby = databaze.PojisteneOsoby;
        }

        /// <summary>
        /// Vypíše všechny pojištěné osoby které jsou evidované
        /// </summary>
        public void VypisVsechnyPojisteneOsoby()
        {
            Console.WriteLine("Výpis pojištěných osob: {0}", pojisteneOsoby.Count);
            PomocnaTrida.HlavickaProVypis();
            foreach (var s in pojisteneOsoby)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Vyhledání pojištěné osoby podle jména
        /// </summary>
        public void VyhledaniPodleJmena()
        {
            string? hledaneJmeno = "";
            var pojistenaOsobaPodleJmena = from j in pojisteneOsoby
                                           where (j.Jmeno.ToLower() == hledaneJmeno)
                                           orderby j.Jmeno
                                           select j;

            Console.WriteLine("\n\t --VYHLEDÁNÍ POJIŠTĚNÉ OSOBY PODLE JMÉNA-- ");
            Console.WriteLine("Zadejte jméno pojištěné osoby:");
            hledaneJmeno = Console.ReadLine().ToLower().Trim();
            while (string.IsNullOrEmpty(hledaneJmeno))
            {
                PomocnaTrida.PrazdnyRetezec();
                hledaneJmeno = Console.ReadLine().ToLower().Trim();
            }

            Console.WriteLine("Nalezená pojištěná osoba: {0}", pojistenaOsobaPodleJmena.Count());
            PomocnaTrida.HlavickaProVypis();
            foreach (var s in pojistenaOsobaPodleJmena)
            {
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Vyhledání pojištěné osoby podle příjmení
        /// </summary>
        public void VyhledaniPodlePrijmeni()
        {
            string? hledanePrijmeni = "";
            var pojistenaOsobaPodlePrijmeni = from p in pojisteneOsoby
                                              where (p.Prijmeni.ToLower() == hledanePrijmeni)
                                              orderby p.Jmeno
                                              select p;

            Console.WriteLine("\n\t --VYHLEDÁNÍ POJIŠTĚNÉ OSOBY PODLE PŘÍJMENÍ-- ");
            Console.WriteLine("Zadejte příjmení pojištěné osoby:");
            hledanePrijmeni = Console.ReadLine().ToLower().Trim();
            while (string.IsNullOrEmpty(hledanePrijmeni))
            {
                PomocnaTrida.PrazdnyRetezec();
                hledanePrijmeni = Console.ReadLine().ToLower().Trim();
            }

            Console.WriteLine("\nNalezená pojištěná osoba: {0}", pojistenaOsobaPodlePrijmeni.Count());
            PomocnaTrida.HlavickaProVypis();
            foreach (var s in pojistenaOsobaPodlePrijmeni)
            {
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Vyhledání pojištěné ospoby podle jména i příjmní
        /// </summary>
        public void VyhledaniPodleJmenaIPrijmeni()
        {
            string? hledaneJmeno = "";
            string? hledanePrijmeni = "";
            var pojistenaosobaPodleJmenaIPrijmeni = from o in pojisteneOsoby
                                            where (o.Prijmeni.ToLower() == hledanePrijmeni && o.Jmeno.ToLower() == hledaneJmeno)
                                            orderby o.Jmeno, o.Prijmeni
                                            select o;

            Console.WriteLine("\n\t --VYHLEDÁVÁNÍ POJIŠTĚNÉ OSOBY PODLE JMÉNA A PŘÍJMENÍ-- ");
            Console.WriteLine("Zadejte jméno pojištěné osoby:");
            hledaneJmeno = Console.ReadLine().Trim().ToLower();
            while (string.IsNullOrWhiteSpace(hledaneJmeno))
            {
                PomocnaTrida.PrazdnyRetezec();
                hledaneJmeno = Console.ReadLine().Trim().ToLower();
            }
            Console.WriteLine("Zadejte příjmení pojištěné osoby:");
            hledanePrijmeni = Console.ReadLine().Trim().ToLower();
            while (string.IsNullOrWhiteSpace(hledanePrijmeni))
            {
                PomocnaTrida.PrazdnyRetezec();
                hledanePrijmeni = Console.ReadLine().Trim().ToLower();
            }

            Console.WriteLine("\nNalezené pojištěné osoby: {0}", pojistenaosobaPodleJmenaIPrijmeni.Count());
            PomocnaTrida.HlavickaProVypis();
            foreach (var s in pojistenaosobaPodleJmenaIPrijmeni)
            {
                Console.WriteLine(s);
            }
        }
    }
}
