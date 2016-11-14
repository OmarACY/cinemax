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
            long siguienteClave;

            try
            {
                try
                {
                    siguienteClave = (long)ObtenUltimo().clave_pel + 1;
                }
                catch (Exception)
                {
                    siguienteClave = 1;
                }

                DalPelicula entidad = new DalPelicula()
                {
                    clave_pel = siguienteClave,
                    nombre = modelo.nombre,
                    director = modelo.director,
                    genero = modelo.genero,
                    clasificacion = modelo.clasificacion,
                    sinopsis = modelo.sinopsis
                };
                db.Pelicula.Add(entidad);
                db.SaveChanges();
                estatus = true;
            }
            catch (Exception) {
                estatus = false;
            }            
            return estatus;
        }

        /// <summary>
        /// Actualiza la informacion de una pelicula
        /// </summary>
        /// <param name="modelo">Pelicula a editar (Actualizar)</param>
        /// <returns></returns>
        public bool EditaPelicula(MoviesViewModel modelo)
        {
            bool estatus;
            DalPelicula entidad;

            try
            {
                estatus = false;
                entidad = db.Pelicula.FirstOrDefault(p => p.clave_pel == modelo.clave_pel);
                if (entidad != null)
                {
                    entidad.nombre = modelo.nombre;
                    entidad.director = modelo.director;
                    entidad.genero = modelo.genero;
                    entidad.clasificacion = modelo.clasificacion;
                    entidad.sinopsis = modelo.sinopsis;
                    
                    db.SaveChanges();
                    estatus = true;
                }
            }
            catch (Exception ex)
            {
                estatus = false;
            }
            return estatus;
        }
        
        /// <summary>
        /// Elimina una pelicula de la base de datos
        /// </summary>
        /// <param name="clave">Clave de la pelicula a eliminar</param>
        /// <returns></returns>
        public bool EliminaPelicula(long clave)
        {
            bool estatus;
            DalPelicula entidad;

            try
            {
                entidad = db.Pelicula.FirstOrDefault(p => p.clave_pel == clave);
                if (entidad != null)
                {
                    db.Pelicula.Remove(entidad);
                    db.SaveChanges();
                    estatus = true;
                }
                else
                    estatus = false;
            }
            catch (Exception)
            {
                estatus = false;
            }

            return estatus;
        }

        /// <summary>
        /// Devuelve una pelicula especifica
        /// </summary>
        /// <param name="clave">Clave de la pelicula</param>
        /// <returns></returns>
        public MoviesViewModel ObtenPelicula(long clave)
        {
            DalPelicula entidad = (from p in db.Pelicula where p.clave_pel == clave select p).FirstOrDefault();
            if (entidad != null)
                return new MoviesViewModel()
                {
                    clave_pel = entidad.clave_pel,
                    nombre = entidad.nombre,
                    director = entidad.director,
                    genero = entidad.genero,
                    clasificacion = entidad.clasificacion,
                    sinopsis = entidad.sinopsis
                };
            else
                return null;
        }

        /// <summary>
        /// Devuelve la ultima pelicula agregada a la base de datos
        /// </summary>
        /// <returns></returns>
        public MoviesViewModel ObtenUltimo()
        {
            DalPelicula pelicula = (from p in db.Pelicula orderby p.clave_pel descending select p).FirstOrDefault();
            if (pelicula != null)
                return new MoviesViewModel()
                {
                    clave_pel = pelicula.clave_pel,
                    nombre = pelicula.nombre,
                    director = pelicula.director,
                    genero = pelicula.genero,
                    clasificacion = pelicula.clasificacion,
                    sinopsis = pelicula.sinopsis
                };
            else
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
            GetMoviesViewModel peliculas;
            List<DalPelicula> peliculasDal;
            int total;

            // Busqueda de empleados
            peliculasDal = (from p in db.Pelicula orderby p.clave_pel ascending select p).ToList();
            total = peliculasDal.Count;
            peliculas = new GetMoviesViewModel()
            {
                current = current,
                rowCount = rowCount,
                total = total
            };
            // Seleccion de empleados por pagina
            peliculasDal = peliculasDal.GetRange(
                (current - 1) * rowCount,
                (((current - 1) * rowCount) + rowCount) <= total ? rowCount : total - ((current - 1) * rowCount));
            foreach (DalPelicula pelicula in peliculasDal)
            {
                peliculas.rows.Add(new MoviesViewModel()
                {
                    clave_pel = pelicula.clave_pel,
                    nombre = pelicula.nombre,
                    director = pelicula.director,
                    genero = pelicula.genero,
                    clasificacion = pelicula.clasificacion,
                    sinopsis = pelicula.sinopsis

                });
            }

            return peliculas;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}