using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loonberekening_Library;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //variabelen
            String invoer;
            int keuze = 0;
            bool controle = false;
            String voornaam = "", familienaam = "";
            int aantalKinderen = 0;
            DateTime geboorteDatum;
            String burgerlijkeStand = "";
            double uurloon;
            String rekeningNummer = "";
            double aantalUren = 0;
            double maandloon;
            String rekeningnummer = "";

            
            //Openingsbericht
            Console.WriteLine("Welkom in het Loonberekeningssysteem.");
            Console.WriteLine();
            Console.WriteLine("Gelieve alle gegevens die gevraagd worden in te geven.");
            
            //Voornaam controle
            do
            {
                Console.Write("Voornaam: ");
                invoer = Console.ReadLine();
                controle = Int32.TryParse(invoer, out keuze);
                if (controle == false)
                {
                    voornaam = invoer;
                }
            } while (controle == true);

            //Familienaam controle
            do
            {
                Console.Write("Familienaam: ");
                invoer = Console.ReadLine();
                controle = Int32.TryParse(invoer, out keuze);
                if (controle == false)
                {
                    familienaam = invoer;
                }
            } while (controle == true);
            
            //Aantal Kinderen controle
            do
            {
                Console.Write("Aantal Kinderen: ");
                invoer = Console.ReadLine();
                controle = Int32.TryParse(invoer, out aantalKinderen);
            } while (controle == false);

            //Geboortedatum ingeven
            do
            {
                Console.Write("Geboortedatum: ");
                invoer = Console.ReadLine();
                controle = DateTime.TryParse(invoer, out geboorteDatum);
                if (geboorteDatum.Year != 0)
                {
                    controle = true;
                }
                else
                {
                    controle = false;
                }
            } while (controle == false);

            //RekeningNummer ingeven met controle
            do
            {
                Console.Write("IBAN: ");
                invoer = Console.ReadLine();
                controle = Int32.TryParse(invoer, out keuze);
                if (controle == false)
                {
                    rekeningNummer = invoer;
                }
                ControleIban(ref rekeningNummer);

                if (ControleIban(ref rekeningNummer) == true)
                {
                    Console.WriteLine("Bedankt voor het invullen van uw IBAN nummer");
                }
                else
                {
                    Console.WriteLine("U heeft een fout gemaakt. Gelieve het rekeningnummer nog eens te controleren.");
                    controle = true;
                }

            } while (controle == true);
            do
            {
                Console.WriteLine("Burgerlijke Stand:");
                Console.WriteLine("1. Gehuwd.");
                Console.WriteLine("2. Alleenstaand");
                Console.WriteLine("");
                invoer = Console.ReadLine();
                controle = Int32.TryParse(invoer, out keuze);
                if (keuze == 1)
                {
                    burgerlijkeStand = "Gehuwd";
                }
                if (keuze == 2)
                {
                    burgerlijkeStand = "Alleenstaand";
                }
            } while (controle == false);

            controle = false;
            //contructor met elementen
            Werknemer werknemer = new Werknemer(voornaam, familienaam, aantalKinderen, geboorteDatum, burgerlijkeStand, rekeningnummer);
            
            
            
            //Keuze arbeider of bediende met controle
            do
            {
                Console.Clear();
                
                Console.WriteLine("Wilt u het loon van een arbeider of bediende berekenen?");
                Console.WriteLine();
                Console.WriteLine("1. Arbeider.");
                Console.WriteLine("2. Bediende.");
                invoer = Console.ReadLine();
                controle = Int32.TryParse(invoer, out keuze);

                if (controle == false)
                {
                    Console.WriteLine("Gelieve een het juiste cijfer in te voeren.");
                    Console.ReadKey();
                }
            } while (controle == false);
            Console.Clear();
            switch (keuze)
            {
//Abreider
                case 1:
                    do
                    {
                        Console.Write("Geef het uurloon in van uw arbeider: ");
                        invoer = Console.ReadLine();
                        controle = double.TryParse(invoer, out uurloon);
                    } while (controle == false);

                    do
                    {
                        Console.Write("Geef het aantal uur in dat de arbeider gewerkt heeft: ");
                        invoer = Console.ReadLine();
                        controle = double.TryParse(invoer, out aantalUren);
                    } while (controle == false);

                    Arbeider arbeider = new Arbeider(aantalUren, uurloon);

                    Console.WriteLine("Brutoloon: {0}", arbeider.getBruto());
                    Console.WriteLine("-RSZ: {0}", arbeider.getRsz());
                    Console.WriteLine("Belastbaar: {0}", arbeider.getBelastbaar());
                    Console.WriteLine("Bedrijfsvoorheffing:");
                    Console.WriteLine("Kinderen: {0}", werknemer.getKinderAfslag());
                    Console.WriteLine();
                    Console.WriteLine("NettoLoon: {0}",arbeider.getNettoLoon());

                    Console.WriteLine();
                    break;
                    
                //Bediende
                case 2:
                    

                    
                    Console.WriteLine();
                    do
                    {
                        Console.Write("Gelieve het maandloon van uw bediende in te geven: ");
                        invoer = Console.ReadLine();
                        controle = double.TryParse(invoer, out maandloon);
                    } while (controle == false);

                    Bediende bediende = new Bediende(maandloon);

                    Console.WriteLine("Brutoloon: {0}", bediende.getBruto());
                    Console.WriteLine("-RSZ: {0}", bediende.getRsz());
                    Console.WriteLine("Belastbaar: {0}", bediende.getBelastbaar());
                    Console.WriteLine("Bedrijfsvoorheffing:");
                    Console.WriteLine("Kinderen: {0}", werknemer.getKinderAfslag());
                    Console.WriteLine();
                    Console.WriteLine("NettoLoon: {0}", bediende.getNettoLoon());

                    Console.WriteLine();

                    break;
                default:
                    break;
            }
            
            Console.WriteLine();
            Console.WriteLine("Bedankt voor het gebruiken van dit programma!");
            Console.ReadKey();
        }
        public static bool ControleIban(ref String rekeningNummer)
        {
            string invoer = "";
            Int64 berekening = 0;
            int controleCijfer = 0;
            int lengte = 0;
            Int64 nummer = 0;
            bool controle;
            Int64 temp = 0;
            string controleLand = "";


            Verwijderen_Spaties(ref rekeningNummer);

            invoer = rekeningNummer;

            Console.WriteLine(invoer);
            Console.ReadKey();
            lengte = invoer.Length;

            nummer = Convert.ToInt64(invoer.Substring(4, 10));
            controleCijfer = Convert.ToInt32(invoer.Substring(13, 3));
            controle = Int64.TryParse(invoer.Substring(2, 14), out temp);
            controleLand = invoer.Substring(0, 2);

            berekening = nummer % 97;
            if (berekening == controleCijfer && lengte == 16 && controleLand == "BE")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static string Verwijderen_Spaties(ref String rekeningNummer)
        {
            string karakter;
            string zSpatie = "";

            for (int positie = 0; positie < rekeningNummer.Length; positie++)
            {
                karakter = rekeningNummer.Substring(positie, 1);
                if (karakter == " ")
                {
                    karakter = "";
                }
                zSpatie = zSpatie + karakter;
            }
            rekeningNummer = zSpatie;
            return rekeningNummer;
        }
    }
}
