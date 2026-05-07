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
                Cabeza.S = Cabeza; // El siguiente apunta a sí mismo
                Cabeza.A = Cabeza; // El anterior apunta a sí mismo
            }
            else
            {
                // Usamos una referencia clara al último nodo (Cabeza.A)
                Nodo ultimo = Cabeza.A;

                nuevo.S = Cabeza;   // El nuevo nodo apunta adelante a la cabeza
                nuevo.A = ultimo;   // El nuevo nodo apunta atrás al último

                ultimo.S = nuevo;   // El viejo último apunta al nuevo
                Cabeza.A = nuevo;   // La cabeza reconoce al nuevo como el último
            }
            Cont++;
        }
        public Nodo BuscarNodo(T dato)
        {
            if (Cabeza == null) return null;

            var aux = Cabeza;
            do
            {
                if (Equals(aux.D, dato))
                    return aux;
                aux = aux.S;
            } while (aux != null && aux != Cabeza);

            return null;
        }

        public T Siguiente(T actual)
        {
            var nodo = BuscarNodo(actual);
            if (nodo == null) return default;
            return nodo.S != null ? nodo.S.D : default;
        }

        public T Anterior(T actual)
        {
            var nodo = BuscarNodo(actual);
            if (nodo == null) return default;
            return nodo.A != null ? nodo.A.D : default;

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
