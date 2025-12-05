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

namespace ProyectoFinal_EdD
{
    public partial class FormGrafo : Form
    {
        Grafo grafo;
        Dictionary<int, string> Generos = new Dictionary<int, string>();
        ResultadoFloyd r;
        public FormGrafo(Grafo grafo, Dictionary<int, string> Generos)
        {
            InitializeComponent();
            this.grafo = grafo;
            this.Generos = Generos;
            CargarGenerosEnListas();
            crearDGV();
            MostrarMatrizAdyacencia();
            actualizarFloyd();

        }
        public void crearDGV()
        {
            dgvMatriz.AllowUserToAddRows = false;
            dgvMatriz.AllowUserToDeleteRows = false;
            dgvMatriz.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatriz.Name = "dgvMatriz";
            dgvMatriz.ReadOnly = true;
            dgvMatriz.RowTemplate.Height = 24;
            dgvMatriz.TabIndex = 13;
        }
        void CargarGenerosEnListas()
        {
            cmbInicio.Items.Clear();
            cmbFin.Items.Clear();
            cmbOrigen.Items.Clear();
            cmbDestino.Items.Clear();
            lstGeneros.Items.Clear();

            foreach (var g in Generos)
            {
                string linea = $"{g.Key} - {g.Value}";

                cmbInicio.Items.Add(linea);
                cmbFin.Items.Add(linea);
                cmbOrigen.Items.Add(linea);
                cmbDestino.Items.Add(linea);
                lstGeneros.Items.Add(linea);
            }
        }

        private void btnCrearRelacion_Click(object sender, EventArgs e)
        {
            if (cmbOrigen.SelectedIndex < 0 || cmbDestino.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione origen y destino");
                return;
            }

            int origen = cmbOrigen.SelectedIndex;
            int destino = cmbDestino.SelectedIndex;
            int peso = (int)numPeso.Value;

            grafo.CrearArista(origen, destino, peso);
            MostrarMatrizAdyacencia();
            actualizarFloyd();
            MostrarFloydEnDataGrid(r);

            MessageBox.Show("Relación creada.");
        }

        private void btnDijkstra_Click(object sender, EventArgs e)
        {
            int inicio = cmbInicio.SelectedIndex;
            int fin = cmbFin.SelectedIndex;

            if (inicio < 0 || fin < 0)
            {
                MessageBox.Show("Seleccione inicio y fin.");
                return;
            }

            listBoxResultados.Items.Clear();

            // Redirigir la consola a un buffer temporal
            using (var sw = new System.IO.StringWriter())
            {
                var writer = new System.IO.StringWriter();
                Console.SetOut(writer);

                Dijkstra d = new Dijkstra(grafo);
                d.BuscarRuta(inicio, fin, Generos.Count);

                // Recuperar toda la salida
                string texto = writer.ToString();

                // Separar en líneas
                string[] lineas = texto.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

                // Enviar cada línea al ListBox
                foreach (string l in lineas)
                {
                    listBoxResultados.Items.Add(l);
                }
                    
            }
        }

        private void btnFloyd_Click(object sender, EventArgs e)
        {
            actualizarFloyd();
        }
        public void actualizarFloyd()
        {
            FloydWarshall fw = new FloydWarshall(grafo);
            r = fw.BuscarRuta(Generos.Count);

            MostrarFloydEnDataGrid(r);

            listBoxResultados.Items.Clear();
            listBoxResultados.Items.Add("Floyd–Warshall ejecutado.");
        }
        private void MostrarMatrizAdyacencia() //le vamos a poner colores
        {
            int n = Generos.Count;
            int[,] mat = grafo.ObtenerMatriz();

            dgvMatriz.Columns.Clear();
            dgvMatriz.Rows.Clear();
            dgvMatriz.RowHeadersWidth = 120;

            // Crear columnas
            for (int i = 0; i < n; i++)
            {
                dgvMatriz.Columns.Add("col" + i, Generos[i]);
            }

            // Llenar filas
            for (int i = 0; i < n; i++)
            {
                dgvMatriz.Rows.Add();
                dgvMatriz.Rows[i].HeaderCell.Value = Generos[i];

                for (int j = 0; j < n; j++)
                {
                    int v = mat[i, j];
                    var cell = dgvMatriz.Rows[i].Cells[j];

                    // Sin conexión = INF (salvo diagonal)
                    if (v == 0 && i != j)
                    {
                        cell.Value = "INF";
                        cell.Style.BackColor = Color.FromArgb(255, 204, 204); // rojo claro
                    }
                    else
                    {
                        cell.Value = (i == j ? "0" : v.ToString());

                        // Diagonal (0)
                        if (i == j)
                        {
                            cell.Style.BackColor = Color.FromArgb(220, 220, 220); // gris
                        }
                        // Distancia pequeña (1–5)
                        else if (v > 0 && v <= 5)
                        {
                            cell.Style.BackColor = Color.FromArgb(204, 255, 204); // verde claro
                        }
                        // Distancia media (6–10)
                        else if (v > 5 && v <= 10)
                        {
                            cell.Style.BackColor = Color.FromArgb(255, 247, 192); // amarillo
                        }
                        // Distancia grande
                        else if (v > 10)
                        {
                            cell.Style.BackColor = Color.FromArgb(255, 217, 179); // naranja claro
                        }
                    }
                }
            }

            dgvMatriz.AutoResizeColumns();
            dgvMatriz.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dgvMatriz.AllowUserToAddRows = false;
        }

        private void MostrarFloydEnDataGrid(ResultadoFloyd r)
        {
            dataGridViewMatriz.Columns.Clear();
            dataGridViewMatriz.Rows.Clear();
            dataGridViewMatriz.RowHeadersWidth = 120;

            // Crear columnas
            for (int i = 0; i < r.N; i++)
            {
                dataGridViewMatriz.Columns.Add("col" + i, Generos[i]);
            }

            // Agregar filas con colores
            for (int i = 0; i < r.N; i++)
            {
                dataGridViewMatriz.Rows.Add();
                dataGridViewMatriz.Rows[i].HeaderCell.Value = Generos[i];

                for (int j = 0; j < r.N; j++)
                {
                    int v = r.Distancias[i, j];

                    DataGridViewCell cell = dataGridViewMatriz.Rows[i].Cells[j];

                    // INF
                    if (v >= int.MaxValue / 3)
                    {
                        cell.Value = "INF";
                        cell.Style.BackColor = Color.FromArgb(255, 204, 204);  // rojo claro
                    }
                    else
                    {
                        cell.Value = v.ToString();

                        // Distancia 0 diagonal
                        if (i == j)
                        {
                            cell.Style.BackColor = Color.FromArgb(220, 220, 220); // gris
                        }
                        // Distancias pequeñas
                        else if (v <= 5)
                        {
                            cell.Style.BackColor = Color.FromArgb(204, 255, 204); // verde claro
                        }
                        // Distancias medias
                        else if (v <= 10)
                        {
                            cell.Style.BackColor = Color.FromArgb(255, 247, 192); // amarillo
                        }
                        // Distancias largas
                        else
                        {
                            cell.Style.BackColor = Color.FromArgb(255, 217, 179); // naranja claro
                        }
                    }
                }
            }

            dataGridViewMatriz.AutoResizeColumns();
            dataGridViewMatriz.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dataGridViewMatriz.AllowUserToAddRows = false;
        }
        private void btnMatriz_Click(object sender, EventArgs e)
        {
            MostrarMatrizAdyacencia();
        }
    }
}
