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
    public class TipoVehiculosController : ApiController
    {
        public List<Tipo_Vehiculo> Get()
        {
            clsTipoVehuculo _tipoVehiculo = new clsTipoVehuculo();
            return _tipoVehiculo.consultarTipoVehiculos();
        }
    }
}