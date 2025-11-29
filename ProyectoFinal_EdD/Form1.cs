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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public ListaEnlazada<string> lista = new ListaEnlazada<string>();
        public Pila<int> pila = new Pila<int>();
        public Cola<int> cola = new Cola<int>();
        public ArbolBinario arbol = new ArbolBinario();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnencolar_Click(object sender, EventArgs e)
        {
            pila.Apilar(int.Parse(tbpila.Text));
            llenadopila();
        }
        public void llenadopila()
        {
            listBox1.Items.Clear();
            foreach (var item in pila.ObtenerElementos())
            {
                listBox1.Items.Add(item);
            }
        }

        private void btndesencolar_Click(object sender, EventArgs e)
        {
            pila.Desapilar();
            llenadopila();
        }

        private void btnencolar_Click_1(object sender, EventArgs e)
        {
            cola.Encolar(int.Parse(tbpila.Text));
            llenadocola();
        }
        public void llenadocola()
        {
            listBox2.Items.Clear();
            foreach (var item in cola.ObtenerElementos())
            {
                listBox2.Items.Add(item);
            }

        }
        private void btndesencolar_Click_1(object sender, EventArgs e)
        {
            cola.Desencolar();
            llenadocola();
        }
        public void ejemplodijjstra()
        {
            Grafo g = new Grafo(5);

            g.crearArista(0, 1, 2);
            g.crearArista(0, 2, 5);
            g.crearArista(1, 3, 1);
            g.crearArista(2, 3, 2);
            g.crearArista(3, 4, 3);

            var (dist, previo) = g.Dijkstra(0);

            Console.WriteLine("Distancia al nodo 4: " + dist[4]);

            List<int> ruta = g.ReconstruirRuta(previo, 4);
            Console.WriteLine("Ruta: " + string.Join(" -> ", ruta));

        }
    }
}
