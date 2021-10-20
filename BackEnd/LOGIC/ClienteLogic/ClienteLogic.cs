using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace LOGIC.ClienteLogic
{
    public class ClienteLogic
    {
        //creamo una instancia de la Interfaz
        private ICliente _cliente = new DAL.Functions.ClienteFuntions();

        public async Task<bool> AgregarCliente(string nombre, string apellido, int identificacion, int edad, bool genero, bool activo, bool maneja, bool usaLentes, bool esdiabetico, bool otraEnfermedad, string enfermedadExtra)
        {
            try
            {
                var result = await _cliente.AgregarCliente(nombre, apellido, identificacion, edad, genero, activo, maneja, usaLentes, esdiabetico, otraEnfermedad, enfermedadExtra);
                if (result.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> ActualizarCliente(int id, string nombre, string apellido, int identificacion, int edad, bool genero, bool activo, bool maneja, bool usaLentes, bool esdiabetico, bool otraEnfermedad, string enfermedadExtra)
        {
            try
            {
                var result = await _cliente.ActualizarCliente(id, nombre, apellido, identificacion, edad, genero, activo, maneja, usaLentes, esdiabetico, otraEnfermedad, enfermedadExtra);
                if (result.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> EliminarClietne(int id)
        {
            try
            {
                var result = await _cliente.EliminarCliente(id);
                if (result.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> ReactivarClietne(int id)
        {
            try
            {
                var result = await _cliente.ReactivarCliente(id);
                if (result.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> BuscarClientePorId(int id)
        {
            try
            {
                var result = await _cliente.BuscarClientePorId(id);
                if (result.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<Cliente>> ListadoDeLosClientesActivos()
        {
            List<Cliente> clietnes = await _cliente.ListarClinetesActivos();
            return clietnes;
        }
        public async Task<List<Cliente>> ListadoDeLosClientesInactivos()
        {
            List<Cliente> clietnes = await _cliente.ListarClinetesInactivos();
            return clietnes;
        }
    }
}