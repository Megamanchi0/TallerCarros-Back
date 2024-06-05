using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taller_Carros.Models;

namespace Taller_Carros.Clases
{
    public class clsTipoProducto
    {
        private DBTallerCarrosEntities DBtaller = new DBTallerCarrosEntities();
        public IQueryable LlenarCombo()
        {
            return from TP in DBtaller.Set<Tipo_producto>()
                   select new
                   {
                       Codigo = TP.id_tipo_producto,
                       Nombre = TP.nombre
                   };
        }
    }
}