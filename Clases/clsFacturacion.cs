using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Taller_Carros.Models;

namespace Taller_Carros.Clases
{
    public class clsFacturacion
    {
        private DBTallerCarrosEntities dbTaller = new DBTallerCarrosEntities();
        public Factura factura { get; set; }
        public detalle_factura_producto productoFactura { get; set; }
        public detalle_factura_servicio servicioFactura { get; set; }
        public detalle_factura_reparacion reparacionFactura { get; set; }

        public string GrabarFactura()
        {
            factura.fecha = DateTime.Now;
            dbTaller.Facturas.Add(factura);
            dbTaller.SaveChanges();
            return factura.id_factura.ToString();
        }
        public string GrabarDetalleProducto()
        {
            Factura factura = dbTaller.Facturas.Find(productoFactura.id_factura);
            factura.total = factura.total + (productoFactura.valorUnitario * productoFactura.cantidad);
            dbTaller.Facturas.AddOrUpdate(factura);
            dbTaller.SaveChanges();
            dbTaller.detalle_factura_producto.Add(productoFactura);
            dbTaller.SaveChanges();
            return productoFactura.id.ToString();
        }
        public string GrabarDetalleReparacion()
        {
            Factura factura = dbTaller.Facturas.Find(reparacionFactura.id_factura);
            factura.total = factura.total + reparacionFactura.costo;
            dbTaller.Facturas.AddOrUpdate(factura);
            dbTaller.SaveChanges();
            dbTaller.detalle_factura_reparacion.Add(reparacionFactura);
            dbTaller.SaveChanges();
            return reparacionFactura.id.ToString();
        }
        public string GrabarDetalleServicio()
        {
            Factura factura = dbTaller.Facturas.Find(servicioFactura.id_factura);
            factura.total = factura.total + servicioFactura.precio;
            dbTaller.Facturas.AddOrUpdate(factura);
            dbTaller.SaveChanges();
            dbTaller.detalle_factura_servicio.Add(servicioFactura);
            dbTaller.SaveChanges();
            return servicioFactura.id.ToString();
        }
        public IQueryable LlenarTablaProductos(int id_factura)
        {
            return from F in dbTaller.Set<Factura>()
                   join FP in dbTaller.Set<detalle_factura_producto>()
                   on F.id_factura equals FP.id_factura
                   join P in dbTaller.Set<Producto>()
                   on FP.id_producto equals P.id_producto
                   join TP in dbTaller.Set<Tipo_producto>()
                   on P.id_tipo_producto equals TP.id_tipo_producto
                   where F.id_factura == id_factura
                   select new
                   {
                       Eliminar = "<button type=\"button\" id=\"btnEliminar\" class=\"btn-block btn-sm btn-danger\" " +
                                "onclick=\"EliminarDetalleProducto(" + FP.id + ")\">ELIMINAR</button>",
                       Id_tipo_producto = TP.id_tipo_producto,
                       Tipo_producto = TP.nombre,
                       Codigo = P.id_producto,
                       Producto = P.nombre,
                       Cantidad = FP.cantidad,
                       ValorUnitario = FP.valorUnitario
                   };
        }

        public IQueryable LlenarTablaReparaciones(int id_factura)
        {
            return from F in dbTaller.Set<Factura>()
                   join FR in dbTaller.Set<detalle_factura_reparacion>()
                   on F.id_factura equals FR.id_factura
                   join R in dbTaller.Set<Reparacion>()
                   on FR.id_reparacion equals R.id_reparacion
                   join TR in dbTaller.Set<Tipo_reparacion>()
                   on R.id_tipo_reparacion equals TR.id_tipo_reparacion
                   join VR in dbTaller.Set<detalle_vehiculo_reparacion>()
                   on R.id_reparacion equals VR.id_reparacion
                   where F.id_factura == id_factura
                   select new
                   {
                       Eliminar = "<button type=\"button\" id=\"btnEliminar\" class=\"btn-block btn-sm btn-danger\" " +
                                "onclick=\"EliminarDetalleReparacion(" + FR.id + ")\">ELIMINAR</button>",
                       Id_tipo_reparacion = TR.id_tipo_reparacion,
                       Tipo_reparacion = TR.nombre,
                       Id_reparacion = R.id_reparacion,
                       Reparacion = R.nombre,
                       Placas_vehiculo = VR.id_vehiculo,
                       Costo = FR.costo,
                       Fecha_reparacion = VR.fecha_reparacion 
                   };
        }
        public IQueryable LlenarTablaServicios(int id_factura)
        {
            return from F in dbTaller.Set<Factura>()
                   join FS in dbTaller.Set<detalle_factura_servicio>()
                   on F.id_factura equals FS.id_factura
                   join S in dbTaller.Set<Servicio_adicional>()
                   on FS.id_servicio equals S.id_servicio_adicional
                   join VS in dbTaller.Set<detalle_vehiculo_servicio>()
                   on S.id_servicio_adicional equals VS.id_servicio
                   where F.id_factura == id_factura
                   select new
                   {
                       Eliminar = "<button type=\"button\" id=\"btnEliminar\" class=\"btn-block btn-sm btn-danger\" " +
                                "onclick=\"EliminarDetalleServicio(" + FS.id + ")\">ELIMINAR</button>",
                       Codigo = S.id_servicio_adicional,
                       Servicio_Adicional = S.nombre,
                       Placas_Vehiculo = VS.id_vehiculo,
                       Precio = S.precio,
                       Fecha_Servicio = VS.fecha_servicio
                   };
        }

        public string EliminarProducto(int idDetalleFacturaProducto)
        {
            detalle_factura_producto _facturaProducto = dbTaller.detalle_factura_producto.FirstOrDefault(d => d.id == idDetalleFacturaProducto);
            dbTaller.detalle_factura_producto.Remove(_facturaProducto);
            dbTaller.SaveChanges();
            return "Se eliminó el detalle del producto";
        }
        public string EliminarReparacion(int idDetalleFacturaProducto)
        {
            detalle_factura_reparacion _facturaReparacion = dbTaller.detalle_factura_reparacion.FirstOrDefault(d => d.id == idDetalleFacturaProducto);
            dbTaller.detalle_factura_reparacion.Remove(_facturaReparacion);
            dbTaller.SaveChanges();
            return "Se eliminó el detalle de la reparación";
        }
        public string EliminarServicio(int idDetalleFacturaProducto)
        {
            detalle_factura_servicio _facturaServicio = dbTaller.detalle_factura_servicio.FirstOrDefault(d => d.id == idDetalleFacturaProducto);
            dbTaller.detalle_factura_servicio.Remove(_facturaServicio);
            dbTaller.SaveChanges();
            return "Se eliminó el detalle del servicio";
        }
    }
}