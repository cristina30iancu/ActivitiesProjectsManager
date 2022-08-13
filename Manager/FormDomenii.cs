using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerProiecte
{
    public partial class FormDomenii : Form
    {
        Main main = null;
        static internal List<Domeniu> dom = null;
        public FormDomenii(Main main)
        {
            InitializeComponent();
            this.main = main;
            dom = new List<Domeniu>();

            Domeniu m = new Domeniu("Cercos",  "IT");
            m.Proiecte.Add(new Proiect("Team Work", 90.5f));
            m.Proiecte.Add(new Proiect("Aplicatie", 190.5f));
            ListViewItem lvi = new
            ListViewItem(new string[] { m.Nume,m.Tip} );
            lvi.Tag = m;
            lvDomenii.Items.Add(lvi);
            dom.Add(m);

            Domeniu m2 = new Domeniu("Anex", "Marketing");
            ListViewItem lvi2 = new
            ListViewItem(new string[] { m2.Nume, m2.Tip });
            m2.Proiecte.Add(new Proiect("Web",99.5f));
            lvi2.Tag = m2;
            lvDomenii.Items.Add(lvi2); dom.Add(m2);

            Domeniu m3 = new Domeniu("Tyohy","IT");
            ListViewItem lvi3 = new
            ListViewItem(new string[] { m3.Nume, m3.Tip });
            lvi3.Tag = m3;
            lvDomenii.Items.Add(lvi3); dom.Add(m3);

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (lvDomenii.SelectedItems.Count > 0)
            {
                stergeToolStripMenuItem.Enabled = true;
                editeazaToolStripMenuItem.Enabled = true;
                comandaToolStripMenuItem.Enabled = true;
            }
            else
            {
                stergeToolStripMenuItem.Enabled = false;
                editeazaToolStripMenuItem.Enabled = false;
                comandaToolStripMenuItem.Enabled = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (main == null)
            {
                Main mf = new Main();
                mf.ShowDialog();
            }
            else
            {
                main.Show();
            }
        }
        public void UpdateItems()
        {
            foreach (ListViewItem lvi in lvDomenii.Items)
            {
                Domeniu m = (Domeniu)lvi.Tag;
                lvi.Text = m.Nume.ToString();
                lvi.SubItems[1].Text = m.Tip;
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new
             ListViewItem(new string[] { "", ""});
            lvDomenii.Items.Add(lvi);
            Domeniu m = new Domeniu("","");
            lvi.Tag = m;

            AddDomeniu fm = new AddDomeniu(this, m);

            fm.Text = "Adaugare domeniu";

            fm.ShowDialog();
            dom.Add(m);
            if (fm.DialogResult != DialogResult.OK)
            {
                lvi.Remove();
            }
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDomenii.SelectedItems.Count > 0)
            {
                Domeniu c = (Domeniu)lvDomenii.SelectedItems[0].Tag;
                DialogResult rezultat = MessageBox.Show("Sunteti sigur ca doriti sa stergeti domeniul " + c.Nume + " ?",
                    "Confirmare stergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rezultat == DialogResult.Yes)
                {
                    lvDomenii.SelectedItems[0].Remove();
                    dom.Remove(c);
                }
            }
        }

        private void editeazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDomenii.SelectedItems.Count > 0)
            {
                Domeniu c = (Domeniu)lvDomenii.SelectedItems[0].Tag;
                AddDomeniu fm = new AddDomeniu(this, c);

                fm.Text = "Modificare domeniu";
                string btntext = "Modifica domeniul";
                fm.ActualizeazaControale(lvDomenii, e, btntext);
                fm.parinte = this;
                fm.ShowDialog();
            }
        }

        private void comandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDomenii.SelectedItems.Count > 0)
            {
                Domeniu c = (Domeniu)lvDomenii.SelectedItems[0].Tag;
                 FormProiecte v = new FormProiecte(main, c);
                    v.ShowDialog();
            }
        }
    }
}
