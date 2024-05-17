using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLNDotNetCore.PizzaAPI.ConnectionStrings
{
    internal class ConnectoinStrings
    {
        public static readonly SqlConnectionStringBuilder _constringbuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-8OT1RLC\\SQLEXPRESS",
            InitialCatalog = "DotNetCore",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
    }
}
