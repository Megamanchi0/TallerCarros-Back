using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Taller_Carros.Models;

namespace Taller_Carros.Clases
{
    public class clsServicioAdicional
    {
        private DBTallerCarrosEntities DBtaller = new DBTallerCarrosEntities();
        public detalle_vehiculo_servicio vehiculo_Servicio { get; set; }
        public IQueryable LlenarCombo()
        {
            return from SA in DBtaller.Set<Servicio_adicional>()
                   select new
                   {
                       Codigo = SA.id_servicio_adicional,
                       Nombre = SA.nombre
                   };
        }
        public string GrabarServicioReparacion()
        {
            try
            {
                DBtaller.detalle_vehiculo_servicio.Add(vehiculo_Servicio);
                DBtaller.SaveChanges();
                return "Detalle vehículo-servicio agregado exitosamente";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}