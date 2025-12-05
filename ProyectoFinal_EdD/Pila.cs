using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_EdD
{
    public class Pila<T>
    {
        private class Nodo
        {
            public T D;
            public Nodo S;
            public Nodo(T dato) 
            {
                D = dato; 
            }
        }

        private Nodo tope;
        public int Count 
        { 
            get; 
            private set; 
        }

        public void Apilar(T elemento)
        {
            var nuevo = new Nodo(elemento);
            nuevo.S = tope;
            tope = nuevo;
            Count++;
        }

        public T Desapilar()
        {
            if (tope == null) throw new Exception("La pila está vacía");

            var dato = tope.D;
            tope = tope.S;
            Count--;
            return dato;
        }

        public T Peek()
        {
            if (tope == null) throw new Exception("La pila está vacía");

            return tope.D;
        }
        public IEnumerable<T> ObtenerElementos()
        {
            Nodo actual = tope;
            while (actual != null)
            {
                yield return actual.D;
                actual = actual.S;
            }
        }
        public void ImprimirPila()
        {
            Nodo actual = tope;
            while (actual != null)
            {
                Console.WriteLine(actual.D);
                actual = actual.S;
            }
        }
        public bool EstaVacia() => tope == null;
    }

}
