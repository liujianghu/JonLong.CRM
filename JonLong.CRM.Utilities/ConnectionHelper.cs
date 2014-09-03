using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonLong.CRM.Utilities
{
    public static class ConnectionHelper
    {
        private static string _connectionString;
        public static string ConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigHelper.GetConnectionString("sqlconnection");
                }
                return _connectionString;
            }
        }
    }
}
