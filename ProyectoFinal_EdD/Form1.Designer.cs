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
            this.btnPausa = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnAñadirFav = new System.Windows.Forms.Button();
            this.listBoxPlaylist = new System.Windows.Forms.ListBox();
            this.lbFav = new System.Windows.Forms.ListBox();
            this.lblNombreCancion = new System.Windows.Forms.Label();
            this.lbPlaylist = new System.Windows.Forms.Label();
            this.lbEstadoCancion = new System.Windows.Forms.Label();
            this.lbArtistaCancion = new System.Windows.Forms.Label();
            this.lbGenero = new System.Windows.Forms.Label();
            this.lbcola = new System.Windows.Forms.Label();
            this.pbCaratula = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porAñoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porArtistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porNombreDeCancionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porAlbumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recomendarGénerosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lbAlbumAño = new System.Windows.Forms.Label();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaratula)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPausa
            // 
            this.btnPausa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPausa.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnPausa.Location = new System.Drawing.Point(431, 390);
            this.btnPausa.Name = "btnPausa";
            this.btnPausa.Size = new System.Drawing.Size(94, 36);
            this.btnPausa.TabIndex = 2;
            this.btnPausa.Text = "⏸️";
            this.btnPausa.UseVisualStyleBackColor = true;
            this.btnPausa.Click += new System.EventHandler(this.btnPausa_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.Location = new System.Drawing.Point(531, 390);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(112, 36);
            this.btnSiguiente.TabIndex = 3;
            this.btnSiguiente.Text = "⏭️";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.Location = new System.Drawing.Point(318, 390);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(107, 36);
            this.btnAnterior.TabIndex = 4;
            this.btnAnterior.Text = "⏮️";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnAñadirFav
            // 
            this.btnAñadirFav.Location = new System.Drawing.Point(76, 394);
            this.btnAñadirFav.Name = "btnAñadirFav";
            this.btnAñadirFav.Size = new System.Drawing.Size(148, 23);
            this.btnAñadirFav.TabIndex = 5;
            this.btnAñadirFav.Text = "Añadir a favoritos";
            this.btnAñadirFav.UseVisualStyleBackColor = true;
            this.btnAñadirFav.Click += new System.EventHandler(this.btnAddToQueue_Click);
            // 
            // listBoxPlaylist
            // 
            this.listBoxPlaylist.FormattingEnabled = true;
            this.listBoxPlaylist.Location = new System.Drawing.Point(16, 59);
            this.listBoxPlaylist.Name = "listBoxPlaylist";
            this.listBoxPlaylist.Size = new System.Drawing.Size(278, 329);
            this.listBoxPlaylist.TabIndex = 8;
            this.listBoxPlaylist.DoubleClick += new System.EventHandler(this.listBoxPlaylist_DoubleClick);
            // 
            // lbFav
            // 
            this.lbFav.FormattingEnabled = true;
            this.lbFav.Location = new System.Drawing.Point(16, 466);
            this.lbFav.Name = "lbFav";
            this.lbFav.Size = new System.Drawing.Size(278, 95);
            this.lbFav.TabIndex = 9;
            // 
            // lblNombreCancion
            // 
            this.lblNombreCancion.AutoSize = true;
            this.lblNombreCancion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCancion.Location = new System.Drawing.Point(314, 466);
            this.lblNombreCancion.Name = "lblNombreCancion";
            this.lblNombreCancion.Size = new System.Drawing.Size(231, 29);
            this.lblNombreCancion.TabIndex = 11;
            this.lblNombreCancion.Text = "lblNombreCancion";
            // 
            // lbPlaylist
            // 
            this.lbPlaylist.AutoSize = true;
            this.lbPlaylist.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlaylist.Location = new System.Drawing.Point(12, 33);
            this.lbPlaylist.Name = "lbPlaylist";
            this.lbPlaylist.Size = new System.Drawing.Size(85, 23);
            this.lbPlaylist.TabIndex = 13;
            this.lbPlaylist.Text = "PlayList";
            // 
            // lbEstadoCancion
            // 
            this.lbEstadoCancion.AutoSize = true;
            this.lbEstadoCancion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstadoCancion.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbEstadoCancion.Location = new System.Drawing.Point(315, 33);
            this.lbEstadoCancion.Name = "lbEstadoCancion";
            this.lbEstadoCancion.Size = new System.Drawing.Size(161, 24);
            this.lbEstadoCancion.TabIndex = 14;
            this.lbEstadoCancion.Text = "Reproduciendo:";
            // 
            // lbArtistaCancion
            // 
            this.lbArtistaCancion.AutoSize = true;
            this.lbArtistaCancion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbArtistaCancion.Location = new System.Drawing.Point(315, 499);
            this.lbArtistaCancion.Name = "lbArtistaCancion";
            this.lbArtistaCancion.Size = new System.Drawing.Size(141, 20);
            this.lbArtistaCancion.TabIndex = 15;
            this.lbArtistaCancion.Text = "lbArtistaCancion";
            // 
            // lbGenero
            // 
            this.lbGenero.AutoSize = true;
            this.lbGenero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGenero.Location = new System.Drawing.Point(580, 519);
            this.lbGenero.Name = "lbGenero";
            this.lbGenero.Size = new System.Drawing.Size(63, 16);
            this.lbGenero.TabIndex = 17;
            this.lbGenero.Text = "lbGenero";
            // 
            // lbcola
            // 
            this.lbcola.AutoSize = true;
            this.lbcola.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcola.Location = new System.Drawing.Point(12, 440);
            this.lbcola.Name = "lbcola";
            this.lbcola.Size = new System.Drawing.Size(99, 23);
            this.lbcola.TabIndex = 18;
            this.lbcola.Text = "Favoritos";
            // 
            // pbCaratula
            // 
            this.pbCaratula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCaratula.Location = new System.Drawing.Point(318, 59);
            this.pbCaratula.Name = "pbCaratula";
            this.pbCaratula.Size = new System.Drawing.Size(325, 325);
            this.pbCaratula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCaratula.TabIndex = 19;
            this.pbCaratula.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(108, 20);
            this.btnAgregar.Text = "Agregar archivos";
            this.btnAgregar.Click += new System.EventHandler(this.agregarArchivosToolStripMenuItem_Click);
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porAñoToolStripMenuItem,
            this.porArtistaToolStripMenuItem,
            this.porNombreDeCancionToolStripMenuItem,
            this.porAlbumToolStripMenuItem});
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.buscarToolStripMenuItem.Text = "Buscar";
            // 
            // porAñoToolStripMenuItem
            // 
            this.porAñoToolStripMenuItem.Name = "porAñoToolStripMenuItem";
            this.porAñoToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.porAñoToolStripMenuItem.Text = "Por año";
            this.porAñoToolStripMenuItem.Click += new System.EventHandler(this.porAñoToolStripMenuItem_Click);
            // 
            // porArtistaToolStripMenuItem
            // 
            this.porArtistaToolStripMenuItem.Name = "porArtistaToolStripMenuItem";
            this.porArtistaToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.porArtistaToolStripMenuItem.Text = "Por artista";
            this.porArtistaToolStripMenuItem.Click += new System.EventHandler(this.porArtistaToolStripMenuItem_Click);
            // 
            // porNombreDeCancionToolStripMenuItem
            // 
            this.porNombreDeCancionToolStripMenuItem.Name = "porNombreDeCancionToolStripMenuItem";
            this.porNombreDeCancionToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.porNombreDeCancionToolStripMenuItem.Text = "Por nombre de cancion";
            this.porNombreDeCancionToolStripMenuItem.Click += new System.EventHandler(this.porNombreDeCancionToolStripMenuItem_Click);
            // 
            // porAlbumToolStripMenuItem
            // 
            this.porAlbumToolStripMenuItem.Name = "porAlbumToolStripMenuItem";
            this.porAlbumToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.porAlbumToolStripMenuItem.Text = "Por album";
            this.porAlbumToolStripMenuItem.Click += new System.EventHandler(this.porAlbumToolStripMenuItem_Click);
            // 
            // historialToolStripMenuItem
            // 
            this.historialToolStripMenuItem.Name = "historialToolStripMenuItem";
            this.historialToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.historialToolStripMenuItem.Text = "Historial";
            this.historialToolStripMenuItem.Click += new System.EventHandler(this.historialToolStripMenuItem_Click);
            // 
            // recomendarGénerosToolStripMenuItem
            // 
            this.recomendarGénerosToolStripMenuItem.Name = "recomendarGénerosToolStripMenuItem";
            this.recomendarGénerosToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.recomendarGénerosToolStripMenuItem.Text = "Recomendaciones";
            this.recomendarGénerosToolStripMenuItem.Click += new System.EventHandler(this.recomendarGénerosToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregar,
            this.buscarToolStripMenuItem,
            this.historialToolStripMenuItem,
            this.recomendarGénerosToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(662, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lbAlbumAño
            // 
            this.lbAlbumAño.AutoSize = true;
            this.lbAlbumAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlbumAño.Location = new System.Drawing.Point(316, 519);
            this.lbAlbumAño.Name = "lbAlbumAño";
            this.lbAlbumAño.Size = new System.Drawing.Size(80, 16);
            this.lbAlbumAño.TabIndex = 20;
            this.lbAlbumAño.Text = "lbAlbumAño";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 590);
            this.Controls.Add(this.lbAlbumAño);
            this.Controls.Add(this.pbCaratula);
            this.Controls.Add(this.lbcola);
            this.Controls.Add(this.lbGenero);
            this.Controls.Add(this.lbArtistaCancion);
            this.Controls.Add(this.lbEstadoCancion);
            this.Controls.Add(this.lbPlaylist);
            this.Controls.Add(this.lblNombreCancion);
            this.Controls.Add(this.lbFav);
            this.Controls.Add(this.listBoxPlaylist);
            this.Controls.Add(this.btnAñadirFav);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnPausa);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ReproductorMP3-Estructura de Datos-Final";
            ((System.ComponentModel.ISupportInitialize)(this.pbCaratula)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPausa;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnAñadirFav;
        private System.Windows.Forms.ListBox listBoxPlaylist;
        private System.Windows.Forms.ListBox lbFav;
        private System.Windows.Forms.Label lblNombreCancion;
        private System.Windows.Forms.Label lbPlaylist;
        private System.Windows.Forms.Label lbEstadoCancion;
        private System.Windows.Forms.Label lbArtistaCancion;
        private System.Windows.Forms.Label lbGenero;
        private System.Windows.Forms.Label lbcola;
        private System.Windows.Forms.PictureBox pbCaratula;
        private System.Windows.Forms.ToolStripMenuItem btnAgregar;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porAñoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porArtistaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porNombreDeCancionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porAlbumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recomendarGénerosToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lbAlbumAño;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
    }
}

