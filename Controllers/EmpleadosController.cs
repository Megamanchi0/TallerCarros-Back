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
    public class EmpleadosController : ApiController
    {
        public IQueryable Get()
        {
            clsEmpleado _empleado = new clsEmpleado();
            return _empleado.ConsultarTodos();
        }

        public Empleado Get(int documento)
        {
            clsEmpleado _empleado = new clsEmpleado();
            return _empleado.Consultar(documento);
        }

        public string Post([FromBody] Empleado empleado)
        {
            clsEmpleado _empleado = new clsEmpleado();
            _empleado.empleado = empleado;
            return _empleado.Insertar();
        }

        public string Put([FromBody] Empleado empleado)
        {
            clsEmpleado _empleado = new clsEmpleado();
            _empleado.empleado = empleado;
            return _empleado.Actualizar();
        }

        public string Delete([FromBody] Empleado empleado)
        {
            clsEmpleado _empleado = new clsEmpleado();
            _empleado.empleado = empleado;
            return _empleado.Eliminar();
        }
    }
}