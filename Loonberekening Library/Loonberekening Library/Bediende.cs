using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loonberekening_Library
{
    public class Bediende : Werknemer
    {
        private double _maandLoon;
        private double _brutoloon;

        public Bediende(double maandloon)
        {
            _maandLoon = maandloon;
        }
        public double MaandLoon
        {
            get { return _maandLoon; }
            set { _maandLoon = value; }
        }
        public double BrutoLoon
        {
            get { return _brutoloon; }
            set { _brutoloon = value; }
        }

        public void setMaandLoon(double brutoloon)
        {
            _brutoloon = brutoloon;
        }
        public double getBelastbaar()
        {
            return _brutoloon - (0.1307 * _brutoloon);
        }
        public double getRsz()
        {
            return 0.1307 * _brutoloon;
        }
        public double getBruto()
        {
            return _brutoloon;
        }
        public double getNettoLoon()
        {
            return getBelastbaar() + getKinderAfslag();
        }
    }
}
