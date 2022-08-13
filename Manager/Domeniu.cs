using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerProiecte
{
    [Serializable]
    public class Domeniu
    {
        private string nume;
        private string tip;
        private List<Proiect> proiecte;

        public Domeniu() { }

        public Domeniu(string nume,  string tip)
        {
            this.nume = nume;
            this.tip = tip;
            proiecte = new List<Proiect>();
        }

        public List<Proiect> Proiecte
        {
            get { return proiecte; }
            set {  proiecte = value; }
        }
        public string Tip
        {
            get { return tip; }
            set { if (tip != value && value.Length >= 3) tip = value; }
        }
        public string Nume
        {
            get { return nume; }
            set { if (nume != value && value.Length >= 3) nume = value; }
        }
       
        override public string ToString()
        {
            return "Furnizorul de  " + tip + " cu numele " + nume + ".";
        }
    }
}
