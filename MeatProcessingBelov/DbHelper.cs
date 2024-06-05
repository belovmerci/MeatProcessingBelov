using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeatProcessingBelov.Models;
using Microsoft.EntityFrameworkCore;
using MeatProcessingBelov.ViewModels;

namespace MeatProcessingBelov
{
    public class DbHelper
    {
        private DbHelper _instance;
        public DbHelper Instance { get { return _instance; } }

        public DbHelper()
        {
            _instance = this;
        }



        public async Task<List<string>> GetTableNames()
        {
            return await Task.Run(() => MainWindowViewModel.Context.GetType().GetProperties()
                .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(p => p.Name).ToList());
        }

        public async Task<List<object>> GetTableData(string tableName)
        {
            var tableProperty = MainWindowViewModel.Context.GetType().GetProperty(tableName);
            if (tableProperty != null)
            {
                var table = tableProperty.GetValue(MainWindowViewModel.Context) as IQueryable;
                if (table != null)
                {
                    return await table.Cast<object>().ToListAsync();
                }
            }
            return new List<object>();
        }

        /*
        public static bool AuthenticateUser(string username, string password)
        {
            using (var context = new BelovMeat2207sb1Context())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                return user != null;
            }
        }
        */
    }
}