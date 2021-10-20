using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using LOGIC.ClienteLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ClienteController
    {
        private ClienteLogic clienteLogic = new ClienteLogic();
        //Agregar Cliente
        [Route("AddNewUser")]
        [HttpPost]
        public async Task<Boolean> AddUser(string nombre, string apellido, int identificacion, int edad, bool genero, bool activo, bool maneja, bool usaLentes, bool esdiabetico, bool otraEnfermedad, string enfermedadExtra)
        {
            bool result = await clienteLogic.AgregarCliente(nombre, apellido, identificacion, edad, genero, activo, maneja, usaLentes, esdiabetico, otraEnfermedad, enfermedadExtra);
            return result;
        }
        //Actualizar Cliente
        [Route("UpdateUser")]
        [HttpPost]
        public async Task<Boolean> UpdateUser(int id, string nombre, string apellido, int identificacion, int edad, bool genero, bool activo, bool maneja, bool usaLentes, bool esdiabetico, bool otraEnfermedad, string enfermedadExtra)
        {
            bool result = await clienteLogic.ActualizarCliente(id, nombre, apellido, identificacion, edad, genero, activo, maneja, usaLentes, esdiabetico, otraEnfermedad, enfermedadExtra);
            return result;
        }
        //EliminarCliente
        [Route("DeleteUser")]
        [HttpPut]
        public async Task<Boolean> DeleteUser(int id)
        {
            bool result = await clienteLogic.EliminarClietne(id);
            return result;
        }
        //ReactivarCliente
        [Route("ReactivateUser")]
        [HttpPut]
        public async Task<Boolean> ReactivateUser(int id)
        {
            bool result = await clienteLogic.ReactivarClietne(id);
            return result;
        }
        //ListarUsuariosActivos
        [Route("GetAllUsersActives")]
        [HttpGet]
        public async Task<List<ClienteViewModel>> GetAllUsersActives()
        {
            List<ClienteViewModel> userList = new List<ClienteViewModel>();
            var users = await clienteLogic.ListadoDeLosClientesActivos();
            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    ClienteViewModel currentUser = new ClienteViewModel
                    {
                        Id = user.Id,
                        Nombre = user.Nombre,
                        Apellido = user.Apellido,
                        Identificacion = user.Identificacion
                    };
                    userList.Add(currentUser);
                }
            }
            return userList;
        }
        //ListarUsuariosActivos
        [Route("GetAllUsersInactives")]
        [HttpGet]
        public async Task<List<ClienteViewModel>> GetAllUsersInactives()
        {
            List<ClienteViewModel> userList = new List<ClienteViewModel>();
            var users = await clienteLogic.ListadoDeLosClientesInactivos();
            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    ClienteViewModel currentUser = new ClienteViewModel
                    {
                        Id = user.Id,
                        Nombre = user.Nombre,
                        Apellido = user.Apellido,
                        Identificacion = user.Identificacion
                    };
                    userList.Add(currentUser);
                }
            }
            return userList;
        }
    }
}