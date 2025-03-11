namespace AnrangoRamos
{
    partial class frmVerifica
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
            this.btnEsercizio1 = new System.Windows.Forms.Button();
            this.btnEsercizio3 = new System.Windows.Forms.Button();
            this.btnEsercizio2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEsercizio1
            // 
            this.btnEsercizio1.Location = new System.Drawing.Point(12, 12);
            this.btnEsercizio1.Name = "btnEsercizio1";
            this.btnEsercizio1.Size = new System.Drawing.Size(216, 23);
            this.btnEsercizio1.TabIndex = 0;
            this.btnEsercizio1.Text = "ESERCIZIO 1";
            this.btnEsercizio1.UseVisualStyleBackColor = true;
            this.btnEsercizio1.Click += new System.EventHandler(this.btnEsercizio1_Click);
            // 
            // btnEsercizio3
            // 
            this.btnEsercizio3.Location = new System.Drawing.Point(12, 70);
            this.btnEsercizio3.Name = "btnEsercizio3";
            this.btnEsercizio3.Size = new System.Drawing.Size(216, 23);
            this.btnEsercizio3.TabIndex = 2;
            this.btnEsercizio3.Text = "ESERCIZIO 3";
            this.btnEsercizio3.UseVisualStyleBackColor = true;
            this.btnEsercizio3.Click += new System.EventHandler(this.btnEsercizio3_Click);
            // 
            // btnEsercizio2
            // 
            this.btnEsercizio2.Location = new System.Drawing.Point(12, 41);
            this.btnEsercizio2.Name = "btnEsercizio2";
            this.btnEsercizio2.Size = new System.Drawing.Size(216, 23);
            this.btnEsercizio2.TabIndex = 1;
            this.btnEsercizio2.Text = "ESERCIZIO 2";
            this.btnEsercizio2.UseVisualStyleBackColor = true;
            this.btnEsercizio2.Click += new System.EventHandler(this.btnEsercizio2_Click);
            // 
            // frmVerifica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 109);
            this.Controls.Add(this.btnEsercizio2);
            this.Controls.Add(this.btnEsercizio3);
            this.Controls.Add(this.btnEsercizio1);
            this.Name = "frmVerifica";
            this.Text = "CONTEGGIO PER SETTIMANE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVerifica_FormClosing);
            this.Load += new System.EventHandler(this.frmVerifica_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEsercizio1;
        private System.Windows.Forms.Button btnEsercizio3;
        private System.Windows.Forms.Button btnEsercizio2;
    }
}

