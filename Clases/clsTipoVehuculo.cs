using Taller_Carros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller_Carros.Clases
{
    public class clsTipoVehuculo
    {
        private DBTallerCarrosEntities taller = new DBTallerCarrosEntities();

        public List<Tipo_Vehiculo> consultarTipoVehiculos()
        {
            return taller.Tipo_Vehiculo.ToList();
        }
    }
}