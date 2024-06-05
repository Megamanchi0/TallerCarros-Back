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
    [RoutePrefix("api/Facturacion")]
    public class FacturacionController : ApiController
    {
        [HttpPost]
        [Route("GrabarDatosFactura")]
        public string GrabarDatosFactura(Factura factura)
        {
            clsFacturacion facturacion = new clsFacturacion();
            facturacion.factura = factura;
            return facturacion.GrabarFactura();
        }

        [HttpPost]
        [Route("GrabarDetalleProducto")]
        public string GrabarDetalleProducto(detalle_factura_producto productoFactura)
        {
            clsFacturacion facturacion = new clsFacturacion();
            facturacion.productoFactura = productoFactura;
            return facturacion.GrabarDetalleProducto();
        }

        [HttpPost]
        [Route("GrabarDetalleReparacion")]
        public string GrabarDetalleReparacion(detalle_factura_reparacion reparacionFactura)
        {
            clsFacturacion facturacion = new clsFacturacion();
            facturacion.reparacionFactura = reparacionFactura;
            return facturacion.GrabarDetalleReparacion();
        }

        [HttpPost]
        [Route("GrabarDetalleServicio")]
        public string GrabarDetalleServicio(detalle_factura_servicio servicioFactura)
        {
            clsFacturacion facturacion = new clsFacturacion();
            facturacion.servicioFactura = servicioFactura;
            return facturacion.GrabarDetalleServicio();
        }

        [HttpGet]
        [Route("LlenarTablaProductos")]
        public IQueryable LlenarTablaProductos(int idFactura)
        {
            clsFacturacion facturacion = new clsFacturacion();
            return facturacion.LlenarTablaProductos(idFactura);
        }

        [HttpGet]
        [Route("LlenarTablaReparaciones")]
        public IQueryable LlenarTablaReparaciones(int idFactura)
        {
            clsFacturacion facturacion = new clsFacturacion();
            return facturacion.LlenarTablaReparaciones(idFactura);
        }

        [HttpGet]
        [Route("LlenarTablaServicios")]
        public IQueryable LlenarTablaServicios(int idFactura)
        {
            clsFacturacion facturacion = new clsFacturacion();
            return facturacion.LlenarTablaServicios(idFactura);
        }

        [HttpDelete]
        [Route("EliminarDetalleProducto")]
        public string EliminarDetalleProducto(int idFacturaProducto)
        {
            clsFacturacion facturacion = new clsFacturacion();
            return facturacion.EliminarProducto(idFacturaProducto);
        }

        [HttpDelete]
        [Route("EliminarDetalleReparacion")]
        public string EliminarDetalleReparacion(int idFacturaProducto)
        {
            clsFacturacion facturacion = new clsFacturacion();
            return facturacion.EliminarReparacion(idFacturaProducto);
        }

        [HttpDelete]
        [Route("EliminarDetalleServicio")]
        public string EliminarDetalleServicio(int idFacturaProducto)
        {
            clsFacturacion facturacion = new clsFacturacion();
            return facturacion.EliminarServicio(idFacturaProducto);
        }
    }
}