using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_EdD
{
    public partial class Busqueda : Form
    {
        ArbolBinario<Cancion> biblioteca;
        int eleccion;
        public Busqueda(ArbolBinario<Cancion> biblioteca, int eleccion)
        {
            InitializeComponent();
            this.biblioteca = biblioteca;
            this.eleccion = eleccion;
            if (eleccion == 0) lblInstruccion.Text = "Ingrese el año de la canción:";
            if (eleccion == 1) lblInstruccion.Text = "Ingrese el artista de la canción:";
            if (eleccion == 2) lblInstruccion.Text = "Ingrese el nombre de la canción:";
            if (eleccion == 3) lblInstruccion.Text = "Ingrese el álbum de la canción:";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (eleccion == 0) BuscarAño();
            if (eleccion == 1) BuscarArtista();
            if (eleccion == 2) BuscarNombre();
            if (eleccion == 3) BuscarAlbum();
        }
        public void BuscarAño()
        {
            if (!int.TryParse(txtBusqueda.Text, out int añoBuscado))
            {
                MessageBox.Show("Ingrese un año válido.");
                return;
            }
            List<Cancion> resultados = biblioteca.Buscar(c => c.Año == añoBuscado);
            mostrarResultados(resultados);
        }
        public void BuscarArtista()
        {
            string artista = txtBusqueda.Text.Trim();
            List<Cancion> resultados = biblioteca.Buscar(c => c.Artista.Equals(artista, StringComparison.OrdinalIgnoreCase));
            mostrarResultados(resultados);
        }
        public void BuscarNombre()
        {
            string nombre = txtBusqueda.Text.Trim();
            List<Cancion> resultados = biblioteca.Buscar(c => c.Titulo.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            mostrarResultados(resultados);
        }
        public void BuscarAlbum()
        {
            string album = txtBusqueda.Text.Trim();
            List<Cancion> resultados = biblioteca.Buscar(c => c.Album.Equals(album, StringComparison.OrdinalIgnoreCase));
            mostrarResultados(resultados);
        }
        public void mostrarResultados(List<Cancion> resultados)
        {
            listBoxResultados.Items.Clear();

            if (resultados.Count == 0)
            {
                listBoxResultados.Items.Add("No se encontraron canciones.");
                return;
            }

            foreach (var cancion in resultados)
            {
                listBoxResultados.Items.Add($"{cancion.Titulo} - {cancion.Artista} | {cancion.Album} [{cancion.Año}]");
            }
        }
    }
}
