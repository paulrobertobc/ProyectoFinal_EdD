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
    public partial class FormFavoritos : Form
    {
        private Pila<Cancion> favoritos;
        public FormFavoritos(Pila<Cancion> favoritos)
        {
            InitializeComponent();
            this.favoritos = favoritos;
            MostrarFavoritos();
        }
        public void MostrarFavoritos()
        {
            lbFav.Items.Clear();
            foreach (var cancion in favoritos.ObtenerElementos())
            {
                lbFav.Items.Add($"{cancion.Titulo} - {cancion.Artista} ({cancion.Año})");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
