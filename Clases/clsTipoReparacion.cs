using Taller_Carros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller_Carros.Clases
{
    public class clsTipoReparacion
    {
        private DBTallerCarrosEntities taller = new DBTallerCarrosEntities();

        public List<Tipo_reparacion> consultarReparaciones()
        {
            return taller.Tipo_reparacion.ToList();
        }
    }
}