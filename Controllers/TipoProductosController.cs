using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Taller_Carros.Clases;

namespace Taller_Carros.Controllers
{
    public class TipoProductosController : ApiController
    {
        public IQueryable Get()
        {
            clsTipoProducto tipoProducto = new clsTipoProducto();
            return tipoProducto.LlenarCombo();
        }
    }
}