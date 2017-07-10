using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficePointApis
{
    public static class ConnectionExtensions
    {
        public static void ConnectAndOpen(this System.Data.Common.DbConnection connection)
        {
            connection.ConnectionString = Common.SecureConstants.SecureConnectionString;
            connection.Open();
        }
    }
}