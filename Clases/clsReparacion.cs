
using Taller_Carros.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Taller_Carros.Clases
{
    public class clsReparacion
    {
        private DBTallerCarrosEntities taller = new DBTallerCarrosEntities();
        public Reparacion reparacion { get; set; }

        public string Insertar()
        {
            try
            {
                Vehiculo vehiculo = taller.Vehiculoes.Find(reparacion.id_vehiculo);
                if (vehiculo!=null)
                {
                    taller.Reparacions.Add(reparacion);
                    taller.SaveChanges();
                    return "Reparación agregada número: " + reparacion.id_reparacion;
                }
                else
                {
                    return "El vehículo con placas '"+reparacion.id_vehiculo+"' no se encuentra registrado";
                }
                
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                taller.Reparacions.AddOrUpdate(reparacion);
                taller.SaveChanges();
                return "Se actualizaron los datos de la reparación número: " + reparacion.id_tipo_reparacion;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Reparacion Consultar(int id)
        {
            return taller.Reparacions.FirstOrDefault(p => p.id_reparacion == id);
        }

        public string Eliminar()
        {
            try
            {
                Reparacion _reparacion = Consultar(reparacion.id_reparacion);
                taller.Reparacions.Remove(_reparacion);
                taller.SaveChanges();
                return "Reparación eliminada número: " + _reparacion.id_reparacion;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public IQueryable ConsultarTodos()
        {
            return from TR in taller.Set<Tipo_reparacion>()
                   join R in taller.Set<Reparacion>()
                   on TR.id_tipo_reparacion equals R.id_tipo_reparacion
                   orderby R.fecha_reparacion
                   select new
                   {
                       id_reparacion = R.id_reparacion,
                       tipo_reparacion = TR.nombre,
                       descripcion = R.descripcion,
                       fecha_reparacion = R.fecha_reparacion,
                       costo_reparacion = R.costo_reparacion,
                       id_vehiculo = R.id_vehiculo
                   };
        }
    }
}