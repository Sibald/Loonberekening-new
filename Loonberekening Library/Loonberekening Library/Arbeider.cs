using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loonberekening_Library
{
    public class Arbeider : Werknemer
    {
        private double _uurloon;
        private double _aantalUren;
        private double _brutoloon;

        public double UurLoon
        {
            get { return _uurloon; }
            set { _uurloon = value; }
        }
        public double AantalUren
        {
            get { return _aantalUren; }
            set { _aantalUren = value; }
        }
        public double BrutoLoon
        {
            get { return _brutoloon; }
            set { _brutoloon = value; }
        }

        public Arbeider(double aantalUren, double uurloon)
        {
            _aantalUren = aantalUren;
            _uurloon = uurloon;
        }
        public void setAantalUur(double aantalUur)
        {
            _aantalUren = aantalUur;
            
        }

        public void setUurloon(double uurloon)
        {
            _uurloon = uurloon;
            
        }

        public double getRsz()
        {
            
            return ((0.1307 * (_aantalUren * _uurloon)) + (_brutoloon * 1.08));
        }
        public double getBelastbaar()
        {
            return (_aantalUren * _uurloon) - getRsz();
        }
        private void updateBruto()
        {
            _brutoloon = _aantalUren * _uurloon;
        }
        public double getBruto()
        {
            return _aantalUren * _uurloon;
        }
        public double getNettoLoon()
        {
            return getBelastbaar() + getKinderAfslag();
        }

    }
}
