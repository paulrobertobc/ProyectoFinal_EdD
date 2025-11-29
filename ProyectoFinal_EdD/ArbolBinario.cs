using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_EdD
{
    public class ArbolBinario
    {
        public class Nodo
        {
            public int D;
            public Nodo Iz;
            public Nodo Der;
            public Nodo (int D)
            {
                this.D = D;
            }
        }

        public Nodo raiz;
        public int cont = 0;
        public void Insertar(ref Nodo raiz, int valor)
        {
            if (raiz == null)
            {
                Nodo nuevo = new Nodo(valor);
                raiz = nuevo;
                cont++;
            }
            else
            {
                if (valor < raiz.D) Insertar(ref raiz.Iz, valor);
                else if (valor > raiz.D) Insertar(ref raiz.Der, valor);
                else Console.WriteLine("Dato duplicado.");
            }
        }
        public void ImprimirArbol(Nodo raiz, int espacio)
        {
            if (raiz == null) return;
            else
            {
                ImprimirArbol(raiz.Der, espacio + 1);
                for (int i = 0; i < espacio; i++)
                {
                    Console.Write("    ");
                }
                Console.WriteLine($"[{raiz.D}]");
                ImprimirArbol(raiz.Iz, espacio + 1);
            }
        }
        public Nodo EncontrarMinimo(Nodo nodo)
        {
            while (nodo.Iz != null)
            {
                nodo = nodo.Iz;
            }
            return nodo;
        }
        public Nodo EncontrarMaximo(Nodo nodo)
        {
            while (nodo.Der != null)
            {
                nodo = nodo.Der;
            }
            return nodo;
        }
        public void BuscarABB(Nodo raiz, int valor)
        {
            if (raiz == null)
            {
                Console.WriteLine("No encontrado.");
                return;
            }
            else
            {
                if (valor < raiz.D) BuscarABB(raiz.Iz, valor);
                else if (valor > raiz.D) BuscarABB(raiz.Der, valor);
                else Console.WriteLine($"{raiz.D} fue econtrado.");
            }
        }
        public Nodo Eliminar(Nodo raiz, int e)
        {
            if (raiz == null)
            {
                Console.WriteLine("No encontrado.");
                return null;
            }
            if (e < raiz.D) raiz.Iz = Eliminar(raiz.Iz, e);
            else if (e > raiz.D) raiz.Der = Eliminar(raiz.Der, e);
            else
            {
                if (raiz.Iz == null && raiz.Der == null) return null;
                else if (raiz.Iz != null && raiz.Der == null) return raiz.Iz;
                else if (raiz.Iz == null && raiz.Der != null) return raiz.Der;
                else
                {
                    Nodo sucesor = EncontrarMinimo(raiz.Der);
                    raiz.D = sucesor.D;
                    raiz.Der = Eliminar(raiz.Der, sucesor.D);
                }
            }
            return raiz;
        }
        public bool esVacio() => raiz == null;
    }
}
