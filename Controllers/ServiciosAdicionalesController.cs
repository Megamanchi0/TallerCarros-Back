using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Taller_Carros.Clases;
using Taller_Carros.Models;

namespace Taller_Carros.Controllers
{
    [EnableCors(origins: "http://localhost:50247", headers: "*", methods: "*")]
    [RoutePrefix("api/ServiciosAdicionales")]
    public class ServiciosAdicionalesController : ApiController
    {
        public IQueryable Get()
        {
            clsServicioAdicional servicioAdicional = new clsServicioAdicional();
            return servicioAdicional.LlenarCombo();
        }
        [HttpPost]
        [Route("GrabarVehiculoServicio")]
        public string GrabarVehiculoServicio(detalle_vehiculo_servicio vehiculo_Servicio)
        {
            clsServicioAdicional _servicio = new clsServicioAdicional();
            _servicio.vehiculo_Servicio = vehiculo_Servicio;
            return _servicio.GrabarServicioReparacion();
        }
    }
}