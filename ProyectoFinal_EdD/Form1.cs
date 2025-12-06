using ProyectoFinal_EdD_Grafo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib; // TagLibSharp

namespace ProyectoFinal_EdD
{
    public partial class Form1 : Form
    {
        private ListaEnlazada<Cancion> playlist = new ListaEnlazada<Cancion>();
        private Pila<Cancion> pila_favoritos = new Pila<Cancion>();
        private Cola<Cancion> cola_historial = new Cola<Cancion>();
        private ArbolBinario<Cancion> biblioteca = new ArbolBinario<Cancion>();
        private Cancion cancionActual = null;
        private Dictionary<int, string> Generos = new Dictionary<int, string>();
        private ReproductorMP3 player = new ReproductorMP3();
        private Grafo grafo;
        public Form1()
        {
            InitializeComponent();
            InicializarGeneros();
            InicializarGrafoMusical();

            player.PlaybackStopped -= Player_PlaybackStopped;
            player.PlaybackStopped += Player_PlaybackStopped;
        }
        //llenamos el diccionario de generos precargados
        void InicializarGeneros()
        {
            Generos.Add(0, "Alternativo");
            Generos.Add(1, "Clásico");
            Generos.Add(2, "Pop");
            Generos.Add(3, "R&B");
            Generos.Add(4, "Rap");
            Generos.Add(5, "Reggae");
            Generos.Add(6, "Reggaeton");
            Generos.Add(7, "Rock");
            Generos.Add(8, "Metal");
            Generos.Add(9, "Jazz");
        }
        //generos, aristas y pesos precargados
        void InicializarGrafoMusical()
        {
            grafo = new Grafo(10);

            // Alternativo
            grafo.CrearArista(0, 7, 2);
            grafo.CrearArista(0, 2, 4);
            grafo.CrearArista(0, 8, 6);
            grafo.CrearArista(0, 3, 7);

            // Clásico
            grafo.CrearArista(1, 9, 5);
            grafo.CrearArista(1, 2, 8);

            // Pop
            grafo.CrearArista(2, 3, 2);
            grafo.CrearArista(2, 6, 3);
            grafo.CrearArista(2, 4, 4);

            // R&B
            grafo.CrearArista(3, 4, 2);
            grafo.CrearArista(3, 6, 5);

            // Rap
            grafo.CrearArista(4, 6, 3);

            // Reggae
            grafo.CrearArista(5, 4, 4);
            grafo.CrearArista(5, 6, 6);

            // Reggaeton
            grafo.CrearArista(6, 3, 5);
            grafo.CrearArista(6, 2, 3);

            // Rock
            grafo.CrearArista(7, 0, 2);
            grafo.CrearArista(7, 8, 2);
            grafo.CrearArista(7, 2, 6);

            // Metal
            grafo.CrearArista(8, 7, 2);

            // Jazz
            grafo.CrearArista(9, 1, 3);
            grafo.CrearArista(9, 3, 6);
        }
        private Grafo ExpandirGrafo(Grafo g)
        {
            int n = Generos.Count;
            Grafo nuevo = new Grafo(n + 1);

            int[,] mat = g.ObtenerMatriz();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    nuevo.CrearArista(i, j, mat[i, j]);
                }
                    
            }
            return nuevo;
        }
        private void Player_PlaybackStopped(object sender, EventArgs e)
        {
            // Al terminar una canción, reproducir siguiente de la lista enlazada playlist
            BeginInvoke(new Action(() =>
            {
                var siguiente = playlist.Siguiente(cancionActual);  
                if (siguiente != null)
                    ReproducirCancion(siguiente);
            }));
        }

        private void agregarArchivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())//abrimos openfiledialog para leer archivos mp3
            {
                of.Filter = "Archivos de audio|*.mp3;*.wav;*.flac;*.m4a";
                of.Multiselect = true;
                if (of.ShowDialog() != DialogResult.OK) return;
                foreach (var ruta in of.FileNames)// aqui vamos a leer los metadatos de la canción en mp3 usando TagLibSharp
                {
                    try
                    {
                        var t = TagLib.File.Create(ruta);
                        var titulo = t.Tag.Title ?? Path.GetFileNameWithoutExtension(ruta);
                        var artista = t.Tag.FirstPerformer ?? "Desconocido";
                        var genero = t.Tag.FirstGenre ?? "Indefinido";
                        var año = (int)(t.Tag.Year);
                        var album = t.Tag.Album ?? "Desconocido";

                        grafo = ExpandirGrafo(grafo);
                        genero = genero.Trim();
                        int id;

                        if (Generos.Values.Contains(genero, StringComparer.OrdinalIgnoreCase))// Verificar si ya existe el género
                        {
                            id = Generos.First(g =>g.Value.Equals(genero, StringComparison.OrdinalIgnoreCase)).Key;// Si existe, obtener su ID existente
                        }
                        else
                        {
                            id = Generos.Count;// Si NO existe, crear nuevo
                            Generos.Add(id, genero);
                            grafo = ExpandirGrafo(grafo);// Como cambia la cantidad de nodos, expandimos el grafo
                        }
                        var c = new Cancion
                        {
                            Titulo = titulo, Artista = artista, Año = año, Album = album, Genero = genero, Ruta = ruta
                        };
                        playlist.Insertar(c);
                        biblioteca.Insertar(c);
                        LlenadoLista();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"No se pudo leer: {ruta}\n{ex.Message}");
                    }
                }
            }
        }
        public void LlenadoLista()
        {
            listBoxPlaylist.Items.Clear();
            foreach (var cancion in playlist)
            {
                listBoxPlaylist.Items.Add(cancion);
            }
        }
        private void listBoxPlaylist_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxPlaylist.SelectedItem is Cancion c)
            {
                ReproducirCancion(c);
            }
            else
            {
                var s2 = cancionActual;
                if (s2 != null) ReproducirCancion(s2);
            }
            listBoxPlaylist.ClearSelected();
        }
        private void ReproducirCancion(Cancion c)
        {
            cancionActual = c;

            if (c == null) return;

            try
            {
                player.Reproducir(c.Ruta);
                cola_historial.Encolar(c);
                pbCaratula.Image = player.ObtenerCaratula(c.Ruta) ?? Properties.Resources.nave;
                pbBarraMusica.Image = Properties.Resources.barra_de_progreso;
                lblNombreCancion.Text = $"{c.Titulo}";
                lbArtistaCancion.Text = $"{c.Artista}";
                lbGenero.Text = $"{c.Genero}";
                lbAlbumAño.Text = $"{c.Album} [{c.Año}]";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reproducir: " + ex.Message);
            }
        }
        private void btnPausa_Click(object sender, EventArgs e)
        {
            if (cancionActual == null)
            {
                ReproducirCancion(playlist.Cabeza.D);
            }
            if (player.Reproduciendo)
            {
                player.Pausar();
                btnPausa.Text = "▶️";
                pbBarraMusica.Image = Properties.Resources.pausa;
                lbEstadoCancion.Text = "En Pausa: ";
            }
            else if (player.Pausado)
            {
                player.Continuar();
                btnPausa.Text = "⏸️";
                pbBarraMusica.Image = Properties.Resources.barra_de_progreso;
                lbEstadoCancion.Text = "Reproduciendo:";
            }
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            listBoxPlaylist.ClearSelected();

            if (cancionActual == null)
            {
                if (playlist.Cabeza != null)// Primera vez: reproducir primera canción
                {
                    ReproducirCancion(playlist.Cabeza.D);
                }
                return;
            }
            var siguiente = playlist.Siguiente(cancionActual);
            if (siguiente == null)
            {
                MessageBox.Show("Ya estás en la última canción.");
                return;
            }

            ReproducirCancion(siguiente);
            cancionActual = siguiente;
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            listBoxPlaylist.ClearSelected();
            if (cancionActual == null) return;
            var anterior = playlist.Anterior(cancionActual);
            if (anterior == null)
            {
                MessageBox.Show("Ya estás en la primera canción.");
                return;
            }
            ReproducirCancion(anterior);
            cancionActual = anterior;
        }
        
        private void btnAddToQueue_Click(object sender, EventArgs e)
        {
            if (listBoxPlaylist.SelectedItem is Cancion c)
            {
                pila_favoritos.Apilar(c);
            }
            listBoxPlaylist.ClearSelected();
        }

        private void recomendarGénerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGrafo fg = new FormGrafo(grafo, Generos);
            fg.ShowDialog();
        }

        private void porAñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Busqueda ba = new Busqueda(biblioteca, 0);
            ba.ShowDialog();
        }
        

        private void porArtistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Busqueda ba = new Busqueda(biblioteca, 1);
            ba.ShowDialog();
        }

        private void porNombreDeCancionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Busqueda ba = new Busqueda(biblioteca, 2);
            ba.ShowDialog();
        }

        private void porAlbumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Busqueda ba = new Busqueda(biblioteca, 3);
            ba.ShowDialog();
        }

        private void historialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormHistorial his = new FormHistorial(cola_historial);
            his.ShowDialog();//culpable o no
        }

        private void favoritosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFavoritos f_fav = new FormFavoritos(pila_favoritos);
            f_fav.ShowDialog();
        }
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Universidad Privada del Norte\n\nEstructura de Datos (2025-2)\nExamen Final\n" +
                "\nDocente:\nCésar Ordoñez\n\nGrupo 1:" +
                "\n -Paul Roberto Becerra Cardenas\n -Juan Esteban Vera Palma\n -Ronaldo Tanta Luicho" +
                "\n\n\t\tCajamarca, diciembre de 2025");
        }
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listBoxPlaylist.SelectedItem is Cancion c)
            {
                playlist.Eliminar(c);
                LlenadoLista();
            }
            else
            {
                MessageBox.Show("Selecciona una canción.");
            }
            listBoxPlaylist.ClearSelected();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)// Al cerrar el form, liberar recursos
        {
            base.OnFormClosing(e);
            //aqui usamos lo que dijimos en la clase ReproductorMP3 para liberar recursos del sistema con el IDisposable
            player?.Dispose();
        }
    }
}

