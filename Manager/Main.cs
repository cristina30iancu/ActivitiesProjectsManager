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
    public partial class Main : Form
    {
        public FormDomenii vizFz = null;
        public FormProiecte vizMat = null;
        public VizualizareActivitati vizContr = null;
        public Main()
        {
            InitializeComponent();
            FormDomenii vzf = new FormDomenii(this);
            vizFz = vzf;
            VizualizareActivitati vz = new VizualizareActivitati(this);
            vizContr = vz;
        }

        private void btnFormFz_Click(object sender, EventArgs e)
        {
            this.Hide();
            vizFz.ContextMenuStrip = vizFz.contextMenuStrip1;
            vizFz.ShowDialog();
        }
        private void btnFormContracte_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (vizContr == null)
            {
                VizualizareActivitati vzf = new VizualizareActivitati(this);
                vizContr = vzf;
            }
            vizContr.ContextMenuStrip = vizContr.contextMenuStrip1;
            vizContr.ShowDialog();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                this.Hide();
                vizContr.ContextMenuStrip = vizContr.contextMenuStrip1;
                vizContr.ShowDialog();
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F)
            {
                this.Hide();
                if (vizFz == null)
                {
                    FormDomenii vzf = new FormDomenii(this);
                    vizFz = vzf;
                }
                vizFz.ContextMenuStrip = vizFz.contextMenuStrip1;
                vizFz.ShowDialog();
            }
        }
    }
}
