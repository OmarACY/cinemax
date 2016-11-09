using Cinemax.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinemax.Models
{
    public class Cine : IDisposable
    {
        private CinemaxEntities db;

        public Cine()
        {
            // Creacion (Inicializacion) del objeto mediante el que se interactua con la base de datos
            db = new CinemaxEntities();
        }

        /// <summary>
        /// Agrega un nuevo cine a la base de datos
        /// </summary>
        /// <param name="modelo">Cine a agregar</param>
        /// <returns></returns>
        public bool AgregaCine(MovieTeathersViewModel modelo)
        {
            bool estatus = false;
            
            return estatus;
        }

        /// <summary>
        /// Actualiza la informacion de un cine
        /// </summary>
        /// <param name="modelo">Cine a editar (Actualizar)</param>
        /// <returns></returns>
        public bool EditaCine(MovieTeathersViewModel modelo)
        {
            bool estatus = false;
            
            return estatus;
        }
        
        /// <summary>
        /// Elimina un cine de la base de datos
        /// </summary>
        /// <param name="clave">Clave del cine a eliminar</param>
        /// <returns></returns>
        public bool EliminaCine(long clave)
        {
            bool estatus = false;
            
            return estatus;
        }

        /// <summary>
        /// Devuelve un cine especifico
        /// </summary>
        /// <param name="clave">Clave del cine</param>
        /// <returns></returns>
        public MovieTeathersViewModel ObtenCine(long clave)
        {
            return null;
        }

        /// <summary>
        /// Devuelve el ultimo cine agregado a la base de datos
        /// </summary>
        /// <returns></returns>
        public MovieTeathersViewModel ObtenUltimo()
        {
            return null;
        }

        /// <summary>
        /// Devuelve todos los cines existentes en la base datos, dentro de un modelo representable en un Bootgrid
        /// </summary>
        /// <param name="current">Pagina actual del grid</param>
        /// <param name="rowCount">Numero de elementos a mostrar</param>
        /// <param name="sort">Columnas a tomar para ordenar</param>
        /// <param name="searchPhrase">Frase de busqueda</param>
        /// <returns></returns>
        public GetMovieTeathersViewModel ObtenCines(int current, int rowCount, Dictionary<object, string> sort, string searchPhrase)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}