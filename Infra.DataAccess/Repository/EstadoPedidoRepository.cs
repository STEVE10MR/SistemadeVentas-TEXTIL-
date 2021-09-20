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
    public class EstadoPedidoRepository : ConectionSql, IEstadoPedidoRepository
    {
        public List<EstadoPedido> BuscarEstadoPedido()
        {
            SqlDataReader DR;
            SqlConnection SQLCNX = new SqlConnection();
            try
            {
                SQLCNX = ConectionSql.Objet().Connection();
                SqlCommand COMMAND = new SqlCommand("EP_BUSCAR_ESTADO_PEDIDO", SQLCNX);
                COMMAND.CommandType = CommandType.StoredProcedure;
                SQLCNX.Open();
                DR = COMMAND.ExecuteReader();
                List<EstadoPedido> ListarEstadoPedido = new List<EstadoPedido>();
                while (DR.Read())
                {
                    ListarEstadoPedido.Add(new EstadoPedido
                    {
                        ID_EstadoPedido = DR.GetInt32(0),
                        Nombre = DR.GetString(1),
                        Descripcion = DR.GetString(2),
                    });
                }
                return ListarEstadoPedido;
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
