using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataAccess.Repository
{
    public class ConectionSql
    {
        public static ConectionSql Objet()
        {
            return new ConectionSql();
        }
        public SqlConnection Connection()
        {
            SqlConnection CONX;
            try
            {
                CONX = new SqlConnection(new SqlConnectionStringBuilder(GetConnectionString()).ConnectionString);
            }
            catch (Exception ex)
            {
                CONX = null;
                throw ex;
            }
            return CONX;
        }
        private static string GetConnectionString()
        {
            return "Server=DESKTOP-PIBUJFJ;Integrated Security=SSPI;" +
            "Initial Catalog=SIVET;User Id=sa;Password=Rk123123";
        }
    }
}
