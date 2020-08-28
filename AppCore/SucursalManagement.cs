using DataAccessLayer.CRUD;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore
{
    public class SucursalManagement {
        private SucursalCrudFactory sucursalFactory;
        private ReglaCrudFactory reglaCrudFactory;

        public SucursalManagement() {
            sucursalFactory = new SucursalCrudFactory();
            this.reglaCrudFactory = new ReglaCrudFactory();
        }

        public void CrearSucursal(Sucursal sucursal) {
            sucursalFactory.Create(sucursal);
        }

        public List<Sucursal> ObtenerTodoSucursal(Sucursal sucursal) {
            return sucursalFactory.RetrieveAll<Sucursal>(sucursal);
        }

        public Sucursal ObtenerSucursal(Sucursal sucursal) {
            return sucursalFactory.Retrieve<Sucursal>(sucursal);
        }

        public Sucursal ObtenerSucursalPorEmpleado(Usuario u) {
            return sucursalFactory.RetrieveByEmpleado<Sucursal>(u);
        }

        public void ModificarSucursal(Sucursal sucursal) {
            sucursalFactory.Update(sucursal);
        }

        public void EliminarSucursal(Sucursal sucursal) {
            sucursalFactory.Delete(sucursal);
        }

        public List<Regla> ObtenerReglasPorSucursal(int sucursalId) {
            return this.reglaCrudFactory.RetrieveBySucursal<Regla>(sucursalId);
        }

        public void CrearRegla(Regla regla) {
            this.reglaCrudFactory.Create(regla);
        }

        public void ModificarRegla(Regla regla) {
            this.reglaCrudFactory.Update(regla);
        }

        public void EliminarRegla(int id) {
            Regla regla = new Regla() { 
                Id = id
            };

            this.reglaCrudFactory.Delete(regla);
        }
    }
}
