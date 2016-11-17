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
            bool estatus;

            try
            {
                MovieTeathersViewModel ultimo = ObtenUltimo();
                DalCine entidad = new DalCine()
                {
                    clave_cin = ultimo != null ? ultimo.clave_cin.Value + 1 : 1,
                    nombre = modelo.nombre,
                    colonia = modelo.colonia,
                    calle = modelo.calle,
                    numero = modelo.numero,
                    num_salas = modelo.num_salas
                };
                db.Cine.Add(entidad);
                if(modelo.telefono != null)
                {
                    db.TelCin.Add(new DalTelCin() { clave_cin = entidad.clave_cin, telefono = modelo.telefono });
                }
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
        /// Actualiza la informacion de un cine
        /// </summary>
        /// <param name="modelo">Cine a editar (Actualizar)</param>
        /// <returns></returns>
        public bool EditaCine(MovieTeathersViewModel modelo)
        {
            bool estatus;

            try
            {
                DalCine entidad = (from e in db.Cine where e.clave_cin == modelo.clave_cin select e).FirstOrDefault();
                DalTelCin tel = (from e in db.TelCin where e.clave_cin == modelo.clave_cin select e).FirstOrDefault();
                if (entidad != null)
                {
                    entidad.nombre = modelo.nombre;
                    entidad.colonia = modelo.colonia;
                    entidad.calle = modelo.calle;
                    entidad.numero = modelo.numero;
                    entidad.num_salas = modelo.num_salas;
                    if (modelo.telefono != null)
                    {
                        if (tel != null)
                            tel.telefono = modelo.telefono;
                        else
                            db.TelCin.Add(new DalTelCin() { clave_cin = entidad.clave_cin, telefono = modelo.telefono });
                    }
                    else
                    {
                        if (tel != null)
                            db.TelCin.Remove(tel);
                    }
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
        /// Elimina un cine de la base de datos
        /// </summary>
        /// <param name="clave">Clave del cine a eliminar</param>
        /// <returns></returns>
        public bool EliminaCine(long clave)
        {
            bool estatus;

            try
            {
                DalCine entidad = (from e in db.Cine where e.clave_cin == clave select e).FirstOrDefault();
                DalTelCin tel = (from e in db.TelCin where e.clave_cin == clave select e).FirstOrDefault();
                if (entidad != null)
                {
                    if (tel != null)
                        db.TelCin.Remove(tel);
                    db.Cine.Remove(entidad);
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
        /// Devuelve un cine especifico
        /// </summary>
        /// <param name="clave">Clave del cine</param>
        /// <returns></returns>
        public MovieTeathersViewModel ObtenCine(long clave)
        {
            DalCine entidad = (from e in db.Cine where e.clave_cin == clave select e).FirstOrDefault();
            if (entidad != null)
                return new MovieTeathersViewModel()
                {
                    clave_cin = entidad.clave_cin,
                    nombre = entidad.nombre,
                    colonia = entidad.colonia,
                    calle = entidad.calle,
                    numero = entidad.numero,
                    num_salas = entidad.num_salas,
                    telefono = entidad.TelCin.Count > 0 ? entidad.TelCin.First().telefono : null
                };
            else
                return null;
        }

        /// <summary>
        /// Devuelve el ultimo cine agregado a la base de datos
        /// </summary>
        /// <returns></returns>
        public MovieTeathersViewModel ObtenUltimo()
        {
            DalCine entidad = (from e in db.Cine orderby e.clave_cin descending select e).FirstOrDefault();
            if (entidad != null)
                return new MovieTeathersViewModel()
                {
                    clave_cin = entidad.clave_cin,
                    nombre = entidad.nombre,
                    colonia = entidad.colonia,
                    calle = entidad.calle,
                    numero = entidad.numero,
                    num_salas = entidad.num_salas,
                    telefono = entidad.TelCin.Count > 0 ? entidad.TelCin.First().telefono : null
                };
            else
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
            GetMovieTeathersViewModel cines;
            List<DalCine> cinesDal;
            int total;

            // Busqueda de empleados
            cinesDal = (from e in db.Cine orderby e.clave_cin ascending select e).ToList();
            total = cinesDal.Count;
            cines = new GetMovieTeathersViewModel()
            {
                current = current,
                rowCount = rowCount,
                total = total
            };
            // Seleccion de empleados por pagina
            cinesDal = cinesDal.GetRange(
                (current - 1) * rowCount,
                (((current - 1) * rowCount) + rowCount) <= total ? rowCount : total - ((current - 1) * rowCount));
            foreach (DalCine cine in cinesDal)
            {
                cines.rows.Add(new MovieTeathersViewModel()
                {
                    clave_cin = cine.clave_cin,
                    nombre = cine.nombre,
                    colonia = cine.colonia,
                    calle = cine.calle,
                    numero = cine.numero,
                    num_salas = cine.num_salas,
                    telefono = cine.TelCin.Count > 0 ? cine.TelCin.First().telefono : null
                });
            }

            return cines;
        }

        /// <summary>
        /// Devuelve una lista con los cines existentes
        /// </summary>
        /// <returns></returns>
        public List<SelectMovieTeather> ObtenCines()
        {
            List<SelectMovieTeather> cines;
            List<DalCine> cinesDal;

            // Busqueda de empleados
            cinesDal = (from e in db.Cine orderby e.clave_cin ascending select e).ToList();
            cines = new List<SelectMovieTeather>();
            foreach (DalCine cine in cinesDal)
            {
                cines.Add(new SelectMovieTeather()
                {
                    clave_cin = cine.clave_cin,
                    nombre = cine.nombre
                });
            }

            return cines;
        }

        public List<SelectLounge> ObtenSalas()
        {
            List<SelectLounge> salas;
            List<DalSala> salasDal;

            // Busqueda de empleados
            salasDal = (from e in db.Sala orderby e.clave_cin ascending, e.clave_sal ascending select e).ToList();
            salas = new List<SelectLounge>();
            foreach (DalSala sala in salasDal)
            {
                salas.Add(new SelectLounge()
                {
                    clave_cin = sala.clave_cin,
                    clave_sal = sala.clave_sal
                });
            }

            return salas;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}