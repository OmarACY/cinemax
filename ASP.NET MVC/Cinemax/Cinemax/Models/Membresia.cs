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
            bool estatus = false;
            
            return estatus;
        }

        /// <summary>
        /// Actualiza la informacion de un cliente
        /// </summary>
        /// <param name="modelo">Cliente a editar (Actualizar)</param>
        /// <returns></returns>
        public bool EditaCliente(ClientsViewModel modelo)
        {
            bool estatus = false;
            
            return estatus;
        }
        
        /// <summary>
        /// Elimina un cliente de la base de datos
        /// </summary>
        /// <param name="clave">Clave del cliente a eliminar</param>
        /// <returns></returns>
        public bool EliminaCliente(long clave)
        {
            bool estatus = false;
            
            return estatus;
        }

        /// <summary>
        /// Devuelve un cliente especifico
        /// </summary>
        /// <param name="clave">Clave del empleado</param>
        /// <returns></returns>
        public ClientsViewModel ObtenCliente(long clave)
        {
            return null;
        }

        /// <summary>
        /// Devuelve el ultimo cliente agregado a la base de datos
        /// </summary>
        /// <returns></returns>
        public ClientsViewModel ObtenUltimo()
        {
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
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}