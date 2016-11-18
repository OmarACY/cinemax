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
            bool estatus;

            try
            {
                FilmFunctionsViewModel ultimo = ObtenUltimo();
                string[] time;

                time = modelo.hora_ini.Split(new char[]{ ':', ' '});
                int initHour = int.Parse(time[0]);
                int initMinute = int.Parse(time[1]);
                initHour += ((time[2] == "pm" && initHour != 12) ? 12 : (time[2] == "am" && initHour == 12) ? -12 : 0);

                time = modelo.hora_fin.Split(new char[] { ':', ' ' });
                int endMinute = int.Parse(time[1]);
                int endHour = int.Parse(time[0]);
                endHour += ((time[2] == "pm" && endHour != 12) ? 12 : (time[2] == "am" && endHour == 12) ? -12 : 0);

                DalFuncion entidad = new DalFuncion()
                {
                    clave_fun = ultimo != null ? ultimo.clave_fun.Value + 1 : 1,
                    clave_pel = modelo.clave_pel.Value,
                    clave_sal = modelo.clave_sal.Value,
                    fecha = modelo.fecha,
                    hora_ini = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, initHour, initMinute, 0),
                    hora_fin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, endHour, endMinute, 0),
                    cupo = 0
                };
                db.Funcion.Add(entidad);
                db.SaveChanges();
                estatus = true;
            }
            catch (Exception)
            {
                estatus = false;
            }

            return estatus;
        }

        /// <summary>
        /// Actualiza la informacion de una Funcion
        /// </summary>
        /// <param name="modelo">Funcion a editar (Actualizar)</param>
        /// <returns></returns>
        public bool EditaFuncion(FilmFunctionsViewModel modelo)
        {
            bool estatus;

            try
            {
                DalFuncion entidad = (from e in db.Funcion where e.clave_fun == modelo.clave_fun select e).FirstOrDefault();
                if (entidad != null)
                {
                    string[] time;

                    time = modelo.hora_ini.Split(new char[] { ':', ' ' });
                    int initHour = int.Parse(time[0]);
                    int initMinute = int.Parse(time[1]);
                    initHour += ((time[2] == "pm" && initHour != 12) ? 12 : (time[2] == "am" && initHour == 12) ? -12 : 0);

                    time = modelo.hora_fin.Split(new char[] { ':', ' ' });
                    int endMinute = int.Parse(time[1]);
                    int endHour = int.Parse(time[0]);
                    endHour += ((time[2] == "pm" && endHour != 12) ? 12 : (time[2] == "am" && endHour == 12) ? -12 : 0);

                    entidad.clave_pel = modelo.clave_pel.Value;
                    entidad.clave_sal = modelo.clave_sal.Value;
                    entidad.fecha = modelo.fecha;
                    entidad.hora_ini = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, initHour, initMinute, 0);
                    entidad.hora_fin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, endHour, endMinute, 0);

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
        /// Elimina una Funcion de la base de datos
        /// </summary>
        /// <param name="clave">Clave de la Funcion a eliminar</param>
        /// <returns></returns>
        public bool EliminaFuncion(long clave)
        {
            bool estatus;

            try
            {
                DalFuncion entidad = (from e in db.Funcion where e.clave_fun == clave select e).FirstOrDefault();
                if (entidad != null)
                {
                    db.Funcion.Remove(entidad);
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
        /// Devuelve una Funcion especifica
        /// </summary>
        /// <param name="clave">Clave de la Funcion</param>
        /// <returns></returns>
        public FilmFunctionsViewModel ObtenFuncion(long clave)
        {
            DalFuncion entidad = (from e in db.Funcion where e.clave_fun == clave select e).FirstOrDefault();
            if (entidad != null)
                return new FilmFunctionsViewModel()
                {
                    clave_fun = entidad.clave_fun,
                    clave_pel = entidad.clave_pel,
                    clave_sal = entidad.clave_sal,
                    fecha = entidad.fecha,
                    hora_fin = entidad.hora_fin.ToShortTimeString(),
                    hora_ini = entidad.hora_ini.ToShortTimeString(),
                    cupo = entidad.cupo
                };
            else
                return null;
        }

        /// <summary>
        /// Devuelve la ultima Funcion agregada a la base de datos
        /// </summary>
        /// <returns></returns>
        public FilmFunctionsViewModel ObtenUltimo()
        {
            DalFuncion entidad = (from e in db.Funcion orderby e.clave_fun descending select e).FirstOrDefault();
            if (entidad != null)
                return new FilmFunctionsViewModel()
                {
                    clave_fun = entidad.clave_fun,
                    clave_pel = entidad.clave_pel,
                    clave_sal = entidad.clave_sal,
                    fecha = entidad.fecha,
                    hora_fin = entidad.hora_fin.ToShortTimeString(),
                    hora_ini = entidad.hora_ini.ToShortTimeString(),
                    cupo = entidad.cupo
                };
            else
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
            GetFilmFunctionsViewModel funciones;
            List<DalFuncion> funcionesDal;
            int total;

            // Busqueda de empleados
            funcionesDal = (from e in db.Funcion orderby e.clave_fun ascending select e).ToList();
            total = funcionesDal.Count;
            funciones = new GetFilmFunctionsViewModel()
            {
                current = current,
                rowCount = rowCount,
                total = total
            };
            // Seleccion de empleados por pagina
            funcionesDal = funcionesDal.GetRange(
                (current - 1) * rowCount,
                (((current - 1) * rowCount) + rowCount) <= total ? rowCount : total - ((current - 1) * rowCount));
            foreach (DalFuncion funcion in funcionesDal)
            {
                funciones.rows.Add(new FilmFunctionsViewModel()
                {
                    clave_fun = funcion.clave_fun,
                    clave_pel = funcion.clave_pel,
                    clave_cin = funcion.Sala.clave_cin,
                    clave_sal = funcion.clave_sal,
                    cupo = funcion.cupo,
                    fecha = funcion.fecha,
                    fecha_grid = funcion.fecha.ToShortDateString(),
                    hora_fin = funcion.hora_fin.ToShortTimeString(),
                    hora_ini = funcion.hora_ini.ToShortTimeString(),
                    pelicula = funcion.Pelicula.nombre,
                    cine = funcion.Sala.Cine.nombre
                });
            }

            return funciones;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}