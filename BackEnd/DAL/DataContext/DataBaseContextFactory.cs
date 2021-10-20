using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//agregamos estos using
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.DataContext
{
    //aplicamos la interfaz : IDesignTimeDbContextFactory<DataBaseContext>
    public class DataBaseContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
    {
        public DataBaseContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            opsBuilder.UseSqlServer(appConfiguration.SqlConnectionString);

            return new DataBaseContext(opsBuilder.Options);
        }
    }
}