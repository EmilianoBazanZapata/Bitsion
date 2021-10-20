using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface ICliente
    {
        Task<Cliente> AgregarCliente(string nombre, string apellido, int identificacion, int edad, bool genero, bool estado, bool Maneja, bool UsaLentes , bool Diabetico , bool TieneOtraEnfermedad , string OtraEnfermedad);
        Task<Cliente> ActualizarCliente(int id , string nombre, string apellido, int identificacion, int edad, bool genero, bool estado, bool Maneja, bool UsaLentes , bool Diabetico , bool TieneOtraEnfermedad , string OtraEnfermedad);
        Task<Cliente> EliminarCliente(int id);
        Task<Cliente> ReactivarCliente(int id);
        Task<List<Cliente>> BuscarClientePorId(int id);
        Task<List<Cliente>> ListarClinetesActivos();
        Task<List<Cliente>> ListarClinetesInactivos();
    }
}