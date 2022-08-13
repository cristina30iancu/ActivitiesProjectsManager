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
    public partial class AddActivitate : Form
    {
        VizualizareActivitati vizC = null;
        Main main = null;
        Domeniu f = null;
        Activitate c = null;
        List<Proiect> proiecte=new List<Proiect>();
        private Dictionary<Proiect, int> proiectele = new Dictionary<Proiect, int>();
        public AddActivitate(Activitate c,VizualizareActivitati viz,Main main)
        {
            this.main = main;
            this.c = c;
            this.vizC = viz;
            InitializeComponent();
            if(FormDomenii.dom!=null)
            foreach(Domeniu fz in FormDomenii.dom)
            {
                comboBox1.Items.Add(fz.Nume);
            }
           
        }
        public void ActualizeazaControale(object sender, EventArgs e, string btntext)
        {
            if (c != null)
            {
                btnIncheiere.Text = btntext;
                this.f = c.Domeniu;
                comboBox1.Text = f.Nume;
                foreach (Domeniu fz in FormDomenii.dom)
                {
                    if (fz.Nume.Equals(comboBox1.Text.TrimEnd()))
                    {
                        f = fz;
                        break;
                    }
                }
                int count = 0; 
                foreach (KeyValuePair<Proiect, int> entry in c.Proiecte)
                {
                    count += entry.Value;
                }
                btnItems.Text = count.ToString();
                textBox1.Text = c.Valoare.ToString();
                proiectele = c.Proiecte;
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (vizC == null)
            {
                VizualizareActivitati mf = new VizualizareActivitati(main);
                mf.ShowDialog();
            }
            else
            {
                vizC.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            foreach(Domeniu fz in FormDomenii.dom)
            {
                if (fz.Nume.Equals(comboBox1.Text.TrimEnd()))
                {
                    f = fz;
                    break;
                }
            }
           
            if (f != null)
            {
                lvActiv.Items.Clear();
                if (f.Proiecte != null)
                foreach (Proiect mat in f.Proiecte)
                {
                    ListViewItem lvi = new
                ListViewItem(new string[] { mat.Denumire,  mat.Profit.ToString() });
                    lvi.Tag = mat;
                    lvActiv.Items.Add(lvi);
                }
            }
        }
        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            Proiect p = (Proiect)((ListViewItem)e.Data.GetData(typeof(ListViewItem))).Tag;
            double total = 0;
            if (!textBox1.Text.Trim().Equals(""))
            {
                total = Double.Parse(textBox1.Text);
            }
            total += p.Profit;
            textBox1.Text = total.ToString();
            if (btnItems.Text.Trim().Equals(""))
                btnItems.Text = 1.ToString();
            else
            {
                int nr = int.Parse(btnItems.Text);
                nr++;
                btnItems.Text = nr.ToString();
            }
            proiecte.Add(p);
            int count = 1;
            if (proiectele.ContainsKey(p))
            {
                proiectele.TryGetValue(p, out count);
              count ++;
            } 
            proiectele.Remove(p);
            proiectele.Add(p, count);
        }

        private void button1_DragOver(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {

                e.Effect = DragDropEffects.None;
                return;
            }
        }

        private void lvMateriale2_MouseDown(object sender, MouseEventArgs e)
        {
            if (lvActiv.SelectedItems.Count > 0)
                lvActiv.DoDragDrop(lvActiv.SelectedItems[0], DragDropEffects.Copy);
        }

        private void btnIncheiere_Click(object sender, EventArgs e)
        {
           c.Nume = "Proiect";
            c.Domeniu = f;
            c.Data = DateTime.Now;
            c.Proiecte = proiectele;
            vizC.UpdateItems();
            this.DialogResult = DialogResult.OK;
        }
    }
}
