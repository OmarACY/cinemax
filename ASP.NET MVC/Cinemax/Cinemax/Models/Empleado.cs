using Cinemax.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinemax.Models
{
    public class Empleado : IDisposable
    {
        private CinemaxEntities db;

        public Empleado()
        {
            // Creacion (Inicializacion) del objeto mediante el que se interactua con la base de datos
            db = new CinemaxEntities();
        }

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
                estatus = true;
            }
            catch (Exception)
            {
                estatus = false;
            }
            return estatus;
        }

        public GetEmployeesViewModel ObtenEmpleados(int current, int rowCount, Dictionary<object, string> sort, string searchPhrase)
        {
            GetEmployeesViewModel empleados;
            List<DalEmpleado> empleadosDal;
            int total;

            // Busqueda de empleados
            empleadosDal = (from e in db.Empleado select e).ToList();
            total = empleadosDal.Count;
            empleados = new GetEmployeesViewModel()
            {
                current = current,
                rowCount = rowCount,
                total = total
            };
            // Seleccion de empleados por pagina
            empleadosDal = empleadosDal.GetRange(
                (current - 1) * rowCount,
                (((current - 1) * rowCount) + rowCount) <= total ? rowCount : total - ((current - 1) * rowCount));
            foreach (DalEmpleado empleado in empleadosDal)
            {
                empleados.rows.Add(new EmployeesViewModel()
                {
                    Password = empleado.password,
                    Clave = empleado.clave_emp,
                    Nombre = empleado.nombre,
                    ApPaterno = empleado.app,
                    ApMaterno = empleado.apm,
                    FechaNacGrid = empleado.fecha_nac.ToShortDateString(),
                    Colonia = empleado.colonia,
                    Calle = empleado.calle,
                    Numero = empleado.numero,
                    Telefono = empleado.TelEmp.Count > 0 ? empleado.TelEmp.First().telefono : null
                });
            }

            return empleados;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}