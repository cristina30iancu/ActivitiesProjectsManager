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
    public partial class AddDomeniu : Form
    {
        public FormDomenii parinte;
        public Domeniu furnizor;
        public AddDomeniu(FormDomenii parinte, Domeniu furnizor)
        {
            InitializeComponent();
            this.parinte = parinte;
            this.furnizor = furnizor;
        }
        public void ActualizeazaControale(object sender, EventArgs e, string btntext)
        {
            if (furnizor != null)
            {
                btnAdauga.Text = btntext;
                cbTip.Text = furnizor.Tip;
                tbNume.Text = furnizor.Nume;
            }
        }
        private void btnAdauga_Click(object sender, EventArgs e)
        {

            if (ValidateChildren() == false)
            {
                errorProvider1.SetError(this, "Campuri eronate!");
            }
            else
            {
                if (furnizor != null)
                {
                    furnizor.Nume = tbNume.Text;
                    furnizor.Tip = cbTip.Text;
                    parinte.UpdateItems();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void tbNume_Validating(object sender, CancelEventArgs e)
        {
            if (tbNume.Text == "" || tbNume.Text.Length <3)
            {
                errorProvider1.SetError(tbNume, "Numele trebuie sa aiba cel putin 3 litere!");
                e.Cancel = true;
                tbNume.Focus();
            }
            else if (!Regex.IsMatch(tbNume.Text, "([A-ZAÎ??Â])+(?=.{1,40}$)[a-zA-ZAÎ??Âaî??]+(?:[-\\s][a-zA-ZAÎ??Âaî??â]+)*\\s*$"))
            {
                errorProvider1.SetError(tbNume, "Numele incepe cu litera mare si nu poate contine cifre!");
                e.Cancel = true;
                tbNume.Focus();
            }
            else
            {
                errorProvider1.SetError(tbNume, "");
            }
        }

        private void cbTip_Validating(object sender, CancelEventArgs e)
        {
            if (cbTip.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbTip, "Campul nu poate fi gol!");
                e.Cancel = true;
                cbTip.Focus();
            }
            else
            {
                errorProvider1.SetError(cbTip, "");
            }
        }
    }
}
