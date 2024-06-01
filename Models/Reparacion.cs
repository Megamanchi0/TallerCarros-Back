//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Taller_Carros.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reparacion
    {
        public int id_reparacion { get; set; }
        public int id_tipo_reparacion { get; set; }
        public string descripcion { get; set; }
        public System.DateTime fecha_reparacion { get; set; }
        public decimal costo_reparacion { get; set; }
        public string id_vehiculo { get; set; }
        public int documento_empleado { get; set; }
        public int id_factura { get; set; }
    
        public virtual Empleado Empleado { get; set; }
        public virtual Factura Factura { get; set; }
        public virtual Tipo_reparacion Tipo_reparacion { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}