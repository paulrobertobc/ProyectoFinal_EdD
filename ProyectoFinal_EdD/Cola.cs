using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_EdD
{
    public class Cola<T>
    {
        private class Nodo
        {
            public T D;
            public Nodo S;
            public Nodo(T D) 
            {
                this.D = D;
            }
        }

        private Nodo frente;
        private Nodo final;
        public int Count 
        { 
            get;
            private set;
        }

        public void Encolar(T dato)
        {
            Nodo nuevo = new Nodo(dato);
            if (final == null)
            {
                frente = final = nuevo;
            }
            else
            {
                final.S = nuevo;
                final = nuevo;
            }
            Count++;
        }

        public T Desencolar()
        {
            if (frente == null) throw new Exception("La cola está vacía");
            var dato = frente.D;
            frente = frente.S;
            if (frente == null) final = null;
            Count--;
            return dato;
        }

        public T Peek()
        {
            if (frente == null) throw new Exception("La cola está vacía");
            return frente.D;
        }
        //con esto puede convertirlo a lista, darle foreach, integrarlo a LINQ, etc.
        public IEnumerable<T> ObtenerElementos()
        {
            Nodo actual = frente;
            while (actual != null)
            {
                yield return actual.D;
                actual = actual.S;
            }
        }
        public void ImprimirCola()
        {
            Nodo actual = frente;
            while (actual != null)
            {
                Console.WriteLine(actual.D);
                actual = actual.S;
            }
        }
        public bool EstaVacia() => frente == null;
    }

}
