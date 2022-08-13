
namespace ManagerProiecte
{
    partial class AddProiect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDenumire = new System.Windows.Forms.TextBox();
            this.numProfit = new System.Windows.Forms.NumericUpDown();
            this.btnAddProiect = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Denumire";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Showcard Gothic", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Profit";
            // 
            // tbDenumire
            // 
            this.tbDenumire.Location = new System.Drawing.Point(161, 51);
            this.tbDenumire.Name = "tbDenumire";
            this.tbDenumire.Size = new System.Drawing.Size(181, 26);
            this.tbDenumire.TabIndex = 3;
            this.tbDenumire.Validating += new System.ComponentModel.CancelEventHandler(this.tbDenumire_Validating);
            // 
            // numProfit
            // 
            this.numProfit.Location = new System.Drawing.Point(161, 101);
            this.numProfit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numProfit.Name = "numProfit";
            this.numProfit.Size = new System.Drawing.Size(181, 26);
            this.numProfit.TabIndex = 5;
            this.numProfit.Validating += new System.ComponentModel.CancelEventHandler(this.numPret_Validating);
            // 
            // btnAddProiect
            // 
            this.btnAddProiect.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAddProiect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddProiect.Location = new System.Drawing.Point(115, 177);
            this.btnAddProiect.Name = "btnAddProiect";
            this.btnAddProiect.Size = new System.Drawing.Size(154, 57);
            this.btnAddProiect.TabIndex = 6;
            this.btnAddProiect.Text = "ADAUGA";
            this.btnAddProiect.UseVisualStyleBackColor = false;
            this.btnAddProiect.Click += new System.EventHandler(this.btnAddProiect_click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddProiect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(434, 294);
            this.Controls.Add(this.btnAddProiect);
            this.Controls.Add(this.numProfit);
            this.Controls.Add(this.tbDenumire);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "AddProiect";
            this.Text = "Adauga proiect";
            ((System.ComponentModel.ISupportInitialize)(this.numProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDenumire;
        private System.Windows.Forms.NumericUpDown numProfit;
        private System.Windows.Forms.Button btnAddProiect;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}