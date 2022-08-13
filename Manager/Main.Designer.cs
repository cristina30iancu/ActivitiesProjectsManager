
namespace ManagerProiecte
{
    partial class Main
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
            this.btnFormDom = new System.Windows.Forms.Button();
            this.btnFormActivitati = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFormDom
            // 
            this.btnFormDom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFormDom.Font = new System.Drawing.Font("Microsoft YaHei", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFormDom.Location = new System.Drawing.Point(50, 135);
            this.btnFormDom.Name = "btnFormDom";
            this.btnFormDom.Size = new System.Drawing.Size(165, 58);
            this.btnFormDom.TabIndex = 0;
            this.btnFormDom.Text = "Domenii";
            this.btnFormDom.UseVisualStyleBackColor = false;
            this.btnFormDom.Click += new System.EventHandler(this.btnFormFz_Click);
            // 
            // btnFormActivitati
            // 
            this.btnFormActivitati.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFormActivitati.Font = new System.Drawing.Font("Microsoft YaHei", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFormActivitati.Location = new System.Drawing.Point(50, 236);
            this.btnFormActivitati.Name = "btnFormActivitati";
            this.btnFormActivitati.Size = new System.Drawing.Size(165, 58);
            this.btnFormActivitati.TabIndex = 1;
            this.btnFormActivitati.Text = "Activitati";
            this.btnFormActivitati.UseVisualStyleBackColor = false;
            this.btnFormActivitati.Click += new System.EventHandler(this.btnFormContracte_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(266, 402);
            this.Controls.Add(this.btnFormActivitati);
            this.Controls.Add(this.btnFormDom);
            this.KeyPreview = true;
            this.Name = "Main";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFormDom;
        private System.Windows.Forms.Button btnFormActivitati;
    }
}

