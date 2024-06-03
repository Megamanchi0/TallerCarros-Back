using Taller_Carros.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;

namespace Taller_Carros.Clases
{
    public class clsVehiculo
    {
        private DBTallerCarrosEntities taller = new DBTallerCarrosEntities();
        public Vehiculo vehiculo { get; set; }

        public string Insertar()
        {
            try
            {
                Cliente cliente = taller.Clientes.Find(vehiculo.documento_cliente);
                if (cliente != null)
                {
                    taller.Vehiculoes.Add(vehiculo);
                    taller.SaveChanges();
                    return "Placas de vehículo agregado: " + vehiculo.id_vehiculo;
                }
                else
                {
                    return "El cliente con documento '" + vehiculo.documento_cliente + "' no está registrado";
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
                taller.Vehiculoes.AddOrUpdate(vehiculo);
                taller.SaveChanges();
                return "Se actualizaron los datos del vehículo con placas: " + vehiculo.id_vehiculo;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Vehiculo Consultar(string id)
        {
            return taller.Vehiculoes.FirstOrDefault(p => p.id_vehiculo == id);
        }

        public string Eliminar()
        {
            try
            {
                Vehiculo _vehiculo = Consultar(vehiculo.id_vehiculo);
                taller.Vehiculoes.Remove(_vehiculo);
                taller.SaveChanges();
                return "Placa de vehículo eliminado: " + _vehiculo.id_vehiculo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Vehiculo> ConsultarTodos()
        {
            return taller.Vehiculoes.ToList();
        }
    }
}