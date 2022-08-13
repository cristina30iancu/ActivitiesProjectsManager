using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerProiecte
{
    public partial class AddProiect : Form
    {
        public FormProiecte parinte;
        public Proiect proiect;
        public AddProiect(FormProiecte parinte, Proiect proiect)
        {
            InitializeComponent();
            this.parinte = parinte;
            this.proiect = proiect;
        }
        public void ActualizeazaControale(object sender, EventArgs e, string btntext)
        {
            if (proiect != null)
            {
                btnAddProiect.Text = btntext;
                tbDenumire.Text = proiect.Denumire;
                numProfit.Value = (int)proiect.Profit;
            }
        }

        private void btnAddProiect_click(object sender, EventArgs e)
        {
            if (ValidateChildren() == false)
            {
                errorProvider1.SetError(this, "Campuri eronate!");
            }
            else
            {
                if (proiect != null)
                {
                    proiect.Denumire = tbDenumire.Text;
                    proiect.Profit = Double.Parse(numProfit.Value.ToString());
                    parinte.UpdateItems();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void tbDenumire_Validating(object sender, CancelEventArgs e)
        {
            if (tbDenumire.Text == "" || tbDenumire.Text.Length < 3)
            {
                errorProvider1.SetError(tbDenumire, "Denumirea trebuie sa aiba cel putin 3 litere!");
                e.Cancel = true;
                tbDenumire.Focus();
            }
            else if (!Regex.IsMatch(tbDenumire.Text, "([A-ZAÎ??Â])+(?=.{1,40}$)[a-zA-ZAÎ??Âaî??]+(?:[-\\s][a-zA-ZAÎ??Âaî??â]+)*\\s*$"))
            {
                errorProvider1.SetError(tbDenumire, "Denumirea incepe cu litera mare si nu poate contine cifre!");
                e.Cancel = true;
                tbDenumire.Focus();
            }
            else
            {
                errorProvider1.SetError(tbDenumire, "");
            }
        }

        private void numPret_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(numProfit.Text, out int rez) == false)
            {
                errorProvider1.SetError(numProfit, "Numar de camera invalid");
                e.Cancel = true;
            }
            else
            {
                if (Convert.ToInt32(numProfit.Text) < 0)
                {
                    errorProvider1.SetError(numProfit, "Introduceti numar natural.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(numProfit, ""); 
                }
            }
        }

    }
}
