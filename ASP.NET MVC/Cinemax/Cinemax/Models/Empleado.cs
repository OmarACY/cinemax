using Cinemax.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinemax.Models
{
    public class Empleado
    {
        private CinemaxEntities db;

        /// <summary>
        /// Agrega un nuevo empleado a la base de datos
        /// </summary>
        /// <param name="modelo">Modelo del emplado a agregar</param>
        /// <returns></returns>
        public bool AgregaEmpleado(EmployeesViewModel modelo)
        {
            bool estatus;
            DalEmpleado entidad; 
            long siguienteClave;

            try
            {
                // Creacion del objeto mediante el que se interactua con la base de datos
                db = new CinemaxEntities();
                try
                {
                    siguienteClave = db.Empleado.ToList().Last().clave_emp + 1;
                }
                catch (Exception)
                {
                    siguienteClave = 1;
                }
                entidad = new DalEmpleado()
                {
                    clave_emp = siguienteClave,
                    password = modelo.Password,
                    nombre = modelo.Nombre,
                    app = modelo.ApPaterno,
                    apm = modelo.ApMaterno,
                    fecha_nac = modelo.FechaNac,
                    colonia = modelo.Colonia,
                    calle = modelo.Calle,
                    numero = modelo.Numero
                };
                db.Empleado.Add(entidad);
                if ((modelo.Telefono != string.Empty) && (modelo.Telefono != null))
                {
                    db.TelEmp.Add(new DalTelEmp()
                    {
                        clave_emp = entidad.clave_emp,
                        telefono = modelo.Telefono
                    });
                }
                db.SaveChanges();
                db.Dispose();
                estatus = true;
            }
            catch (Exception)
            {
                estatus = false;
            }
            return estatus;
        }
    }
}