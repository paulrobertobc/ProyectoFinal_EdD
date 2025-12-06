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
            this.lblNombreCancion = new System.Windows.Forms.Label();
            this.lbPlaylist = new System.Windows.Forms.Label();
            this.lbEstadoCancion = new System.Windows.Forms.Label();
            this.lbArtistaCancion = new System.Windows.Forms.Label();
            this.lbGenero = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porAñoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porArtistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porNombreDeCancionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porAlbumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recomendarGénerosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbAlbumAño = new System.Windows.Forms.Label();
            this.historialToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.favoritosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbBarraMusica = new System.Windows.Forms.PictureBox();
            this.pbCaratula = new System.Windows.Forms.PictureBox();
            this.pbFondo = new System.Windows.Forms.PictureBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarraMusica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaratula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFondo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPausa
            // 
            this.btnPausa.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnPausa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPausa.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnPausa.Location = new System.Drawing.Point(108, 504);
            this.btnPausa.Name = "btnPausa";
            this.btnPausa.Size = new System.Drawing.Size(104, 36);
            this.btnPausa.TabIndex = 2;
            this.btnPausa.Text = "⏸️";
            this.btnPausa.UseVisualStyleBackColor = false;
            this.btnPausa.Click += new System.EventHandler(this.btnPausa_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.Location = new System.Drawing.Point(218, 504);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(92, 36);
            this.btnSiguiente.TabIndex = 3;
            this.btnSiguiente.Text = "⏭️";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.Location = new System.Drawing.Point(10, 504);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(92, 36);
            this.btnAnterior.TabIndex = 4;
            this.btnAnterior.Text = "⏮️";
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnAñadirFav
            // 
            this.btnAñadirFav.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnAñadirFav.Location = new System.Drawing.Point(343, 617);
            this.btnAñadirFav.Name = "btnAñadirFav";
            this.btnAñadirFav.Size = new System.Drawing.Size(148, 23);
            this.btnAñadirFav.TabIndex = 5;
            this.btnAñadirFav.Text = "Añadir a favoritos";
            this.btnAñadirFav.UseVisualStyleBackColor = false;
            this.btnAñadirFav.Click += new System.EventHandler(this.btnAddToQueue_Click);
            // 
            // listBoxPlaylist
            // 
            this.listBoxPlaylist.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.listBoxPlaylist.FormattingEnabled = true;
            this.listBoxPlaylist.Location = new System.Drawing.Point(343, 59);
            this.listBoxPlaylist.Name = "listBoxPlaylist";
            this.listBoxPlaylist.Size = new System.Drawing.Size(278, 550);
            this.listBoxPlaylist.TabIndex = 8;
            this.listBoxPlaylist.DoubleClick += new System.EventHandler(this.listBoxPlaylist_DoubleClick);
            // 
            // lblNombreCancion
            // 
            this.lblNombreCancion.AutoSize = true;
            this.lblNombreCancion.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblNombreCancion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCancion.ForeColor = System.Drawing.Color.Navy;
            this.lblNombreCancion.Location = new System.Drawing.Point(12, 555);
            this.lblNombreCancion.Name = "lblNombreCancion";
            this.lblNombreCancion.Size = new System.Drawing.Size(231, 29);
            this.lblNombreCancion.TabIndex = 11;
            this.lblNombreCancion.Text = "lblNombreCancion";
            // 
            // lbPlaylist
            // 
            this.lbPlaylist.AutoSize = true;
            this.lbPlaylist.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbPlaylist.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlaylist.Location = new System.Drawing.Point(339, 33);
            this.lbPlaylist.Name = "lbPlaylist";
            this.lbPlaylist.Size = new System.Drawing.Size(85, 23);
            this.lbPlaylist.TabIndex = 13;
            this.lbPlaylist.Text = "PlayList";
            // 
            // lbEstadoCancion
            // 
            this.lbEstadoCancion.AutoSize = true;
            this.lbEstadoCancion.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbEstadoCancion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstadoCancion.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbEstadoCancion.Location = new System.Drawing.Point(8, 33);
            this.lbEstadoCancion.Name = "lbEstadoCancion";
            this.lbEstadoCancion.Size = new System.Drawing.Size(161, 24);
            this.lbEstadoCancion.TabIndex = 14;
            this.lbEstadoCancion.Text = "Reproduciendo:";
            // 
            // lbArtistaCancion
            // 
            this.lbArtistaCancion.AutoSize = true;
            this.lbArtistaCancion.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbArtistaCancion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbArtistaCancion.ForeColor = System.Drawing.Color.Navy;
            this.lbArtistaCancion.Location = new System.Drawing.Point(13, 584);
            this.lbArtistaCancion.Name = "lbArtistaCancion";
            this.lbArtistaCancion.Size = new System.Drawing.Size(141, 20);
            this.lbArtistaCancion.TabIndex = 15;
            this.lbArtistaCancion.Text = "lbArtistaCancion";
            // 
            // lbGenero
            // 
            this.lbGenero.AutoSize = true;
            this.lbGenero.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbGenero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGenero.ForeColor = System.Drawing.Color.Navy;
            this.lbGenero.Location = new System.Drawing.Point(217, 617);
            this.lbGenero.Name = "lbGenero";
            this.lbGenero.Size = new System.Drawing.Size(71, 16);
            this.lbGenero.TabIndex = 17;
            this.lbGenero.Text = "lbGenero";
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
            this.historialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historialToolStripMenuItem1,
            this.favoritosToolStripMenuItem});
            this.historialToolStripMenuItem.Name = "historialToolStripMenuItem";
            this.historialToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.historialToolStripMenuItem.Text = "Historial";
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
            this.menuStrip1.Size = new System.Drawing.Size(651, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // lbAlbumAño
            // 
            this.lbAlbumAño.AutoSize = true;
            this.lbAlbumAño.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbAlbumAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlbumAño.ForeColor = System.Drawing.Color.Navy;
            this.lbAlbumAño.Location = new System.Drawing.Point(14, 604);
            this.lbAlbumAño.Name = "lbAlbumAño";
            this.lbAlbumAño.Size = new System.Drawing.Size(90, 16);
            this.lbAlbumAño.TabIndex = 20;
            this.lbAlbumAño.Text = "lbAlbumAño";
            // 
            // historialToolStripMenuItem1
            // 
            this.historialToolStripMenuItem1.Name = "historialToolStripMenuItem1";
            this.historialToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.historialToolStripMenuItem1.Text = "Historial";
            this.historialToolStripMenuItem1.Click += new System.EventHandler(this.historialToolStripMenuItem1_Click);
            // 
            // favoritosToolStripMenuItem
            // 
            this.favoritosToolStripMenuItem.Name = "favoritosToolStripMenuItem";
            this.favoritosToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.favoritosToolStripMenuItem.Text = "Favoritos";
            this.favoritosToolStripMenuItem.Click += new System.EventHandler(this.favoritosToolStripMenuItem_Click);
            // 
            // pbBarraMusica
            // 
            this.pbBarraMusica.Image = global::ProyectoFinal_EdD.Properties.Resources.pausa;
            this.pbBarraMusica.Location = new System.Drawing.Point(78, 365);
            this.pbBarraMusica.Name = "pbBarraMusica";
            this.pbBarraMusica.Size = new System.Drawing.Size(149, 119);
            this.pbBarraMusica.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBarraMusica.TabIndex = 21;
            this.pbBarraMusica.TabStop = false;
            // 
            // pbCaratula
            // 
            this.pbCaratula.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pbCaratula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbCaratula.Location = new System.Drawing.Point(12, 59);
            this.pbCaratula.Name = "pbCaratula";
            this.pbCaratula.Size = new System.Drawing.Size(300, 300);
            this.pbCaratula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCaratula.TabIndex = 19;
            this.pbCaratula.TabStop = false;
            // 
            // pbFondo
            // 
            this.pbFondo.Image = global::ProyectoFinal_EdD.Properties.Resources.fondo;
            this.pbFondo.Location = new System.Drawing.Point(0, 0);
            this.pbFondo.Name = "pbFondo";
            this.pbFondo.Size = new System.Drawing.Size(656, 703);
            this.pbFondo.TabIndex = 22;
            this.pbFondo.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnEliminar.Location = new System.Drawing.Point(516, 615);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(105, 23);
            this.btnEliminar.TabIndex = 23;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 666);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.pbBarraMusica);
            this.Controls.Add(this.lbAlbumAño);
            this.Controls.Add(this.pbCaratula);
            this.Controls.Add(this.lbGenero);
            this.Controls.Add(this.lbArtistaCancion);
            this.Controls.Add(this.lbEstadoCancion);
            this.Controls.Add(this.lbPlaylist);
            this.Controls.Add(this.lblNombreCancion);
            this.Controls.Add(this.listBoxPlaylist);
            this.Controls.Add(this.btnAñadirFav);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnPausa);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pbFondo);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ReproductorMP3-Estructura de Datos-Final";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarraMusica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaratula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFondo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPausa;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnAñadirFav;
        private System.Windows.Forms.ListBox listBoxPlaylist;
        private System.Windows.Forms.Label lblNombreCancion;
        private System.Windows.Forms.Label lbPlaylist;
        private System.Windows.Forms.Label lbEstadoCancion;
        private System.Windows.Forms.Label lbArtistaCancion;
        private System.Windows.Forms.Label lbGenero;
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
        private System.Windows.Forms.PictureBox pbBarraMusica;
        private System.Windows.Forms.PictureBox pbFondo;
        private System.Windows.Forms.ToolStripMenuItem historialToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem favoritosToolStripMenuItem;
        private System.Windows.Forms.Button btnEliminar;
    }
}

