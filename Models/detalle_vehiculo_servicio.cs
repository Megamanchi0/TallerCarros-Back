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
    
    public partial class detalle_vehiculo_servicio
    {
        public int id { get; set; }
        public string id_vehiculo { get; set; }
        public int id_servicio { get; set; }
        public System.DateTime fecha_servicio { get; set; }
    
        public virtual Servicio_adicional Servicio_adicional { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
