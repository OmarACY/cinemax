using Cinemax.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinemax.Models
{
    public class Funcion : IDisposable
    {
        private CinemaxEntities db;

        public Funcion()
        {
            // Creacion (Inicializacion) del objeto mediante el que se interactua con la base de datos
            db = new CinemaxEntities();
        }

        /// <summary>
        /// Agrega una nueva Funcion a la base de datos
        /// </summary>
        /// <param name="modelo">Funcion a agregar</param>
        /// <returns></returns>
        public bool AgregaFuncion(FilmFunctionsViewModel modelo)
        {
            bool estatus = false;
            
            return estatus;
        }

        /// <summary>
        /// Actualiza la informacion de una Funcion
        /// </summary>
        /// <param name="modelo">Funcion a editar (Actualizar)</param>
        /// <returns></returns>
        public bool EditaFuncion(FilmFunctionsViewModel modelo)
        {
            bool estatus = false;
            
            return estatus;
        }
        
        /// <summary>
        /// Elimina una Funcion de la base de datos
        /// </summary>
        /// <param name="clave">Clave de la Funcion a eliminar</param>
        /// <returns></returns>
        public bool EliminaFuncion(long clave)
        {
            bool estatus = false;
            
            return estatus;
        }

        /// <summary>
        /// Devuelve una Funcion especifica
        /// </summary>
        /// <param name="clave">Clave de la Funcion</param>
        /// <returns></returns>
        public FilmFunctionsViewModel ObtenFuncion(long clave)
        {
            return null;
        }

        /// <summary>
        /// Devuelve la ultima Funcion agregada a la base de datos
        /// </summary>
        /// <returns></returns>
        public FilmFunctionsViewModel ObtenUltimo()
        {
            return null;
        }

        /// <summary>
        /// Devuelve todas las Funcions existentes en la base datos, dentro de un modelo representable en un Bootgrid
        /// </summary>
        /// <param name="current">Pagina actual del grid</param>
        /// <param name="rowCount">Numero de elementos a mostrar</param>
        /// <param name="sort">Columnas a tomar para ordenar</param>
        /// <param name="searchPhrase">Frase de busqueda</param>
        /// <returns></returns>
        public GetFilmFunctionsViewModel ObtenFunciones(int current, int rowCount, Dictionary<object, string> sort, string searchPhrase)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}