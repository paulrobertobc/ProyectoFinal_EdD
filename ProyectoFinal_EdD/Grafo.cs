using ProyectoFinal_EdD;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_EdD_Grafo
{
    public class Grafo
    {
        private int[,] mAdya;
        private int[] indegree;
        private int nodos;

        public Grafo(int nodos)
        {
            this.nodos = nodos;
            mAdya = new int[nodos, nodos];
            indegree = new int[nodos];
        }
        public void CrearArista(int nodoI, int nodoF, int peso)
        {
            mAdya[nodoI, nodoF] = peso;
        }

        public int ObtenerPeso(int f, int c) => mAdya[f, c];

        public int[,] ObtenerMatriz() => mAdya;
    }
    ////////////////Dijjstra////////////////////
    public class Dijkstra
    {
        private Grafo grafo;

        public Dijkstra(Grafo grafo)
        {
            this.grafo = grafo;
        }

        public void BuscarRuta(int inicio, int fin, int cantNodos)
        {
            int[,] tabla = new int[cantNodos, 3];
            const int VISITADO = 0;
            const int DIST = 1;
            const int PREV = 2;

            for (int i = 0; i < cantNodos; i++)
            {
                tabla[i, VISITADO] = 0;
                tabla[i, DIST] = int.MaxValue;
                tabla[i, PREV] = -1;
            }

            tabla[inicio, DIST] = 0;

            int actual = inicio;

            do
            {
                tabla[actual, VISITADO] = 1;

                for (int col = 0; col < cantNodos; col++)
                {
                    int peso = grafo.ObtenerPeso(actual, col);

                    if (peso > 0)
                    {
                        int nuevaDist = tabla[actual, DIST] + peso;

                        if (nuevaDist < tabla[col, DIST])
                        {
                            tabla[col, DIST] = nuevaDist;
                            tabla[col, PREV] = actual;
                        }
                    }
                }

                int menorDist = int.MaxValue;
                int menorNodo = -1;

                for (int i = 0; i < cantNodos; i++)
                {
                    if (tabla[i, VISITADO] == 0 && tabla[i, DIST] < menorDist)
                    {
                        menorDist = tabla[i, DIST];
                        menorNodo = i;
                    }
                }

                actual = menorNodo;

            } while (actual != -1);
            ListaEnlazada<int> ruta = new ListaEnlazada<int>();
            int nodo = fin;

            if (tabla[fin, DIST] == int.MaxValue)
            {
                Console.WriteLine("No existe ruta.");
                return;
            }

            while (nodo != -1)
            {
                ruta.Insertar(nodo);
                nodo = tabla[nodo, PREV];
            }

            ruta.Reverse();
            Console.WriteLine(string.Join(" -> ", ruta));
        }
    }
    ////////////Floy-Warshall/////////////////////
    public class FloydWarshall
    {
        private Grafo grafo;

        public FloydWarshall(Grafo grafo)
        {
            this.grafo = grafo;
        }

        public ResultadoFloyd BuscarRuta(int n)
        {
            int[,] original = grafo.ObtenerMatriz();
            int[,] dist = new int[n, n];
            bool[,] alcanzable = new bool[n, n];

            const int INF = int.MaxValue / 2;

            // Copiar matriz
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        dist[i, j] = 0;
                        alcanzable[i, j] = true;
                    }
                    else if (original[i, j] > 0)
                    {
                        dist[i, j] = original[i, j];
                        alcanzable[i, j] = true;
                    }
                    else
                    {
                        dist[i, j] = INF;
                        alcanzable[i, j] = false;
                    }
                }
            }

            // Algoritmo Floyd
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                            alcanzable[i, j] = true;
                        }
                    }
                }
            }

            return new ResultadoFloyd()
            {
                Distancias = dist,
                Alcanzable = alcanzable,
                N = n
            };
        }

    }
    public class ResultadoFloyd
    {
        public int[,] Distancias { get; set; }
        public bool[,] Alcanzable { get; set; }
        public int N { get; set; }
    }
}
