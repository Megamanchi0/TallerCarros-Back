using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Taller_Carros.Clases;

namespace Taller_Carros.Controllers
{
    public class ProductosController : ApiController
    {
        public IQueryable Get(int idTipoProducto)
        {
            clsProducto producto = new clsProducto();
            return producto.LlenarCombo(idTipoProducto);
        }
    }
}