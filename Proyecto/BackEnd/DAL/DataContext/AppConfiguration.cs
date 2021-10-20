using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//agregamos estos using
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DAL.DataContext
{
    public class AppConfiguration
    {
        //constructor
        public AppConfiguration()
        {
            var ConfigBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            ConfigBuilder.AddJsonFile(path, false);
            var root = ConfigBuilder.Build();
            //ubicacion de la cadena de conexion hacia la BD
            var AppSettings = root.GetSection("ConnectionStrings:BD");
            SqlConnectionString = AppSettings.Value;
        }
        public string SqlConnectionString { get; set; }
    }
}