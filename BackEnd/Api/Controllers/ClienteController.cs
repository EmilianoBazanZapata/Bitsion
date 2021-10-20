using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Api.Models.ClienteDto.cs;
using DAL.Entities;
using LOGIC.ClienteLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ClienteController : ControllerBase
    {
        private ClienteLogic clienteLogic = new ClienteLogic();
        protected ResponseDto _response;

        public ClienteController()
        {
            _response = new ResponseDto();
        }

        //Agregar Cliente
        [Route("AddNewUser")]
        [HttpPost]
        public async Task<ActionResult<Cliente>> AddUser(string nombre, string apellido, int identificacion, int edad, bool genero, bool activo, bool maneja, bool usaLentes, bool esdiabetico, bool otraEnfermedad, string enfermedadExtra)
        {
            try
            {
                bool result = await clienteLogic.AgregarCliente(nombre, apellido, identificacion, edad, genero, activo, maneja, usaLentes, esdiabetico, otraEnfermedad, enfermedadExtra);
                _response.Result = result;
                _response.DisplayMessage = "Usuario Agregado Exitosamente";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "ocurrio un problema";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
        //Actualizar Cliente
        [Route("UpdateUser")]
        [HttpPost]
        public async Task<ActionResult<Cliente>> UpdateUser(int id, string nombre, string apellido, int identificacion, int edad, bool genero, bool activo, bool maneja, bool usaLentes, bool esdiabetico, bool otraEnfermedad, string enfermedadExtra)
        {
            try
            {
                var result = await clienteLogic.ActualizarCliente(id, nombre, apellido, identificacion, edad, genero, activo, maneja, usaLentes, esdiabetico, otraEnfermedad, enfermedadExtra);
                _response.Result = result;
                _response.DisplayMessage = "Usuario Actualizado Exitosamente";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "ocurrio un problema";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
        //EliminarCliente
        [Route("DeleteUser")]
        [HttpPut]
        public async Task<ActionResult<Cliente>> DeleteUser(int id)
        {
            try
            {
                var result = await clienteLogic.EliminarClietne(id);
                _response.Result = result;
                _response.DisplayMessage = "Usuario Eliminado Exitosamente";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "ocurrio un problema";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
        //ReactivarCliente
        [Route("ReactivateUser")]
        [HttpPut]
        public async Task<ActionResult<Cliente>> ReactivateUser(int id)
        {
            try
            {
                var result = await clienteLogic.ReactivarClietne(id);
                _response.Result = result;
                _response.DisplayMessage = "Usuario Eliminado Exitosamente";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "ocurrio un problema";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
        //ListarUsuariosActivos
        [Route("GetAllUsersActives")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAllUsersActives()
        {
            try
            {
                var lista = await clienteLogic.ListadoDeLosClientesActivos();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Clientes";
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }
        //ListarUsuariosActivos
        [Route("GetAllUsersInactives")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAllUsersInactives()
        {
            try
            {
                var lista = await clienteLogic.ListadoDeLosClientesInactivos();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Clientes";
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }
        [Route("GetUserById")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetUserById(int id)
        {
           try
            {
                var lista = await clienteLogic.BuscarClientePorId(id);
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Clientes";
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);

        }
    }
}