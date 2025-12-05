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
    public partial class FormHistorial : Form
    {
        Cola<Cancion> cola_historial;
        public FormHistorial(Cola<Cancion> cola_historial)
        {
            InitializeComponent();
            this.cola_historial = cola_historial;
            llenado();
        }
        public void llenado()
        {
            lbHistorial.Items.Clear();
            foreach (var cancion in cola_historial.ObtenerElementos())
            {
                lbHistorial.Items.Add($"{cancion.Titulo} - {cancion.Artista} | {cancion.Album} [{cancion.Año}]");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
