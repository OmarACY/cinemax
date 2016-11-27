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
                    siguienteClave = ObtenUltimo().Clave + 1;
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
                    numero = modelo.Numero,
                    nombre_usuario = modelo.NombreUsuario,
                    email = modelo.Email
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

        /// <summary>
        /// Actualiza la informacion de un empleado
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        public bool EditaEmpleado(EmployeesViewModel modelo)
        {
            bool estatus;
            DalEmpleado entidad;

            try
            {
                estatus = false;
                entidad = db.Empleado.FirstOrDefault(e => e.clave_emp == modelo.Clave);
                if (entidad != null)
                {
                    entidad.password = modelo.Password;
                    entidad.nombre = modelo.Nombre;
                    entidad.app = modelo.ApPaterno;
                    entidad.apm = modelo.ApMaterno;
                    entidad.fecha_nac = modelo.FechaNac;
                    entidad.colonia = modelo.Colonia;
                    entidad.calle = modelo.Calle;
                    entidad.numero = modelo.Numero;
                    if ((modelo.Telefono != string.Empty) && (modelo.Telefono != null))
                    {
                        if (entidad.TelEmp.Count > 0)
                        {
                            if (modelo.Telefono != entidad.TelEmp.First().telefono)
                            {
                                DalTelEmp telefonoEmpleado = entidad.TelEmp.FirstOrDefault(t => 
                                    (t.telefono == entidad.TelEmp.First().telefono)
                                );
                                entidad.TelEmp.Remove(telefonoEmpleado);
                                db.TelEmp.Add(new DalTelEmp()
                                {
                                    clave_emp = entidad.clave_emp,
                                    telefono = modelo.Telefono
                                });
                            }
                        }
                        else
                        {
                            db.TelEmp.Add(new DalTelEmp()
                            {
                                clave_emp = entidad.clave_emp,
                                telefono = modelo.Telefono
                            });
                        }
                    }
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
        
        public bool EliminaEmpleado(long clave)
        {
            bool estatus;
            DalEmpleado entidad;

            try
            {
                estatus = false;
                entidad = db.Empleado.FirstOrDefault(e => e.clave_emp == clave);
                if (entidad != null)
                { 
                    db.AspNetUsers.Remove(db.AspNetUsers.FirstOrDefault(u => 
                        (u.UserName == entidad.nombre_usuario) && 
                        (u.Email == entidad.email)
                    ));
                    if (entidad.TelEmp.Count > 0)
                    {
                        DalTelEmp telefonoEmpleado = entidad.TelEmp.FirstOrDefault(t =>
                                    (t.telefono == entidad.TelEmp.First().telefono)
                                );
                        entidad.TelEmp.Remove(telefonoEmpleado);
                    }
                    db.Empleado.Remove(entidad);
                    db.SaveChanges();
                    estatus = true;
                }
            }
            catch (Exception)
            {
                estatus = false;
            }
            return estatus;
        }

        /// <summary>
        /// Devuelve un empleado especifico
        /// </summary>
        /// <param name="clave">Clave del empleado</param>
        /// <param name="nombreUsuario">Nombre de usuario</param>
        /// <returns></returns>
        public EmployeesViewModel ObtenEmpleado(long clave, string nombreUsuario)
        {
            DalEmpleado empleado = (from e in db.Empleado where e.clave_emp == clave select e).FirstOrDefault();
            DalAspNetUsers usuario = (from u in db.AspNetUsers where u.UserName == nombreUsuario select u).FirstOrDefault();

            if ((empleado != null) && (usuario != null))
                return new EmployeesViewModel()
                {
                    IdUsuarioAspNet = usuario.Id,
                    Clave = empleado.clave_emp,
                    NombreUsuario = empleado.nombre_usuario,
                    Password = empleado.password,
                    Nombre = empleado.nombre,
                    ApPaterno = empleado.app,
                    ApMaterno = empleado.apm,
                    FechaNac = empleado.fecha_nac,
                    Email = empleado.email,
                    Telefono = empleado.TelEmp.Count > 0 ? empleado.TelEmp.First().telefono : null,
                    Colonia = empleado.colonia,
                    Calle = empleado.calle,
                    Numero = empleado.numero
                };
            else
                return null;
        }

        public EmployeesViewModel ObtenEmpleado(string nombreUsuario)
        {
            DalEmpleado empleado = (from e in db.Empleado where e.nombre_usuario == nombreUsuario select e).FirstOrDefault();
            DalAspNetUsers usuario = (from u in db.AspNetUsers where u.UserName == nombreUsuario select u).FirstOrDefault();

            if ((empleado != null) && (usuario != null))
                return new EmployeesViewModel()
                {
                    IdUsuarioAspNet = usuario.Id,
                    Clave = empleado.clave_emp,
                    NombreUsuario = empleado.nombre_usuario,
                    Password = empleado.password,
                    Nombre = empleado.nombre,
                    ApPaterno = empleado.app,
                    ApMaterno = empleado.apm,
                    FechaNac = empleado.fecha_nac,
                    Email = empleado.email,
                    Telefono = empleado.TelEmp.Count > 0 ? empleado.TelEmp.First().telefono : null,
                    Colonia = empleado.colonia,
                    Calle = empleado.calle,
                    Numero = empleado.numero
                };
            else
                return null;
        }

        /// <summary>
        /// Devuelve el ultimo empleado agregado a la base de datos
        /// </summary>
        /// <returns></returns>
        public EmployeesViewModel ObtenUltimo()
        {
            DalEmpleado empleado = (from e in db.Empleado orderby e.clave_emp descending select e).FirstOrDefault();
            if (empleado != null)
                return new EmployeesViewModel()
                {
                    Clave = empleado.clave_emp,
                    NombreUsuario = empleado.nombre_usuario,
                    Password = empleado.password,
                    Nombre = empleado.nombre,
                    ApPaterno = empleado.app,
                    ApMaterno = empleado.apm,
                    FechaNac = empleado.fecha_nac,
                    Email = empleado.email,
                    Telefono = empleado.TelEmp.Count > 0 ? empleado.TelEmp.First().telefono : null,
                    Colonia = empleado.colonia,
                    Calle = empleado.calle,
                    Numero = empleado.numero
                };
            else
                return null;
        }

        /// <summary>
        /// Devuelve todos los empleados existentes en la base datos, dentro de un modelo representable en un Bootgrid
        /// </summary>
        /// <param name="current">Pagina actual del grid</param>
        /// <param name="rowCount">Numero de elementos a mostrar</param>
        /// <param name="sort">Columnas a tomar para ordenar</param>
        /// <param name="searchPhrase">Frase de busqueda</param>
        /// <returns></returns>
        public GetEmployeesViewModel ObtenEmpleados(int current, int rowCount, Dictionary<object, string> sort, string searchPhrase)
        {
            GetEmployeesViewModel empleados;
            List<DalEmpleado> empleadosDal;
            int total;

            // Busqueda de empleados
            empleadosDal = (from e in db.Empleado orderby e.clave_emp ascending select e).ToList();
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
                    Telefono = empleado.TelEmp.Count > 0 ? empleado.TelEmp.First().telefono : null,
                    NombreUsuario = empleado.nombre_usuario,
                    Email = empleado.email
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