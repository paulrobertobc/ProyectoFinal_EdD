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

            grafo.CrearArista(origen, destino, peso);//creamos la arista en el grafo
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

            using (var sw = new System.IO.StringWriter())// vamos a redirigir la consola a un buffer temporal
            {
                var writer = new System.IO.StringWriter();
                Console.SetOut(writer);

                Dijkstra d = new Dijkstra(grafo); //ejecutamos el Dijkstra
                d.BuscarRuta(inicio, fin, Generos.Count);

                string texto = writer.ToString();// recupermaos toda la salida

                string[] lineas = texto.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);// separamos en varias líneas con el split

                foreach (string l in lineas)// estas lineas se las pasamos al listbox para conocer la ruta
                {
                    listBoxResultados.Items.Add(l);
                }
            }
        }
        private void btnMatriz_Click(object sender, EventArgs e)
        {
            MostrarMatrizAdyacencia();
        }
        private void MostrarMatrizAdyacencia() //le vamos a poner colores al dgv
        {
            int n = Generos.Count;
            int[,] mat = grafo.ObtenerMatriz();

            dgvMatriz.Columns.Clear();
            dgvMatriz.Rows.Clear();
            dgvMatriz.RowHeadersWidth = 120;

            for (int i = 0; i < n; i++)// aqui creamos las columnas
            {
                dgvMatriz.Columns.Add("col" + i, Generos[i]);
            }
            for (int i = 0; i < n; i++)// llenamos las filas con for
            {
                dgvMatriz.Rows.Add();
                dgvMatriz.Rows[i].HeaderCell.Value = Generos[i];

                for (int j = 0; j < n; j++)
                {
                    int v = mat[i, j];
                    var cell = dgvMatriz.Rows[i].Cells[j];

                    if (v == 0 && i != j)// este if es cuando no hay conexion
                    {
                        cell.Value = "INF";
                        cell.Style.BackColor = Color.FromArgb(255, 204, 204); // rojo claro
                    }
                    else
                    {
                        cell.Value = (i == j ? "0" : v.ToString());

                        if (i == j)// diagonal vacia
                        {
                            cell.Style.BackColor = Color.FromArgb(220, 220, 220); // gris
                        }
                        else if (v > 0 && v <= 5)// distancia pqueña (1 a 5)
                        {
                            cell.Style.BackColor = Color.FromArgb(204, 255, 204); // verde claro
                        }
                        else if (v > 5 && v <= 10)// distancia media (6 a 10)
                        {
                            cell.Style.BackColor = Color.FromArgb(255, 247, 192); // amarillo
                        }
                        else if (v > 10)// gran distancia
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
        private void MostrarFloydEnDataGrid(ResultadoFloyd r)//a esta también le ponemos colores
        {
            dataGridViewMatriz.Columns.Clear();
            dataGridViewMatriz.Rows.Clear();
            dataGridViewMatriz.RowHeadersWidth = 120;

            
            for (int i = 0; i < r.N; i++)// creamos las columnas como en la funcion anterior
            {
                dataGridViewMatriz.Columns.Add("col" + i, Generos[i]);
            }
            for (int i = 0; i < r.N; i++)
            {
                dataGridViewMatriz.Rows.Add();
                dataGridViewMatriz.Rows[i].HeaderCell.Value = Generos[i];

                for (int j = 0; j < r.N; j++)
                {
                    int v = r.Distancias[i, j];

                    DataGridViewCell cell = dataGridViewMatriz.Rows[i].Cells[j];

                    
                    if (v >= int.MaxValue / 3)// si es infinito
                    {
                        cell.Value = "INF";
                        cell.Style.BackColor = Color.FromArgb(255, 204, 204);  // rojo claro
                    }
                    else
                    {
                        cell.Value = v.ToString();

                        if (i == j)// diagonal vacia
                        {
                            cell.Style.BackColor = Color.FromArgb(220, 220, 220); // gris
                        }
                        else if (v <= 5)// distancia pequeña
                        {
                            cell.Style.BackColor = Color.FromArgb(204, 255, 204); // verde claro
                        }
                        else if (v <= 10)// distancia mediana
                        {
                            cell.Style.BackColor = Color.FromArgb(255, 247, 192); // amarillo
                        }
                        else// gran distancia
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
        
    }
}
