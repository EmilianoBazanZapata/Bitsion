using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAL.Functions
{
    public class ClienteFuntions : ICliente
    {
        public async Task<Cliente> AgregarCliente(string nombre, string apellido, int identificacion, int edad, bool genero, bool activo, bool maneja, bool usaLentes, bool esdiabetico, bool otraEnfermedad, string enfermedadExtra)
        {
            Cliente Nuevocliente = new Cliente()
            {
                Nombre = nombre,
                Apellido = apellido,
                Identificacion = identificacion,
                Edad = edad,
                Genero = genero,
                Activo = activo,
                Maneja = maneja,
                UsaLentes = usaLentes,
                EsDiabetico = esdiabetico,
                PadeceOtraEnfermedad = otraEnfermedad,
                OtraEnfermedad = enfermedadExtra,

            };
            //guardo los cambios en la BD
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                await context.clientes.AddAsync(Nuevocliente);
                await context.SaveChangesAsync();
            }
            return Nuevocliente;
        }

        public async Task<Cliente> EliminarCliente(int id)
        {
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                //selecciono el cliente que tenga el mismo id
                var query = (from Cli in context.clientes
                             where Cli.Id == id
                             select Cli).FirstOrDefault();
                //una vez encontrado el Cliente lo elimino colocaldo el campo activo en false
                query.Activo = false;
                //guardo los cambios
                var response = await context.SaveChangesAsync();
                return query;
            }
        }
        public async Task<Cliente> ActualizarCliente(int id, string nombre, string apellido, int identificacion, int edad, bool genero, bool estado, bool maneja, bool usaLentes, bool diabetico, bool tieneOtraEnfermedad, string otraEnfermedad)
        {
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                //selecciono el cliente que tenga el mismo id
                var query = (from Cli in context.clientes
                             where Cli.Id == id
                             select Cli).FirstOrDefault();
                //una vez encontrado el Cliente lo reactivo colocaldo el campo activo en true
                query.Nombre = nombre;
                query.Apellido = apellido;
                query.Identificacion = identificacion;
                query.Edad = edad;
                query.Genero = genero;
                query.Activo = estado;
                query.Maneja = maneja;
                query.UsaLentes = usaLentes;
                query.EsDiabetico = diabetico;
                query.PadeceOtraEnfermedad = tieneOtraEnfermedad;
                query.OtraEnfermedad = otraEnfermedad;
                //guardo los cambios
                await context.SaveChangesAsync();
                return query;
            }
        }
        public async Task<List<Cliente>> BuscarClientePorId(int id)
        {
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                var lista = await context.clientes.Where(p => p.Id == id).ToListAsync();
                return lista;
            }
        }
        public async Task<List<Cliente>> ListarClinetesActivos()
        {
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                var lista = await context.clientes.Where(p => p.Activo == true).OrderBy(p => p.Nombre).ToListAsync();
                return lista;
            }
        }
        public async Task<List<Cliente>> ListarClinetesInactivos()
        {
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                var lista = await context.clientes.Where(p => p.Activo == false).OrderBy(p => p.Nombre).ToListAsync();
                return lista;
            }
        }
        public async Task<Cliente> ReactivarCliente(int id)
        {
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                //selecciono el cliente que tenga el mismo id
                var query = (from Cli in context.clientes
                             where Cli.Id == id
                             select Cli).FirstOrDefault();
                //una vez encontrado el Cliente lo reactivo colocaldo el campo activo en true
                query.Activo = true;
                //guardo los cambios
                await context.SaveChangesAsync();
                return query;
            }
        }
    }
}