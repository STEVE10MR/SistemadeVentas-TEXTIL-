using Domain.Model.Abstractions;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataAccess.Repository
{
    public class FacturaRepository : ConectionSql, IFacturaRepository
    {
        public bool GenerarProducto(int Nrofactura, DateTime Fecha, double SubTotal, double Descuento, double igv, double CostoTotal)
        {
            bool RE;
            SqlConnection sqlCnx = new SqlConnection();

            try
            {
                sqlCnx = ConectionSql.Objet().Connection();
                SqlCommand comando = new SqlCommand("F_GENERARFACTURA", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@PSERIEFACTURA", SqlDbType.Int).Value = Nrofactura;
                comando.Parameters.Add("@PFECHA", SqlDbType.DateTime).Value = Fecha;
                comando.Parameters.Add("@PSUBTOTAL", SqlDbType.Int).Value = SubTotal;
                comando.Parameters.Add("@PDESCUENTO", SqlDbType.Int).Value = Descuento;
                comando.Parameters.Add("@PIGV", SqlDbType.Int).Value = igv;
                comando.Parameters.Add("@PCOSTOTOTAL", SqlDbType.Int).Value = CostoTotal;
                sqlCnx.Open();

                RE = comando.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCnx.State == ConnectionState.Open)
                {
                    sqlCnx.Close();
                }
            }

            return RE;
        }
    }
}
