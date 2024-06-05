using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taller_Carros.Models;

namespace Taller_Carros.Clases
{
    public class clsProducto
    {
        public DBTallerCarrosEntities DBtaller = new DBTallerCarrosEntities();
        public IQueryable LlenarCombo(int idTipoProducto)
        {
            return from P in DBtaller.Set<Producto>()
                   where P.id_tipo_producto == idTipoProducto
                   select new
                   {
                       Codigo = P.id_producto + "|" + P.precio,
                       Nombre = P.nombre
                   };
        }
    }
}