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
    public class ReparacionesController : ApiController
    {
        public IQueryable Get()
        {
            clsReparacion _reparacion = new clsReparacion();
            IQueryable objeto = _reparacion.ConsultarTodos();
            return objeto;
        }

        public Reparacion Get(int id)
        {
            clsReparacion _reparacion = new clsReparacion();
            return _reparacion.Consultar(id);
        }

        public string Post([FromBody] Reparacion reparacion)
        {
            clsReparacion _reparacion = new clsReparacion();
            _reparacion.reparacion = reparacion;
            return _reparacion.Insertar();
        }

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