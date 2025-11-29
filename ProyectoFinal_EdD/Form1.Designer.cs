namespace ProyectoFinal_EdD
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tbpila = new System.Windows.Forms.TextBox();
            this.btnpop = new System.Windows.Forms.Button();
            this.btnpush = new System.Windows.Forms.Button();
            this.btnencolar = new System.Windows.Forms.Button();
            this.btndesencolar = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(65, 47);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(217, 290);
            this.listBox1.TabIndex = 0;
            // 
            // tbpila
            // 
            this.tbpila.Location = new System.Drawing.Point(431, 74);
            this.tbpila.Name = "tbpila";
            this.tbpila.Size = new System.Drawing.Size(100, 20);
            this.tbpila.TabIndex = 1;
            // 
            // btnpop
            // 
            this.btnpop.Location = new System.Drawing.Point(319, 178);
            this.btnpop.Name = "btnpop";
            this.btnpop.Size = new System.Drawing.Size(75, 23);
            this.btnpop.TabIndex = 2;
            this.btnpop.Text = "button1";
            this.btnpop.UseVisualStyleBackColor = true;
            this.btnpop.Click += new System.EventHandler(this.btndesencolar_Click);
            // 
            // btnpush
            // 
            this.btnpush.Location = new System.Drawing.Point(319, 124);
            this.btnpush.Name = "btnpush";
            this.btnpush.Size = new System.Drawing.Size(75, 23);
            this.btnpush.TabIndex = 3;
            this.btnpush.Text = "button1";
            this.btnpush.UseVisualStyleBackColor = true;
            this.btnpush.Click += new System.EventHandler(this.btnencolar_Click);
            // 
            // btnencolar
            // 
            this.btnencolar.Location = new System.Drawing.Point(538, 124);
            this.btnencolar.Name = "btnencolar";
            this.btnencolar.Size = new System.Drawing.Size(75, 23);
            this.btnencolar.TabIndex = 4;
            this.btnencolar.Text = "encolar";
            this.btnencolar.UseVisualStyleBackColor = true;
            this.btnencolar.Click += new System.EventHandler(this.btnencolar_Click_1);
            // 
            // btndesencolar
            // 
            this.btndesencolar.Location = new System.Drawing.Point(538, 178);
            this.btndesencolar.Name = "btndesencolar";
            this.btndesencolar.Size = new System.Drawing.Size(75, 23);
            this.btndesencolar.TabIndex = 5;
            this.btndesencolar.Text = "button2";
            this.btndesencolar.UseVisualStyleBackColor = true;
            this.btndesencolar.Click += new System.EventHandler(this.btndesencolar_Click_1);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(646, 65);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(276, 290);
            this.listBox2.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 698);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.btndesencolar);
            this.Controls.Add(this.btnencolar);
            this.Controls.Add(this.btnpush);
            this.Controls.Add(this.btnpop);
            this.Controls.Add(this.tbpila);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox tbpila;
        private System.Windows.Forms.Button btnpop;
        private System.Windows.Forms.Button btnpush;
        private System.Windows.Forms.Button btnencolar;
        private System.Windows.Forms.Button btndesencolar;
        private System.Windows.Forms.ListBox listBox2;
    }
}

