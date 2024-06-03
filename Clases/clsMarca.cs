using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taller_Carros.Models;

namespace Taller_Carros.Clases
{
    public class clsMarca
    {
        private DBTallerCarrosEntities taller = new DBTallerCarrosEntities();
        public IQueryable ConsultarMarcas()
        {
            return from M in taller.Set<Marca>()
                   select new
                   {
                       Codigo = M.id_marca,
                       Nombre = M.nombre,
                   };
        }
    }
}