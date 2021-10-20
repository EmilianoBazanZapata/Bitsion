using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    //hereda de DbContext
    public class DataBaseContext : DbContext
    {
        public class OptionsBuild
        {
            //segundo creo el constructor
            public OptionsBuild()
            {
                Settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
                opsBuilder.UseSqlServer(Settings.SqlConnectionString);
                dbOptions = opsBuilder.Options;
            }
            //primero agrego los set y get
            public DbContextOptionsBuilder<DataBaseContext> opsBuilder { get; set; }
            public DbContextOptions<DataBaseContext> dbOptions { get; set; }
            public AppConfiguration Settings { get; set; }
        }
        public static OptionsBuild ops = new OptionsBuild();
        
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        //referencias de las entidades para crear la migracion
        public DbSet<Cliente> clientes{get;set;}
    }
}