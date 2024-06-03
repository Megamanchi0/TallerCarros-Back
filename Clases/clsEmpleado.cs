using Taller_Carros.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Taller_Carros.Clases
{
    public class clsEmpleado
    {
        private DBTallerCarrosEntities taller = new DBTallerCarrosEntities();
        public Empleado empleado { get; set; }

        public string Insertar()
        {
            try
            {
                taller.Empleadoes.Add(empleado);
                taller.SaveChanges();
                return "Empleado agregado: " + empleado.nombre+" "+empleado.apellido;
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
                taller.Empleadoes.AddOrUpdate(empleado);
                taller.SaveChanges();
                return "Se actualizaron los datos del emleado: "+ empleado.nombre + " " + empleado.apellido;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Empleado Consultar(int documento)
        {
            return taller.Empleadoes.FirstOrDefault(p => p.documento == documento);
        }

        public string Eliminar()
        {
            try
            {
                Empleado _empleado = Consultar(empleado.documento);
                taller.Empleadoes.Remove(_empleado);
                taller.SaveChanges();
                return "Empleado eliminado: " + empleado.nombre+" "+empleado.apellido;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public IQueryable ConsultarTodos()
        {
            return from C in taller.Set<Cargo>()
                   join E in taller.Set<Empleado>()
                   on C.id_cargo equals E.id_cargo
                   orderby E.apellido, E.nombre
                   select new
                   {
                       documento = E.documento,
                       nombre = E.nombre,
                       apellido = E.apellido,
                       telefono = E.telefono,
                       fechaContratacion = E.fecha_contratacion,
                       Cargo = C.nombre
                   };
        }
    }
}