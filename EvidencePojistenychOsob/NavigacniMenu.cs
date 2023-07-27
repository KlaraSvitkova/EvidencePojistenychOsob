using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojistenychOsob
{
    /// <summary>
    /// Hlavní menu a navigace v aplikaci pojištěných osob
    /// </summary>
    internal class NavigacniMenu
    {
        /// <summary>
        /// Konstruktor pro užívání Listu
        /// </summary>
        private readonly DatabazePojistenychOsob evidence = new();

        /// <summary>
        /// Proměnná pro dotazy na List
        /// </summary>
        private readonly DotazyNaDatabazi databaze;

        /// <summary>
        /// Konstruktor umožnujícíc používání dotazů
        /// </summary>
        public NavigacniMenu()
        {
            databaze = new DotazyNaDatabazi(evidence);
        }

        /// <summary>
        /// Základní menu
        /// </summary>
        public static void VytejteVMenu()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("\tEVIDENCE POJIŠTĚNÝCH OSOB");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("\n VYBERTE Z NÁSLEDUJÍCÍC NABÍDKY:");
            Console.WriteLine("\t1 - Přidat novou pojištěnou osobu");
            Console.WriteLine("\t2 - Vypsat všechny pojištěné osoby");
            Console.WriteLine("\t3 - Vyhledat pojištěnou osobu");
            Console.WriteLine("\t4 - Konec");
        }

        /// <summary>
        /// Úroveň výběru vyhledání pojištěných osob
        /// </summary>
        public static void UrovenVyberu3()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("\tVYHLEDÁNÍ POJIŠTĚNÝCH OSOB");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("\nVYBERTE Z NÁSLEDUJÍCÍ NABÍDKY:");
            Console.WriteLine("\t1 - Vyhledat podle jména");
            Console.WriteLine("\t2 - Vyhledat podle příjmení");
            Console.WriteLine("\t3 - Vyhledat podle jména i příjmení");
            Console.WriteLine("\t4 - Návrat do menu");
        }

        /// <summary>
        /// Komunikace s uživatelem na základě jeho výběru
        /// </summary>
        public void VolbaAkceZMenu()
        {
            char volbaHlavnihoMenu;
            char volbaPodMenu;

            do
            {
                volbaHlavnihoMenu = Console.ReadKey().KeyChar;

                switch (volbaHlavnihoMenu)
                {
                    case '1':
                        PomocnaTrida.Odradkuj();
                        evidence.VytvoreniPojisteneOsoby();
                        PomocnaTrida.VycisteniConsolePauza(1);
                        VytejteVMenu();
                        VolbaAkceZMenu();
                        break;

                    case '2':
                        PomocnaTrida.Odradkuj();
                        databaze.VypisVsechnyPojisteneOsoby();
                        PomocnaTrida.StiskniEnter();
                        Console.Clear();
                        VytejteVMenu();
                        VolbaAkceZMenu();
                        break;

                    case '3':
                        Console.Clear();
                        UrovenVyberu3();

                        volbaPodMenu = Console.ReadKey().KeyChar;

                        switch (volbaPodMenu)
                        {
                            case '1':
                                PomocnaTrida.Odradkuj();
                                databaze.VyhledaniPodleJmena();
                                PomocnaTrida.StiskniEnter();
                                Console.Clear();
                                VytejteVMenu();
                                VolbaAkceZMenu();
                                break;

                            case '2':
                                PomocnaTrida.Odradkuj();
                                databaze.VyhledaniPodlePrijmeni();
                                PomocnaTrida.StiskniEnter();
                                Console.Clear();
                                VytejteVMenu();
                                VolbaAkceZMenu();
                                break;

                            case '3':
                                PomocnaTrida.Odradkuj();
                                databaze.VyhledaniPodleJmenaIPrijmeni();
                                PomocnaTrida.StiskniEnter();
                                Console.Clear();
                                VytejteVMenu();
                                VolbaAkceZMenu();
                                break;

                        }
                        break;

                }
                break;

            } while (volbaHlavnihoMenu != '4');

        }
        /// <summary>
        /// Zkrácení výpisu do programu pro výpis do konzole
        /// </summary>
        public void Menu()
        {
            VytejteVMenu();
            VolbaAkceZMenu();
        }
    }
}
