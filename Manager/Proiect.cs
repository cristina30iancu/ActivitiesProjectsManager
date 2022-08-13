using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerProiecte
{
    [Serializable]
    public class Proiect
    {
        private string denumire;
        private double profit;

        public Proiect() { }

        public Proiect(string denumire,  double pret)
        {
            this.denumire = denumire;
            this.profit = pret;
        }
      
        public string Denumire
        {
            get { return denumire; }
            set { if (denumire != value && value.Length >= 3) denumire = value; }
        }
        public double Profit
        {
            get { return profit; }
            set { if (value > 0) profit = value; }
        }
        override public string ToString()
        {
            return "Materialul cu denumirea " + denumire + " are pret unitar " + profit + 
                ".";
        }
    }
}
