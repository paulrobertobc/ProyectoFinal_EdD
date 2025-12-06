using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_EdD
{
    //es circular doble, se usó el getenumerator para facilitar el uso con foreach y de esa forma imprimir la lista mas rapidamente
    public class ListaEnlazada<T> : IEnumerable<T>
    {
        public class Nodo
        {
            public T D { get; set; }
            public Nodo S { get; set; }
            public Nodo A { get; set; }

            public Nodo(T d) { D = d; }
        }

        public Nodo Cabeza;
        public Nodo cola;
        public int Cont { get; private set; }

        public void Insertar(T valor)
        {
            Nodo nuevo = new Nodo(valor);

            if (Cabeza == null)
            {
                Cabeza = nuevo;
                Cabeza.S = Cabeza;
                Cabeza.A = Cabeza;
            }
            else
            {
                cola = Cabeza.A;

                cola.S = nuevo;
                nuevo.A = cola;

                nuevo.S = Cabeza;
                Cabeza.A = nuevo;
            }

            Cont++;
        }
        public Nodo BuscarNodo(T dato)
        {
            var aux = Cabeza;
            while (aux != null)
            {
                if (aux.D.Equals(dato))
                    return aux;
                aux = aux.S;
            }
            return null;
        }

        public T Siguiente(T actual)
        {
            var nodo = BuscarNodo(actual);
            if (nodo.S == null) return default;
            else return nodo.S.D;
        }

        public T Anterior(T actual)
        {
            var nodo = BuscarNodo(actual);
            if (nodo.A == null) return default;
            else return nodo.A.D;

        }
        public void Eliminar(T dato)
        {
            var nodoAEliminar = BuscarNodo(dato);
            if (nodoAEliminar == null) return;
            if (nodoAEliminar == Cabeza && Cont == 1)
            {
                Cabeza = null;
            }
            else
            {
                nodoAEliminar.A.S = nodoAEliminar.S;
                nodoAEliminar.S.A = nodoAEliminar.A;
                if (nodoAEliminar == Cabeza)
                {
                    Cabeza = nodoAEliminar.S;
                }
            }
            Cont--;
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (Cabeza == null) yield break;

            var nodo = Cabeza;

            do
            {
                yield return nodo.D;
                nodo = nodo.S;
            }
            while (nodo != Cabeza);
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
