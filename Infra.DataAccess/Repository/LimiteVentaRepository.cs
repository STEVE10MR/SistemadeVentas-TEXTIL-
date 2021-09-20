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
    public class LimiteVentaRepository : ConectionSql, ILimiteVentaRepository
    {
        public bool ActualizarLimiteVenta(int ID_M, double DECPORC, double PORC, DateTime FECHA)
        {
            bool retornar = false;

            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("LV_ACTUALIZAR", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PID", SqlDbType.SmallInt).Value = ID_M;
                command.Parameters.Add("@PDESCP", SqlDbType.Decimal).Value = DECPORC;
                command.Parameters.Add("@PPORC", SqlDbType.Decimal).Value = PORC;
                command.Parameters.Add("@PFECHAULTIMOCAMBIO", SqlDbType.DateTime).Value = FECHA;
                cnx.Open();
                retornar = command.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (Exception EX)
            {
                throw EX;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return retornar;
        }

        public LimiteVenta BuscarLimitesVenta(int ID_M)
        {
            SqlDataReader DR;
            LimiteVenta OBJLimiteVenta=null;
            SqlConnection SQLCNX = new SqlConnection();
            try
            {
                SQLCNX = ConectionSql.Objet().Connection();
                SqlCommand COMMAND = new SqlCommand("LV_BUSCAR", SQLCNX);
                COMMAND.Parameters.Add("@ID", SqlDbType.SmallInt).Value = ID_M;
                SQLCNX.Open();
                DR = COMMAND.ExecuteReader();
                while (DR.Read()) 
                {
                    OBJLimiteVenta = new LimiteVenta
                    {
                        ID_LimiteVenta = DR.GetInt32(0),
                        Porcentaje=DR.GetDouble(1),
                        DescPorcentaje = DR.GetDouble(2),
                        FechaUltimoCambio=DR.GetDateTime(3)
                    };
                }
                return OBJLimiteVenta;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            finally
            {
                if (SQLCNX.State == ConnectionState.Open)
                    SQLCNX.Close();
            }
        }
    }
}
