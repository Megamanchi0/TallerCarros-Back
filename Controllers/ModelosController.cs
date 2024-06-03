using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Taller_Carros.Clases;

namespace Taller_Carros.Controllers
{
    [EnableCors(origins: "http://localhost:50247", headers: "*", methods: "*")]
    public class ModelosController : ApiController
    {
        public IQueryable Get(int id_marca)
        {
            clsModelo modelo = new clsModelo();
            return modelo.ConsultarModelos(id_marca);
        }
    }
}