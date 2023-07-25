using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojistenychOsob
{
    /// <summary>
    /// Pojištěný, který bude v evidenci databáze pojištěných osob
    /// </summary>
    internal class PojistenaOsoba
    {
        /// <summary>
        /// Jméno pojištěné osoby
        /// </summary>
        public string Jmeno { get; private set; }

        /// <summary>
        /// Příjmení pojištěné osoby
        /// </summary>
        public string Prijmeni { get; private set; }

        /// <summary>
        /// Věk pojištěné osoby
        /// </summary>
        public int Vek { get; private set; }

        /// <summary>
        /// Telefonní číslo pojištěné osoby
        /// </summary>
        public string TelefoniCislo { get; private set; }

        /// <summary>
        /// Konstruktor pojištěné osoby s parametry
        /// </summary>
        /// <param name="jmeno">Jméno pojištěné osoby</param>
        /// <param name="prijmeni">Příjmení pojištěné´osoby</param>
        /// <param name="vek">Věk pojištěné osoby</param>
        /// <param name="telefon">Telefonní číslo pojištěné osoby</param>
        public PojistenaOsoba(string jmeno, string prijmeni, int vek, string telefoniCislo)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            TelefoniCislo = telefoniCislo;
        }

        /// <summary>
        /// Vypsání pojištěné osoby
        /// </summary>
        /// <returns>Vrácení jména, příjmení, věku a telefonu pohjištěné osoby</returns>
        public override string ToString()
        {
            _ = Vek.ToString();
            return Jmeno.PadRight(15) + Prijmeni.PadRight(15) + Vek.ToString().PadRight(10) + TelefoniCislo;
        }
    }
}

