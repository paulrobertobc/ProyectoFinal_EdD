using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_EdD
{
    public class ArbolBinario<T> where T : IComparable<T>
    {
        public class Nodo
        {
            public T Dato;
            public Nodo Iz;
            public Nodo Der;

            public Nodo(T dato)
            {
                Dato = dato;
            }
        }

        public Nodo raiz;
        public int Count { get; private set; }

        public void Insertar(T valor)
        {
            InsertarR(ref raiz, valor);
        }

        private void InsertarR(ref Nodo r, T valor)
        {
            if (r == null)
            {
                r = new Nodo(valor);
                Count++;
                return;
            }

            int cmp = valor.CompareTo(r.Dato);

            if (cmp < 0) InsertarR(ref r.Iz, valor);
            else if (cmp > 0) InsertarR(ref r.Der, valor);
            else
                Console.WriteLine("Dato duplicado.");
        }
        public void ImprimirArbol(Nodo raiz, int espacio)
        {
            if (raiz == null) return;

            ImprimirArbol(raiz.Der, espacio + 1);

            for (int i = 0; i < espacio; i++)
                Console.Write("    ");

            Console.WriteLine($"[{raiz.Dato}]");

            ImprimirArbol(raiz.Iz, espacio + 1);
        }
        public List<T> Buscar(Func<T, bool> criterio)
        {
            List<T> resultados = new List<T>();
            BuscarRec(raiz, criterio, resultados);
            return resultados;
        }

        private void BuscarRec(Nodo nodo, Func<T, bool> criterio, List<T> resultados)
        {
            if (nodo == null) return;

            BuscarRec(nodo.Iz, criterio, resultados);

            if (criterio(nodo.Dato))
                resultados.Add(nodo.Dato);

            BuscarRec(nodo.Der, criterio, resultados);
        }

        public void Eliminar(T valor)
        {
            raiz = Eliminar(raiz, valor);
        }

        private Nodo Eliminar(Nodo r, T valor)
        {
            if (r == null) return null;

            int cmp = valor.CompareTo(r.Dato);

            if (cmp < 0)
                r.Iz = Eliminar(r.Iz, valor);
            else if (cmp > 0)
                r.Der = Eliminar(r.Der, valor);
            else
            {
                if (r.Iz == null) return r.Der;
                if (r.Der == null) return r.Iz;

                Nodo sucesor = EncontrarMinimo(r.Der);
                r.Dato = sucesor.Dato;
                r.Der = Eliminar(r.Der, sucesor.Dato);
            }

            return r;
        }

        public Nodo EncontrarMinimo(Nodo nodo)
        {
            while (nodo?.Iz != null)
                nodo = nodo.Iz;
            return nodo;
        }

        public Nodo EncontrarMaximo(Nodo nodo)
        {
            while (nodo?.Der != null)
                nodo = nodo.Der;
            return nodo;
        }
        public bool EsVacio() => raiz == null;
    }

}