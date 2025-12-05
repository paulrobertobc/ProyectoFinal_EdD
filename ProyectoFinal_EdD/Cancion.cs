using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_EdD
{
    //IComparable(interfaz) para poder ordenar las canciones por titulo, abajo usamos el compareto para lograrlo
    public class Cancion : IComparable<Cancion>
    {
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public string Genero { get; set; }
        public int Año { get; set; }
        public string Album { get; set; }
        public string Ruta { get; set; }
        

        public int CompareTo(Cancion other)
        {
            //este metodo compara dos canciones por su titulo, ignorando mayusculas y minusculas con el stringcomparison
            if (other == null) return 1;
            return string.Compare(this.Titulo ?? "", other.Titulo ?? "", StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            //devuelve el nombre de la cancion y el artista sin la extension del archivo
            return $"{Titulo ?? System.IO.Path.GetFileNameWithoutExtension(Ruta)} - {Artista}";
        }
    }
}
