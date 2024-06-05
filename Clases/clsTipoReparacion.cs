﻿using Taller_Carros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller_Carros.Clases
{
    public class clsTipoReparacion
    {
        private DBTallerCarrosEntities DBtaller = new DBTallerCarrosEntities();

        public IQueryable LlenarCombo()
        {
            return from TR in DBtaller.Set<Tipo_reparacion>()
                   select new
                   {
                       Codigo = TR.id_tipo_reparacion,
                       Nombre = TR.nombre
                   };
        }
    }
}