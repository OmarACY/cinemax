using Cinemax.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinemax.Models
{
    public class Venta : IDisposable
    {
        private CinemaxEntities db;

        public Venta()
        {
            // Creacion (Inicializacion) del objeto mediante el que se interactua con la base de datos
            db = new CinemaxEntities();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public bool AgregaVenta(SalesViewModel modelo)
        {
            bool estatus;

            try
            {
                SalesViewModel ultimo = ObtenUltimo();
                DalVenta entidad = new DalVenta()
                {
                    clave_venta = ultimo != null ? ultimo.clave_venta.Value + 1 : 1,
                    clave_emp = modelo.clave_emp,
                    clave_fun = modelo.clave_fun,
                    clave_mem = modelo.clave_mem,
                    total = 0
                };
                db.Venta.Add(entidad);
                db.SaveChanges();
                foreach (Place asiento in modelo.asientos)
                {
                    string procedimiento = string.Format("BEGIN CALCULA_PUNTOS_MEMBRESIA({0}, {1}); END; ", entidad.clave_venta, "35.0");
                    db.DetalleVenta.Add(new DalDetalleVenta()
                    {
                        asiento = asiento.Name,
                        clave_venta = entidad.clave_venta,
                        subtotal = 35,
                        tipo_asiento = "Sencillo"
                    });
                    db.Database.ExecuteSqlCommand(procedimiento);
                }
                if (modelo.tipo_pago == "Tarjeta")
                {
                    db.Cuenta.Add(new DalCuenta()
                    {
                        clave_venta = entidad.clave_venta,
                        codigo_seg = modelo.cod_seguridad,
                        fecha_venta = DateTime.Now,
                         numero_tarjeta = modelo.num_tarjeta
                    });
                }
                db.SaveChanges();
                estatus = true;
            }
            catch (Exception e)
            {
                estatus = false;
            }

            return estatus;
        }

        public SalesViewModel ObtenUltimo()
        {
            DalVenta entidad = (from e in db.Venta orderby e.clave_venta descending select e).FirstOrDefault();
            if (entidad != null)
                return new SalesViewModel()
                {
                    clave_venta = entidad.clave_venta,
                    clave_cin = entidad.Funcion.Sala.clave_cin,
                    clave_emp = entidad.clave_emp,
                    clave_fun = entidad.clave_fun,
                    clave_mem = entidad.clave_mem,
                    clave_pel = entidad.Funcion.clave_pel,
                    clave_sal = entidad.Funcion.clave_sal
                };
            else
                return null;
        }
    }
}