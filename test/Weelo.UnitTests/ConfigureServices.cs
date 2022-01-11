using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Weelo.Infrastructure;

namespace Weelo.UnitTests
{
    public class ConfigureServices
    {
        private static IConfiguration _configuration;
        private static WeeloContext _context;

        public static IConfiguration configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.test.json")
                        .Build();
                }

                return _configuration;
            }
        }

        public static string GetConnectionString
        {
            get
            {
                //return configuration.GetConnectionString("DefaultConnection");
                return configuration.GetConnectionString("LocalConnection");
            }
        }

        public static WeeloContext GetContext
        {
            get
            {
                if (_context == null)
                {
                    var builder = new DbContextOptionsBuilder<WeeloContext>().UseInMemoryDatabase("WeelodDB");
                    //var builder = new DbContextOptionsBuilder<WeeloContext>().UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                    //var builder = new DbContextOptionsBuilder<WeeloContext>().UseSqlServer(configuration.GetConnectionString("LocalConnection"));
                    _context = new WeeloContext(builder.Options);
                }
                return _context;
            }
        }



    }
}
