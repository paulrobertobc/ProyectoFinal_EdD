using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_EdD
{
    public class ListaEnlazada<T> : IEnumerable<T>
    {
        private class Nodo
        {
            public T D { get; set; }
            public Nodo S { get; set; }
            public Nodo A { get; set; }
            public Nodo(T D)
            {
                this.D = D;
            }
        }
        private Nodo Cabeza;
        private Nodo Actual { get; set; }
        public int cont { get; private set; }
        public void Insertar(T valor)
        {
            var nuevo = new Nodo(valor);
            if (Cabeza == null)
            {
                Cabeza = nuevo;
                Cabeza.S = Cabeza;
                Cabeza.A = Cabeza;
                Actual = Cabeza;
            }
            else
            {
                var cola = Cabeza.A;
                cola.S = nuevo;
                nuevo.A = cola;
                nuevo.S = Cabeza;
                Cabeza.A = nuevo;
            }
            cont++;
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (Cabeza == null) yield break;
            var node = Cabeza;
            do
            {
                yield return node.D;
                node = node.S;
            } while (node != Cabeza);
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
