using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EvidencePojistenychOsob
{
    /// <summary>
    /// Textová předloha pro použití v programu
    /// </summary>
    internal class PomocnaTrida
    {
        /// <summary>
        /// Výpis při zadání prázdné hodnoty, použití ve třída DotazyNaDatabazi
        /// </summary>
        public static void PrazdnyRetezec()
        {
            Console.WriteLine("Nezadali jste žádný záznam. Prosím zadejte znovu.");
        }

        /// <summary>
        /// Odřádkování
        /// </summary>
        public static void Odradkuj()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Vyčistění a uspání konzoole na určitou dobu, použití ve třídě NavigacniMenu
        /// </summary>
        /// <param name="casUspani"></param>
        public static void VycisteniConsolePauza(int casUspani)
        {
            Thread.Sleep(casUspani);
            Console.Clear();
        }

        /// <summary>
        /// Pro pokračování je třeba zmáčknouj entr, pokud se uživatel splete je vyzván znovu, použití ve třídě NavigacniMenu
        /// </summary>
        public static void StiskniEnter()
        {
            ConsoleKeyInfo klavesa;

            Console.WriteLine("\nPro pokračování stiskni Enter.");
            klavesa = Console.ReadKey();
            Console.WriteLine();
            while (klavesa.Key != ConsoleKey.Enter)
            {
                Console.WriteLine("Nestiskli jste Enter.");
                klavesa = Console.ReadKey();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Hlavička pro výpis, použití ve třídě DotazyNaDatabazi
        /// </summary>
        public static void HlavickaProVypis()
        {
            Console.WriteLine("\n{0}{1}{2}\t{3}", "JMÉNO".PadRight(15), "PŘÍJMENÍ".PadRight(15), "VĚK".PadRight(8), "TELEFONNÍ ČÍSLO\n");
        }

    }
}
