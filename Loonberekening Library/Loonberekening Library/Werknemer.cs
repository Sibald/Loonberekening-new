using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loonberekening_Library
{
    public class Werknemer
    {
        private String _voornaam;
        private String _familienaam;
        private DateTime _geboortedatum;
        private String _burgerlijkeStand;
        private int _aantalKinderen;
        private double _belastbaar;
        private String _IBAN;

        public Werknemer(String voornaam, String familienaam, int aantalKinderen, DateTime geboorteDatum, String burgerlijkeStand, String rekeningnummer)
        {
            _voornaam = voornaam;
            _familienaam = familienaam;
            _aantalKinderen = aantalKinderen;
            _geboortedatum = geboorteDatum;
            _burgerlijkeStand = burgerlijkeStand;
            _IBAN = rekeningnummer;
        }
        public Werknemer()
        {

        }
        public double Belastbaar
        {
            get { return _belastbaar; }
            set { _belastbaar = value; }
        }
        public string Voornaam
        {
            get { return _voornaam; }
            set { _voornaam = value; }
        }
        public string Familienaam
        {
            get { return _familienaam; }
            set { _familienaam = value; }
        }
        public int AantalKinderen
        {
            get { return _aantalKinderen; }
            set { _aantalKinderen = value; }
        }
        public String Iban
        {
            get { return _IBAN; }
            set { _IBAN = value; }
        }
        public DateTime GeboorteDatum
        {
            get { return _geboortedatum; }
            set { _geboortedatum = value; }
        }
        public string BurgerlijkeStand
        {
            get { return _burgerlijkeStand; }
            set { _burgerlijkeStand = value; }
        }
        public double getKinderAfslag()
        {
            double temp = 0;
            switch (_aantalKinderen)
            {
                case 1:
                    temp = 36.00;
                    break;
                case 2:
                    temp = 104.00;
                    break;
                case 3:
                    temp = 275.00;
                    break;
                case 4:
                    temp = 482.00;
                    break;
                case 5:
                    temp = 713.00;
                    break;
                case 6:
                    temp = 944.00;
                    break;
                case 7:
                    temp = 1174.00;
                    break;
                case 8:
                    temp = 1428.00;
                    break;
                default:
                    temp = 0;
                    break;
            }
            return temp;
        }
    }
}