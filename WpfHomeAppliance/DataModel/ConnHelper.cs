using System.Configuration;
using System.Data.SqlClient;

namespace WpfHomeAppliance.DataModel
    {
     class ConnHelper
        { 
        public SqlConnection GetConnection()
            {
            return  new SqlConnection(
                ConfigurationManager.ConnectionStrings["default"].ConnectionString);
            }
        
        }
    }
