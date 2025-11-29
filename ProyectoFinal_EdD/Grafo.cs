using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_EdD
{
    public class Grafo
    {
        int[,] mAdya;        // Matriz de adyacencia (pesos)
        int[] indegree;
        int nodos;

        public Grafo(int nodos)
        {
            this.nodos = nodos;
            mAdya = new int[nodos, nodos];
            indegree = new int[nodos];
        }

        public void crearArista(int nodoI, int nodoF)
        {
            mAdya[nodoI, nodoF] = 1;
        }

        public void crearArista(int nodoI, int nodoF, int peso)
        {
            mAdya[nodoI, nodoF] = peso;
        }

        public void mostrarAdyacencia()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < this.nodos; i++)
            {
                Console.Write("\t{0}", i);
            }
            Console.WriteLine(" ");

            for (int i = 0; i < this.nodos; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(i);
                for (int j = 0; j < this.nodos; j++)
                {
                    if (mAdya[i, j] > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\t{0}", mAdya[i, j]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\t{0}", mAdya[i, j]);
                    }
                }
                Console.WriteLine(" ");
            }
            Console.ResetColor();
        }

        public int obtenerAdyacencia(int f, int c) => mAdya[f, c];

        public void calcularIndegree()
        {
            for (int i = 0; i < this.nodos; i++)
            {
                for (int j = 0; j < this.nodos; j++)
                {
                    if (mAdya[j, i] > 0) indegree[i]++;
                }
            }
        }

        public void mostrarIndegree()
        {
            for (int i = 0; i < this.nodos; i++)
            {
                Console.WriteLine("Nodo {0}: {1}", i, indegree[i]);
            }
        }

        public int encontrarNodoSinArista()
        {
            bool busqueda = false;
            int i = 0;
            for (i = 0; i < this.nodos; i++)
            {
                if (indegree[i] > 0)
                {
                    busqueda = true;
                    break;
                }
            }
            if (busqueda) return i;
            else return -1;
        }

        public void decrementarIndegree(int nodo)
        {
            indegree[nodo] = -1;
            for (int i = 0; i < this.nodos; i++)
            {
                if (mAdya[nodo, i] > 1) indegree[i]--;
            }
        }

        // ============================================================
        // =====================    NUEVO    ==========================
        // ============================================================

        // NUEVO: Obtener lista de vecinos de un nodo
        public List<int> ObtenerVecinos(int nodo)
        {
            List<int> vecinos = new List<int>();
            for (int i = 0; i < nodos; i++)
            {
                if (mAdya[nodo, i] > 0)  // hay arista
                    vecinos.Add(i);
            }
            return vecinos;
        }

        // NUEVO: Validar que un nodo exista
        public bool NodoValido(int nodo)
        {
            return nodo >= 0 && nodo < nodos;
        }


        // ============================================================
        // =====================   DIJKSTRA   ==========================
        // ============================================================
        public (int[] dist, int[] previo) Dijkstra(int origen)
        {
            if (!NodoValido(origen))
                throw new Exception("Nodo origen fuera de rango.");

            int[] dist = new int[nodos];     // distancias mínimas
            bool[] visitado = new bool[nodos]; // nodos ya procesados
            int[] previo = new int[nodos];   // para reconstruir la ruta

            const int INF = int.MaxValue;

            // Inicializar
            for (int i = 0; i < nodos; i++)
            {
                dist[i] = INF;
                previo[i] = -1;
                visitado[i] = false;
            }

            dist[origen] = 0;

            // Procesamos los nodos
            for (int _ = 0; _ < nodos - 1; _++)
            {
                // 1. Elegir el nodo con la distancia mínima NO visitado
                int u = MinDistancia(dist, visitado);
                if (u == -1) break; // No quedan alcanzables

                visitado[u] = true;

                // 2. Relajar a los vecinos
                for (int v = 0; v < nodos; v++)
                {
                    int peso = mAdya[u, v];

                    // si existe arista y no está visitado
                    if (peso > 0 && !visitado[v])
                    {
                        // si se encuentra un camino mejor
                        if (dist[u] != INF && dist[u] + peso < dist[v])
                        {
                            dist[v] = dist[u] + peso;
                            previo[v] = u; // Para reconstruir la ruta
                        }
                    }
                }
            }

            return (dist, previo);
        }

        // NUEVO: Método auxiliar para encontrar el nodo con menor distancia
        private int MinDistancia(int[] dist, bool[] visitado)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < nodos; i++)
            {
                if (!visitado[i] && dist[i] <= min)
                {
                    min = dist[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        // NUEVO: Reconstruir ruta óptima desde origen a destino
        public List<int> ReconstruirRuta(int[] previo, int destino)
        {
            List<int> ruta = new List<int>();

            for (int actual = destino; actual != -1; actual = previo[actual])
                ruta.Add(actual);

            ruta.Reverse();
            return ruta;
        }
    }
}
