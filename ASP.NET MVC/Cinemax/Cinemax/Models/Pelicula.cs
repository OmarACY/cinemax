using Cinemax.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinemax.Models
{
    public class Pelicula : IDisposable
    {
        private CinemaxEntities db;

        public Pelicula()
        {
            // Creacion (Inicializacion) del objeto mediante el que se interactua con la base de datos
            db = new CinemaxEntities();
        }

        /// <summary>
        /// Agrega una nueva pelicula a la base de datos
        /// </summary>
        /// <param name="modelo">Pelicula a agregar</param>
        /// <returns></returns>
        public bool AgregaPelicula(MoviesViewModel modelo)
        {
            bool estatus = false;
            
            return estatus;
        }

        /// <summary>
        /// Actualiza la informacion de una pelicula
        /// </summary>
        /// <param name="modelo">Pelicula a editar (Actualizar)</param>
        /// <returns></returns>
        public bool EditaPelicula(MoviesViewModel modelo)
        {
            bool estatus = false;
            
            return estatus;
        }
        
        /// <summary>
        /// Elimina una pelicula de la base de datos
        /// </summary>
        /// <param name="clave">Clave de la pelicula a eliminar</param>
        /// <returns></returns>
        public bool EliminaPelicula(long clave)
        {
            bool estatus = false;
            
            return estatus;
        }

        /// <summary>
        /// Devuelve una pelicula especifica
        /// </summary>
        /// <param name="clave">Clave de la pelicula</param>
        /// <returns></returns>
        public MoviesViewModel ObtenPelicula(long clave)
        {
            return null;
        }

        /// <summary>
        /// Devuelve la ultima pelicula agregada a la base de datos
        /// </summary>
        /// <returns></returns>
        public MoviesViewModel ObtenUltimo()
        {
            return null;
        }

        /// <summary>
        /// Devuelve todas las peliculas existentes en la base datos, dentro de un modelo representable en un Bootgrid
        /// </summary>
        /// <param name="current">Pagina actual del grid</param>
        /// <param name="rowCount">Numero de elementos a mostrar</param>
        /// <param name="sort">Columnas a tomar para ordenar</param>
        /// <param name="searchPhrase">Frase de busqueda</param>
        /// <returns></returns>
        public GetMoviesViewModel ObtenPeliculas(int current, int rowCount, Dictionary<object, string> sort, string searchPhrase)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}