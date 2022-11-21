using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ProjectDefence.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class TestDataBaseContext
    {
        public static ApplicationDbContext GetDatabase()
        {
            ApplicationDbContext context;
            DbConnection conection = new SqliteConnection("Filename=:memory:");
            conection.Open();

            DbContextOptions<ApplicationDbContext> contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(conection).Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }
    }
}
