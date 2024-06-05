using Taller_Carros.Clases;
using Taller_Carros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Taller_Carros.Controllers
{
    [EnableCors(origins: "http://localhost:50247", headers: "*", methods: "*")]
    public class TipoReparacionesController : ApiController
    {
        public IQueryable Get()
        {
            clsTipoReparacion tipoRreparacion = new clsTipoReparacion();
            return tipoRreparacion.LlenarCombo();
        }
    }
}