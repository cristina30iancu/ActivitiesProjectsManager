using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerProiecte
{
    public partial class FormProiecte : Form
    {
        public Main main;
        List<Proiect> proiecte = null;
        Domeniu domeniu = null;
        public FormProiecte(Main main,Domeniu f)
        {
            InitializeComponent();
            this.main = main;
            domeniu = f;
            proiecte = new List<Proiect>();

            if(f.Proiecte==null)
                f.Proiecte = new List<Proiect>();
            foreach (Proiect mat in f.Proiecte){
                ListViewItem lvi = new
            ListViewItem(new string[] { mat.Denumire,mat.Profit.ToString() });
                lvi.Tag = mat;
                lvProiecte.Items.Add(lvi);
                proiecte.Add(mat);
            }
            Adauga();
        }
        private void AdaugaListView()
        {
            lvProiecte.Items.Clear();
            foreach (Proiect mat in proiecte.ToList())
            {
                ListViewItem lvi = new 
                ListViewItem(new string[] { mat.Denumire,  mat.Profit.ToString() });
                lvi.Tag = mat;
                lvProiecte.Items.Add(lvi);
            }
            Adauga();
        }
        private void inapoiToolStripMenuItem_Click(object sender, EventArgs e)
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
            foreach (ListViewItem lvi in lvProiecte.Items)
            {
                Proiect m = (Proiect)lvi.Tag;
                lvi.Text = m.Denumire;
              
                lvi.SubItems[1].Text = m.Profit.ToString();
            }
            Adauga();
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (lvProiecte.SelectedItems.Count > 0)
            {
                stergeToolStripMenuItem.Enabled = true;
                editeazaToolStripMenuItem.Enabled = true;
            }
            else
            {
                stergeToolStripMenuItem.Enabled = false;
                editeazaToolStripMenuItem.Enabled = false;
            }
        }

        private void adaugaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new
            ListViewItem(new string[] { "", "", "" });
            lvProiecte.Items.Add(lvi);
            Proiect m = new Proiect("", 0);
            lvi.Tag = m;

            AddProiect fm = new AddProiect(this, m);

            fm.Text = "Adaugare proiect";

            fm.ShowDialog();
            proiecte.Add(m);
            domeniu.Proiecte.Add(m);
            if (fm.DialogResult != DialogResult.OK)
            {
                lvi.Remove();
            }
            Adauga();
        }

        private void editeazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvProiecte.SelectedItems.Count > 0)
            {
                Proiect c = (Proiect)lvProiecte.SelectedItems[0].Tag;
                AddProiect fm = new AddProiect(this, c);

                fm.Text = "Modificare proiect";
                string btntext = "Modifica proiectul";
                fm.ActualizeazaControale(lvProiecte, e, btntext);
                fm.parinte = this;
                fm.ShowDialog();
            }
            Adauga();
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvProiecte.SelectedItems.Count > 0)
            {
                Proiect c = (Proiect)lvProiecte.SelectedItems[0].Tag;
                DialogResult rezultat = MessageBox.Show("Sunteti sigur ca doriti sa stergeti proiectul " + c.Denumire + " ?",
                    "Confirmare stergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rezultat == DialogResult.Yes)
                {
                    lvProiecte.SelectedItems[0].Remove();
                    domeniu.Proiecte.Remove(c);
                }

            }
        }

        private void deserializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.CheckPathExists = true;
            fd.CheckFileExists = true;
            fd.Filter = "Fisiere binare (*bin)|*.bin";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                proiecte.Clear();
                Stream fb = File.OpenRead("Proiecte.bin");
                BinaryFormatter des = new BinaryFormatter();
                proiecte = (List<Proiect>)des.Deserialize(fb);
                fb.Close();
                AdaugaListView();
            }

            domeniu.Proiecte = proiecte;
            Adauga();
        }
        void Adauga()
        {
            List<string> comp = new List<string>(); List<double> valori = new List<double>();
            foreach (Proiect c in proiecte)
            {
                if (!comp.Contains(c.Denumire))
                {
                    comp.Add(c.Denumire);
                    valori.Add(0);
                }
            }
            for (int i = 0; i < comp.Count; i++)
            {
                foreach (Proiect c in proiecte)
                {
                    if (c.Denumire.TrimEnd() == comp[i])
                        valori[i]++;
                }
            }

            for (int i = 0; i < comp.Count; i++)
            {
                if (valori[i] == 0)
                {
                    valori.Remove(valori[i]);
                    comp.Remove(comp[i]);
                    i++;
                }
            }
            if (comp.Count == 0)
            {
               // MessageBox.Show("Proiecte insuficiente");
                return;
            }
            grafic1.Luni = comp;
            grafic1.Valori = valori;
            grafic1.Invalidate(true);
        }

        private void serializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.CheckPathExists = true;
            fd.Filter = "Fisiere binare (*bin)|*.bin";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                Stream fb = File.Create("Proiecte.bin");
                BinaryFormatter serializator = new BinaryFormatter();
                serializator.Serialize(fb, proiecte);
                fb.Close();
            }
        }

    }
}
