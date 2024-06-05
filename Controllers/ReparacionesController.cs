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
    [RoutePrefix("api/Reparaciones")]
    public class ReparacionesController : ApiController
    {
        [HttpGet]
        [Route("LlenarCombo")]
        public IQueryable LlenarCombo(int idTipoReparacion)
        {
            clsReparacion _reparacion = new clsReparacion();
            return _reparacion.LlenarCombo(idTipoReparacion);
        }

        [HttpPost]
        [Route("GrabarVehiculoReparacion")]
        public string GrabarVehiculoReparacion(detalle_vehiculo_reparacion vehiculo_Reparacion)
        {
            clsReparacion _reparacion = new clsReparacion();
            _reparacion.vehiculo_Reparacion = vehiculo_Reparacion;
            return _reparacion.GrabarVehiculoReparacion();
        }

        public Reparacion Get(int id)
        {
            clsReparacion _reparacion = new clsReparacion();
            return _reparacion.Consultar(id);
        }

        //public string Post([FromBody] Reparacion reparacion)
        //{
        //    clsReparacion _reparacion = new clsReparacion();
        //    _reparacion.reparacion = reparacion;
        //    return _reparacion.Insertar();
        //}

        public string Put([FromBody] Reparacion reparacion)
        {
            clsReparacion _reparacion = new clsReparacion();
            _reparacion.reparacion = reparacion;
            return _reparacion.Actualizar();
        }

        public string Delete([FromBody] Reparacion reparacion)
        {
            clsReparacion _reparacion = new clsReparacion();
            _reparacion.reparacion = reparacion;
            return _reparacion.Eliminar();
        }
    }
}