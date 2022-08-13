using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerProiecte
{
    public partial class VizualizareActivitati : Form
    {
        Main main = null;
        Activitate deprintat = null;
        List<Activitate> activitati = null;
        public VizualizareActivitati(Main main)
        {
            InitializeComponent();
            this.main = main;
            this.activitati = new List<Activitate>();
        }

        private void adaugaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new
            ListViewItem(new string[] { "", "", "" ,""});
            lvAct.Items.Add(lvi);
            Activitate m = new Activitate("", null, DateTime.Now,null);
            lvi.Tag = m;

            AddActivitate fm = new AddActivitate(m,this,main);

            fm.Text = "Adaugare activitate";

            fm.ShowDialog();
            activitati.Add(m);
            if (fm.DialogResult != DialogResult.OK)
            {
                lvi.Remove();
            }
        }
        public void UpdateItems()
        {
            foreach (ListViewItem lvi in lvAct.Items)
            {
                Activitate m = (Activitate)lvi.Tag;
                lvi.Text = m.Nume.ToString();
                lvi.SubItems[1].Text = m.Domeniu.ToString();
                lvi.SubItems[2].Text = m.Data.ToString();
                lvi.SubItems[3].Text = m.Valoare.ToString();
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

      
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (lvAct.SelectedItems.Count > 0)
            {
                stergeToolStripMenuItem.Enabled = true;
                modificaToolStripMenuItem.Enabled = true;
                printeazaToolStripMenuItem.Enabled = true;
            }
            else
            {
                stergeToolStripMenuItem.Enabled = false;
                modificaToolStripMenuItem.Enabled = false;
                printeazaToolStripMenuItem.Enabled = false;
            }
           
        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvAct.SelectedItems.Count > 0)
            {
                Activitate c = (Activitate)lvAct.SelectedItems[0].Tag;
                AddActivitate fm = new AddActivitate( c,this,main);

                fm.Text = "Modificare activitate";
                string btntext = "Modifica activitate";
                fm.ActualizeazaControale(lvAct, e, btntext);
                fm.ShowDialog();
            }
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvAct.SelectedItems.Count > 0)
            {
                Activitate c = (Activitate)lvAct.SelectedItems[0].Tag;
                DialogResult rezultat = MessageBox.Show("Sunteti sigur ca doriti sa stergeti activitatea " + c.Nume + " ?",
                    "Confirmare stergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rezultat == DialogResult.Yes)
                {
                    lvAct.SelectedItems[0].Remove();
                    activitati.Remove(c);
                }
            }
        }
    }
}