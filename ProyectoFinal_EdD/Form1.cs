using ProyectoFinal_EdD_Grafo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using TagLib; // TagLibSharp

namespace ProyectoFinal_EdD
{
    public partial class Form1 : Form
    {
        private ListaEnlazada<Cancion> lista_playlist = new ListaEnlazada<Cancion>();
        private Pila<Cancion> pila_reproduccion = new Pila<Cancion>();
        private Cola<Cancion> cola_reproduccion = new Cola<Cancion>();
        private Pila<Cancion> pila_favoritos = new Pila<Cancion>();
        private Cola<Cancion> cola_historial = new Cola<Cancion>();
        private ArbolBinario<Cancion> biblioteca = new ArbolBinario<Cancion>();
        private Cancion cancionActual = null;
        private Dictionary<int, string> Generos = new Dictionary<int, string>();
        private ReproductorMP3 player = new ReproductorMP3();
        private Grafo grafo;
        private SynchronizationContext uiContext;
        private CancellationTokenSource playCancellation;
        private readonly object playLock = new object();

        public Form1()
        {
            InitializeComponent();
            InicializarGeneros();
            InicializarGrafoMusical();
            uiContext = SynchronizationContext.Current;
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
            int[,] mat = g.ObtenerMatriz();
            int oldSize = mat.GetLength(0);
            // Determinar nuevo tamaño: al menos uno más que el anterior,
            // y suficiente para contener la cantidad actual de géneros
            int newSize = Math.Max(oldSize + 1, Generos.Count);

            Grafo nuevo = new Grafo(newSize);

            // Copiar la matriz vieja en la nueva sin acceder fuera de límites
            for (int i = 0; i < oldSize; i++)
            {
                for (int j = 0; j < oldSize; j++)
                {
                    nuevo.CrearArista(i, j, mat[i, j]);
                }
            }

            return nuevo;
        }
        private void Player_PlaybackStopped(object sender, EventArgs e)
        {
            // Al terminar una canción, reproducir siguiente de la lista enlazada playlist
            uiContext.Post(_ =>
            {
                var siguiente = lista_playlist.Siguiente(cancionActual);
                if (siguiente != null)
                    ReproducirCancion(siguiente);

            }, null);
        }

        private void agregarArchivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())//abrimos openfiledialog para leer archivos mp3
            {
                of.Filter = "Archivos de audio|*.mp3;*.wav;*.flac;*.m4a";
                of.Multiselect = true;
                if (of.ShowDialog() != DialogResult.OK) return;
                var errores = new List<string>();
                foreach (var ruta in of.FileNames)// aqui vamos a leer los metadatos de la canción en mp3 usando TagLibSharp
                {
                    try
                    {
                        using (var t = TagLib.File.Create(ruta))
                        {
                            var titulo = t.Tag.Title ?? Path.GetFileNameWithoutExtension(ruta);
                            var artista = t.Tag.FirstPerformer ?? "Desconocido";
                            var genero = t.Tag.FirstGenre ?? "Indefinido";
                            var año = (int)(t.Tag.Year);
                            var album = t.Tag.Album ?? "Desconocido";

                            // No expandir el grafo por cada archivo: solo expandir si agregamos un nuevo género
                            genero = genero.Trim();
                            int id;

                            if (Generos.Values.Contains(genero, StringComparer.OrdinalIgnoreCase))// Verificar si ya existe el género
                            {
                                id = Generos.First(g => g.Value.Equals(genero, StringComparison.OrdinalIgnoreCase)).Key;// Si existe, obtener su ID existente
                            }
                            else
                            {
                                id = Generos.Count; // Si NO existe, crear nuevo (id será el índice del nuevo género)
                                Generos.Add(id, genero);
                                // Como cambia la cantidad de nodos, expandimos el grafo una sola vez
                                grafo = ExpandirGrafo(grafo);
                            }
                            var c = new Cancion
                            {
                                Titulo = titulo, Artista = artista, Año = año, Album = album, Genero = genero, Ruta = ruta
                            };
                            lista_playlist.Insertar(c);
                            biblioteca.Insertar(c);
                        }
                    }
                    catch (Exception ex)
                    {
                        errores.Add($"{Path.GetFileName(ruta)}: {ex.Message}");
                    }
                }
                // Actualizar la interfaz solo una vez después de procesar todos los archivos
                LlenadoLista();

                if (errores.Count > 0)
                {
                    // Mostrar un único resumen de errores para no abrumar con múltiples popups
                    var resumen = string.Join("\n", errores.Take(10));
                    if (errores.Count > 10) resumen += $"\n... y {errores.Count - 10} más";
                    MessageBox.Show($"Algunos archivos no se pudieron leer:\n{resumen}", "Errores al agregar archivos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public void LlenadoLista()
        {
            listBoxPlaylist.Items.Clear();
            foreach (var cancion in lista_playlist)
            {
                listBoxPlaylist.Items.Add(cancion);
            }
        }
        private void listBoxPlaylist_DoubleClick(object sender, EventArgs e)
        {
            /*if (listBoxPlaylist.SelectedItem is Cancion c)
            {
                ReproducirCancion(c);
            }
            else
            {
                var s2 = cancionActual;
                if (s2 != null) ReproducirCancion(s2);
            }*/



            cancionActual = listBoxPlaylist.SelectedItem as Cancion;
            ReproducirCancion(cancionActual);


            listBoxPlaylist.ClearSelected();
        }
        private void ReproducirCancion(Cancion c)
        {
            cancionActual = c;

            if (c == null) return;

            try
            {
                var cancionLocal = c;

                // Cancelar cualquier tarea previa de carga de carátula
                lock (playLock)
                {
                    playCancellation?.Cancel();
                    playCancellation = new CancellationTokenSource();
                }
                var token = playCancellation.Token;

                // Reproducir de forma síncrona (método es thread-safe internamente)
                try
                {
                    player.Reproducir(cancionLocal.Ruta);
                }
                catch (Exception exPlay)
                {
                    Debug.WriteLine("Error al iniciar reproducción: " + exPlay);
                    return;
                }

                // Actualizar UI inmediato con datos básicos
                uiContext.Post(_ =>
                {
                    try
                    {
                        lblNombreCancion.Text = $"{cancionLocal.Titulo}";
                        lbArtistaCancion.Text = $"{cancionLocal.Artista}";
                        lbGenero.Text = $"{cancionLocal.Genero}";
                        lbAlbumAño.Text = $"{cancionLocal.Album} [{cancionLocal.Año}]";
                        pbBarraMusica.Image = Properties.Resources.barra_de_progreso;
                    }
                    catch (Exception uiEx)
                    {
                        Debug.WriteLine("Error al actualizar la interfaz: " + uiEx);
                    }
                }, null);

                // Cargar la carátula en background
                Task.Run(() =>
                {
                    try
                    {
                        if (token.IsCancellationRequested) return;
                        var imagen = player.ObtenerCaratula(cancionLocal.Ruta) ?? Properties.Resources.nave;
                        if (token.IsCancellationRequested) return;
                        uiContext.Post(_ =>
                        {
                            try
                            {
                                if (token.IsCancellationRequested) return;
                                cola_historial.Encolar(cancionLocal);
                                pbCaratula.Image = imagen;
                            }
                            catch (Exception uiEx)
                            {
                                Debug.WriteLine("Error al actualizar la interfaz (caratula): " + uiEx);
                            }
                        }, null);
                    }
                    catch (Exception exBg)
                    {
                        Debug.WriteLine("Error al cargar carátula en segundo plano: " + exBg);
                    }
                }, token);
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
                if (lista_playlist.Cabeza != null)
                {
                    ReproducirCancion(lista_playlist.Cabeza.D);
                }
                else
                {
                    // No hay canciones en la lista
                    return;
                }
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
                if (lista_playlist.Cabeza != null)// Primera vez: reproducir primera canción
                {
                    ReproducirCancion(lista_playlist.Cabeza.D);
                }
                return;
            }
            //var siguiente = playlist.Siguiente(cancionActual);
            cancionActual = lista_playlist.Siguiente(cancionActual);

            ReproducirCancion(cancionActual);
            //cancionActual = siguiente;
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            listBoxPlaylist.ClearSelected();
            if (cancionActual == null) return;
            var anterior = lista_playlist.Anterior(cancionActual);
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
                lista_playlist.Eliminar(c);
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
            // Limpiar y liberar recursos relacionados con la reproducción
            try
            {
                // Cancelar cualquier carga en background y liberar el token
                lock (playLock)
                {
                    playCancellation?.Cancel();
                    playCancellation?.Dispose();
                    playCancellation = null;
                }
            }
            catch { }

            // Desuscribirse del evento y liberar el reproductor
            if (player != null)
            {
                try { player.PlaybackStopped -= Player_PlaybackStopped; } catch { }
                player.Dispose();
                player = null;
            }
        }
    }
}

