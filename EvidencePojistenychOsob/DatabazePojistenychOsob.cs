using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EvidencePojistenychOsob
{
    /// <summary>
    /// Databáze pojištěných osob se vstupy a výstupy
    /// </summary>
    internal partial class DatabazePojistenychOsob
    {
        /// <summary>
        /// List pojištěných osob
        /// </summary>
        private readonly List<PojistenaOsoba> pojisteneOsoby;

        /// <summary>
        /// List pojištěných osob pro nový přístup
        /// </summary>
        public List<PojistenaOsoba> PojisteneOsoby
        {
            get { return pojisteneOsoby; }
        }

        /// <summary>
        /// Vytvoření pojištěné osoby do listu
        /// </summary>
        public DatabazePojistenychOsob()
        {
            pojisteneOsoby = new List<PojistenaOsoba>();
        }

        /// <summary>
        /// Funkce, která řeší zda uživatel nezadal nulovou hodnotu
        /// </summary>
        /// <returns></returns>
        static string OvereniVstupu(string zprava)
        {
            string? cteniHodnot = Console.ReadLine().Trim();
            while (string.IsNullOrWhiteSpace(cteniHodnot))
            {
                Console.WriteLine(zprava);
                cteniHodnot = Console.ReadLine();
            }
            return cteniHodnot;
        }

        /// <summary>
        /// Zařazení pojištěné osoby do listu
        /// </summary>
        public void VytvoreniPojisteneOsoby()
        {
            bool platnyVstup = false;
            string? telefoniCislo = "";
            
            Regex regex = MyRegex();

            ConsoleKeyInfo klavesa;

            Console.WriteLine("\nZADÁNÍ ÚDAJŮ PRO VYTVOŘENÍ NOVÉ POJIŠTĚNÉ OSOBY");

            Console.WriteLine("\nZadejte jméno pojišťované osoby: ");
            string? jmeno = OvereniVstupu("Nezadali jste žádné jméno. Zadejte znovu.");


            Console.WriteLine("Zadejte příjmení pojišťované osoby: ");
            string? prijmeni = OvereniVstupu("Nezadali jste žádné příjmení. Zadejte znovu.");

            Console.WriteLine("Zadejte věk pojištěné osoby: ");
            int vek = 0;
            while (vek <= 0)
            {
                var vstup = Console.ReadLine();

                if (int.TryParse(vstup, out int zadanyVek))
                {
                    if (zadanyVek >= 0)
                    {
                        vek = zadanyVek;
                    }
                    else
                    {
                        Console.WriteLine("Věk nesmí být záporné číslo.");
                    }
                }
                else
                {
                    Console.WriteLine("Neplatný vstup. Zadejte prosím platné celé číslo.");
                }
            }

            Console.WriteLine("Zadejte své telefoní číslo:");
            while (!platnyVstup)
            {
                telefoniCislo = Console.ReadLine();

                if (telefoniCislo != null && !string.IsNullOrWhiteSpace(telefoniCislo) && regex.IsMatch(telefoniCislo))
                {
                    platnyVstup = true;
                }
                else
                {
                    Console.WriteLine("Zadali jste neplatné telefoní číslo. Zadejte znovu.");
                }
            }

            PojistenaOsoba pojistenaOsoba = new(jmeno, prijmeni, vek, telefoniCislo);

            pojisteneOsoby.Add(pojistenaOsoba);

            Console.WriteLine("\nPřejete si zaevidovat další osobu [A/N]?");
            klavesa = Console.ReadKey();
            if (klavesa.Key == ConsoleKey.A)
            {
                VytvoreniPojisteneOsoby();
            }
            else
            {
                Console.WriteLine("\nPojištěnec/nci byl/i zaevidován/i");
            }
            
        }

        /// <summary>
        /// Regex výraz pro ověření telefoního čísla
        /// </summary>
        /// <returns></returns>
        [GeneratedRegex("^\\+?(\\d[\\d-. ]+)?(\\([\\d-. ]+\\))?[\\d-. ]+\\d$")]
        private static partial Regex MyRegex();
    }
    
}


