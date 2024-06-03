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
    public class VehiculosController : ApiController
    {
        // GET api/<controller>
        public List<Vehiculo> Get()
        {
            clsVehiculo _vehiculo = new clsVehiculo();
            return _vehiculo.ConsultarTodos();
        }

        public Vehiculo Get(string id)
        {
            clsVehiculo _vehiculo = new clsVehiculo();
            return _vehiculo.Consultar(id);
        }

        public string Post([FromBody] Vehiculo vehiculo)
        {
            clsVehiculo _vehiculo = new clsVehiculo();
            _vehiculo.vehiculo = vehiculo;
            return _vehiculo.Insertar();
        }

        public string Put([FromBody] Vehiculo empleado)
        {
            clsVehiculo _vehiculo = new clsVehiculo();
            _vehiculo.vehiculo = empleado;
            return _vehiculo.Actualizar();
        }

        public string Delete([FromBody] Vehiculo vehiculo)
        {
            clsVehiculo _vehiculo = new clsVehiculo();
            _vehiculo.vehiculo = vehiculo;
            return _vehiculo.Eliminar();
        }
    }
}