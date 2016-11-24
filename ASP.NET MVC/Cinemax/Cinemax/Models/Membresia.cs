using Cinemax.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinemax.Models
{
    public class Membresia : IDisposable
    {
        private CinemaxEntities db;

        public Membresia()
        {
            // Creacion (Inicializacion) del objeto mediante el que se interactua con la base de datos
            db = new CinemaxEntities();
        }

        /// <summary>
        /// Agrega un nuevo cliente a la base de datos
        /// </summary>
        /// <param name="modelo">Cliente a agregar</param>
        /// <returns></returns>
        public bool AgregaCliente(ClientsViewModel modelo)
        {
            bool estatus;

            try
            {
                ClientsViewModel ultimo = ObtenUltimo();
                DalMembresia entidad = new DalMembresia()
                {
                    clave_mem = ultimo != null ? ultimo.clave_mem.Value + 1 : 1,
                    nombre = modelo.nombre,
                    app = modelo.app,
                    apm = modelo.apm,
                    fecha_nac = modelo.fecha_nac,
                    colonia = modelo.colonia,
                    calle = modelo.calle,
                    numero = modelo.numero,
                    tipo = modelo.tipo,
                    puntos = modelo.puntos
                };
                db.Membresia.Add(entidad);
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
        /// Actualiza la informacion de un cliente
        /// </summary>
        /// <param name="modelo">Cliente a editar (Actualizar)</param>
        /// <returns></returns>
        public bool EditaCliente(ClientsViewModel modelo)
        {
            bool estatus;
            DalMembresia entidad;

            try
            {
                entidad = db.Membresia.FirstOrDefault(e => e.clave_mem == modelo.clave_mem);
                if (entidad != null)
                {
                    entidad.nombre = modelo.nombre;
                    entidad.app = modelo.app;
                    entidad.apm = modelo.apm;
                    entidad.fecha_nac = modelo.fecha_nac;
                    entidad.colonia = modelo.colonia;
                    entidad.calle = modelo.calle;
                    entidad.numero = modelo.numero;
                    entidad.tipo = modelo.tipo;
                    entidad.puntos = modelo.puntos;
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
        /// Elimina un cliente de la base de datos
        /// </summary>
        /// <param name="clave">Clave del cliente a eliminar</param>
        /// <returns></returns>
        public bool EliminaCliente(long clave)
        {
            bool estatus;
            DalMembresia entidad;

            try
            {
                entidad = db.Membresia.FirstOrDefault(e => e.clave_mem == clave);
                if (entidad != null)
                {
                    db.Membresia.Remove(entidad);
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
        /// Devuelve un cliente especifico
        /// </summary>
        /// <param name="clave">Clave del empleado</param>
        /// <returns></returns>
        public ClientsViewModel ObtenCliente(long clave)
        {
            DalMembresia entidad = (from e in db.Membresia where e.clave_mem == clave select e).FirstOrDefault();
            if (entidad != null)
                return new ClientsViewModel()
                {
                    clave_mem = entidad.clave_mem,
                    nombre = entidad.nombre,
                    app = entidad.app,
                    apm = entidad.apm,
                    fecha_nac = entidad.fecha_nac,
                    fecha_nacimiento_grid = entidad.fecha_nac.ToShortDateString(),
                    colonia = entidad.colonia,
                    calle = entidad.calle,
                    numero = entidad.numero,
                    tipo = entidad.tipo,
                    puntos = entidad.puntos
                };
            else
                return null;
        }

        /// <summary>
        /// Devuelve el ultimo cliente agregado a la base de datos
        /// </summary>
        /// <returns></returns>
        public ClientsViewModel ObtenUltimo()
        {
            DalMembresia entidad = (from e in db.Membresia orderby e.clave_mem descending select e).FirstOrDefault();
            if (entidad != null)
                return new ClientsViewModel()
                {
                    clave_mem = entidad.clave_mem,
                    nombre = entidad.nombre,
                    app = entidad.app,
                    apm = entidad.apm,
                    fecha_nac = entidad.fecha_nac,
                    fecha_nacimiento_grid = entidad.fecha_nac.ToShortDateString(),
                    colonia = entidad.colonia,
                    calle = entidad.calle,
                    numero = entidad.numero,
                    tipo = entidad.tipo,
                    puntos = entidad.puntos
                };
            else
                return null;
        }

        /// <summary>
        /// Devuelve todos los clientes existentes en la base datos, dentro de un modelo representable en un Bootgrid
        /// </summary>
        /// <param name="current">Pagina actual del grid</param>
        /// <param name="rowCount">Numero de elementos a mostrar</param>
        /// <param name="sort">Columnas a tomar para ordenar</param>
        /// <param name="searchPhrase">Frase de busqueda</param>
        /// <returns></returns>
        public GetClientsViewModel ObtenClientes(int current, int rowCount, Dictionary<object, string> sort, string searchPhrase)
        {
            GetClientsViewModel clientes;
            List<DalMembresia> clientesDal;
            int total;

            // Busqueda de empleados
            clientesDal = (from e in db.Membresia orderby e.clave_mem ascending select e).ToList();
            total = clientesDal.Count;
            clientes = new GetClientsViewModel()
            {
                current = current,
                rowCount = rowCount,
                total = total
            };
            // Seleccion de empleados por pagina
            clientesDal = clientesDal.GetRange(
                (current - 1) * rowCount,
                (((current - 1) * rowCount) + rowCount) <= total ? rowCount : total - ((current - 1) * rowCount));
            foreach (DalMembresia cliente in clientesDal)
            {
                clientes.rows.Add(new ClientsViewModel()
                {
                    clave_mem = cliente.clave_mem,
                    nombre = cliente.nombre,
                    app = cliente.app,
                    apm = cliente.apm,
                    fecha_nac = cliente.fecha_nac,
                    fecha_nacimiento_grid = cliente.fecha_nac.ToShortDateString(),
                    colonia = cliente.colonia,
                    calle = cliente.calle,
                    numero = cliente.numero,
                    tipo = cliente.tipo,
                    puntos = cliente.puntos
                });
            }

            return clientes;
        }

        /// <summary>
        /// Devuelve una lista con los clientes existentes
        /// </summary>
        /// <returns></returns>
        public List<SelectClient> ObtenClientes()
        {
            List<SelectClient> clientes;
            List<DalMembresia> clientesDal;

            // Busqueda de clientes
            clientesDal = (from e in db.Membresia orderby e.clave_mem ascending select e).ToList();
            clientes = new List<SelectClient>();
            foreach (DalMembresia cliente in clientesDal)
            {
                clientes.Add(new SelectClient()
                {
                    clave_mem = cliente.clave_mem,
                    nombre = cliente.nombre
                });
            }

            return clientes;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}