using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerProiecte
{
    [Serializable]
     public class Activitate
    {
        private string nume;
        private Domeniu domeniu;
        private DateTime data;
        private Dictionary<Proiect, int> proiecte;

        public Activitate() { proiecte = new Dictionary<Proiect, int>(); }

        public Activitate(string nume, Domeniu domeniu, DateTime data, Dictionary<Proiect, int> proiecte)
        {
            this.nume = nume;
            this.data = data;
            this.domeniu = domeniu;
            this.proiecte = proiecte;
        }
        public Dictionary<Proiect, int> Proiecte
        {
            get { return proiecte; }
            set { if (value != proiecte && value.Count > 0) proiecte = value; }
        }
        public DateTime Data
        {
            get { return data; }
            set { if (value != data && value >= DateTime.Now) data = value; }
        }
        public Domeniu Domeniu
        {
            get { return domeniu; }
            set { if (domeniu != value) domeniu = value; }
        }
        public string Nume
        {
            get { return nume; }
            set { if (nume != value && value.Length > 3) nume = value; }
        }
      
        public double Valoare
        {
            get
            {
                double val = 0;
                if(this.proiecte!=null && this.proiecte.Count>0)
                {
                    foreach(Proiect v in proiecte.Keys)
                    {
                        val += v.Profit * int.Parse(proiecte[v].ToString());
                    }
                }
                return val;
            }
        }
        override public string ToString()
        {
            return "Contractul seria "+nume+" din data de  " + data + ", cu furnizorul " + domeniu.Nume + ".";
        }
    }
}
