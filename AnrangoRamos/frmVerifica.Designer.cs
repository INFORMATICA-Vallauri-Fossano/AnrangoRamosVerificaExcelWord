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
            this.btn20File = new System.Windows.Forms.Button();
            this.btnMediaSommaGrafico = new System.Windows.Forms.Button();
            this.btnRiepilogo = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn20File
            // 
            this.btn20File.Location = new System.Drawing.Point(12, 12);
            this.btn20File.Name = "btn20File";
            this.btn20File.Size = new System.Drawing.Size(186, 23);
            this.btn20File.TabIndex = 0;
            this.btn20File.Text = "20 FILE";
            this.btn20File.UseVisualStyleBackColor = true;
            this.btn20File.Click += new System.EventHandler(this.btn20File_Click);
            // 
            // btnMediaSommaGrafico
            // 
            this.btnMediaSommaGrafico.Location = new System.Drawing.Point(12, 41);
            this.btnMediaSommaGrafico.Name = "btnMediaSommaGrafico";
            this.btnMediaSommaGrafico.Size = new System.Drawing.Size(186, 23);
            this.btnMediaSommaGrafico.TabIndex = 1;
            this.btnMediaSommaGrafico.Text = "MEDIA-SOMMA-GRAFICO";
            this.btnMediaSommaGrafico.UseVisualStyleBackColor = true;
            this.btnMediaSommaGrafico.Click += new System.EventHandler(this.btnMediaSommaGrafico_Click);
            // 
            // btnRiepilogo
            // 
            this.btnRiepilogo.Location = new System.Drawing.Point(12, 70);
            this.btnRiepilogo.Name = "btnRiepilogo";
            this.btnRiepilogo.Size = new System.Drawing.Size(186, 23);
            this.btnRiepilogo.TabIndex = 2;
            this.btnRiepilogo.Text = "RIEPILOGO";
            this.btnRiepilogo.UseVisualStyleBackColor = true;
            this.btnRiepilogo.Click += new System.EventHandler(this.btnRiepilogo_Click);
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(12, 99);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(186, 23);
            this.btnElimina.TabIndex = 3;
            this.btnElimina.Text = "ELIMINA TUTTO";
            this.btnElimina.UseVisualStyleBackColor = true;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // frmVerifica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnElimina);
            this.Controls.Add(this.btnRiepilogo);
            this.Controls.Add(this.btnMediaSommaGrafico);
            this.Controls.Add(this.btn20File);
            this.Name = "frmVerifica";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVerifica_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn20File;
        private System.Windows.Forms.Button btnMediaSommaGrafico;
        private System.Windows.Forms.Button btnRiepilogo;
        private System.Windows.Forms.Button btnElimina;
    }
}

