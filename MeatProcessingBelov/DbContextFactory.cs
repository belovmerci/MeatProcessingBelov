using MeatProcessingBelov.Models;
using MeatProcessingBelov.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeatProcessingBelov
{
    public class DbContextFactory
    {
        private static BelovMeat2207sb1Context _context;
        private static readonly object _lock = new object();

        private DbContextFactory() { }

        public static BelovMeat2207sb1Context GetDbContext(string username, string password)
        {
            lock (_lock)
            {
                if (_context == null)
                {
                    var connectionString = $"Server=localhost\\SQLEXPRESS;Database=Belov_MEAT_2207sb1;User Id={username};Password={password};TrustServerCertificate=True;";
                    var optionsBuilder = new DbContextOptionsBuilder<BelovMeat2207sb1Context>();
                    optionsBuilder.UseSqlServer(connectionString);
                    _context = new BelovMeat2207sb1Context(optionsBuilder.Options);
                }
                return _context;
            }
        }

        public static BelovMeat2207sb1Context GetExistingDbContext()
        {
            lock (_lock)
            {
                if (_context == null)
                {
                    throw new InvalidOperationException("DbContext has not been initialized. Call GetDbContext(username, password) first.");
                }
                return _context;
            }
        }

        public static void ResetDbContext()
        {
            lock (_lock)
            {
                _context = null;
            }
        }
    }
}