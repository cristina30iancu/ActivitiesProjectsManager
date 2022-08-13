using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerProiecte
{
    public partial class Grafic : UserControl
    {

        public List<string> luni;
         List<double> valori;

        private Color[] culoriDefault = {
            Color.FromArgb(66, 135, 245),
            Color.FromArgb(245, 66, 66),
            Color.FromArgb(114, 245, 66),
            Color.FromArgb(200, 66, 245),
            Color.FromArgb(245, 236, 66),
            Color.FromArgb(87, 176, 46), // vi
            Color.FromArgb(66, 245, 233),
            Color.FromArgb(245, 66, 66),
            Color.FromArgb(46, 79, 176),
            Color.FromArgb(171, 39, 129),
            Color.FromArgb(245, 66, 161),
            Color.FromArgb(176, 46, 46)
        };
        public List<string> Luni
        {
            set { luni = value; }
        }
        public List<double> Valori
        {
            set { valori = value; }
        }
        public Grafic() 
        {
            InitializeComponent();
            luni = new List<string>();
            valori = new List<double>();

        }
        private void scrieInvers(Graphics g, string str, Font fnt, Brush brs, float x, float y, float width, float height)
        {
            g.TranslateTransform(x, y);
            g.TranslateTransform(width, height);

            g.RotateTransform(180);
            g.DrawString(str, fnt, brs, 0, 0);
            g.RotateTransform(-180);

            g.TranslateTransform(-width, -height);
            g.TranslateTransform(-x, -y);
        }
        private void Desenare(Graphics g, Rectangle r)
        {
            int dim = Math.Min(this.Width, this.Height);
            if (dim <= 40) return;
            Pen pen = new Pen(new SolidBrush(Color.DeepSkyBlue), 5);
            Pen pen2 = new Pen(new SolidBrush(Color.Black), 5);
            Rectangle rect = new Rectangle
            {
                X = 5,
                Y = 5,
                Width = dim - 10,
                Height = dim - 10
            };
            if (this.Width > this.Height) rect.X = (this.Width - rect.Width) / 2;
            else rect.Y = (this.Height - rect.Height) / 2;

            float unghi = 0;
            for (int i = 0; i < valori.Count; i++)
            {
                g.FillPie(new SolidBrush(culoriDefault[i]), rect, unghi, (float)(valori[i] / valori.Sum() * 360));
                g.DrawPie(pen, rect, unghi, (float)(valori[i] / valori.Sum() * 360));
               
                unghi +=(float)( valori[i] / valori.Sum() * 360);
            }
            g.DrawEllipse(pen, rect);
            // Scrie textul
            float unghiTotal = 0; // pt orientarea textului
            unghi = 0;
            g.ResetTransform();
            g.TranslateTransform((float)this.Width / 2, (float)this.Height / 2);
            for (int i = 0; i < valori.Count; i++)
            {
                // Roteste pana la jumatatea feliei din pie
                unghi = (float)(valori[i] / valori.Sum() * 360);
                unghiTotal += unghi / 2;
                g.RotateTransform(unghi / 2);

                // Calculeaza dimensiunea textului
                string str = luni[i];
                Font fnt = new Font(FontFamily.GenericSansSerif, dim / 25);
                SizeF strSize = g.MeasureString(str, fnt);

                float x = dim / 2 - strSize.Width -65;
                float y = -strSize.Height / 2;

                // Scrie luna in pie (daca are loc ...)
                if (strSize.Height > 0)
                {
                    if (unghiTotal > 90 && unghiTotal < 270)
                        scrieInvers(g, str, fnt, new SolidBrush(Color.Black), x, y, strSize.Width, strSize.Height);
                    else g.DrawString(str, fnt, new SolidBrush(Color.Black), x, y);
                }
                // Roteste si cealalta jumatate
                g.RotateTransform(unghi / 2);
                unghiTotal += unghi / 2;

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Desenare(e.Graphics, DisplayRectangle);
        }
      
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            string mesaj = "";
            for (int i = 0; i < luni.Count; i++)
            {
                mesaj += (luni[i] + ", " + valori[i] + "\n");
            }
            MessageBox.Show(mesaj);
        }
    }    
}
