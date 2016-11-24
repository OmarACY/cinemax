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
    }
}