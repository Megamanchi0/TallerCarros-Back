using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taller_Carros.Models;

namespace Taller_Carros.Clases
{
    public class clsModelo
    {
        private DBTallerCarrosEntities taller = new DBTallerCarrosEntities();
        public IQueryable ConsultarModelos(int id_marca)
        {
            return from MA in taller.Set<Marca>()
                   join MO in taller.Set<Modelo>()
                   on MA.id_marca equals MO.id_marca
                   where MA.id_marca == id_marca
                   select new
                   {
                       Codigo = MO.id_modelo,
                       Nombre = MO.nombre
                   };
        }
    }
}