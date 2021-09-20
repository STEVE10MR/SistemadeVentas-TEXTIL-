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
    public class DetallePedidoRepository : ConectionSql, IDetallePedidoRepository
    {
        public List<DetallePedido> BuscarDetallePedido(int ID_CLIENTE)
        {
            SqlDataReader DR;
            SqlConnection SQLCNX = new SqlConnection();
            try
            {
                SQLCNX = ConectionSql.Objet().Connection();
                SqlCommand COMMAND = new SqlCommand("DP_BUSCAR", SQLCNX);
                COMMAND.CommandType = CommandType.StoredProcedure;
                COMMAND.Parameters.Add("@PID_CLIENTE", SqlDbType.VarChar).Value = ID_CLIENTE;
                SQLCNX.Open();
                DR = COMMAND.ExecuteReader();

                List<DetallePedido> ListarDetallePedido = new List<DetallePedido>();
                while (DR.Read())
                {
                    ListarDetallePedido.Add(new DetallePedido
                    {
                        Material = new Material{ ID_Material = DR.GetInt32(0) },
                        Pedido = new Pedido{ ID_Pedido = DR.GetInt32(1) },
                        Cantidad = DR.GetInt32(2),
                        PrecioUnit = DR.GetDouble(3),
                        SubTotal = DR.GetDouble(4)
                    });
                }
                return ListarDetallePedido;
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

        public bool RegistrarDetallePedido(string DNI, string nombres, string apellidos, string direccion, string gmail, string celular, string contrasena)
        {
            bool RE;
            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("C_INSERT", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PDNI", SqlDbType.VarChar).Value = DNI;
                command.Parameters.Add("@PNOMBRES", SqlDbType.VarChar).Value = nombres;
                command.Parameters.Add("@PAPELLIDOS", SqlDbType.VarChar).Value = apellidos;
                command.Parameters.Add("@PDIRECCION", SqlDbType.VarChar).Value = direccion;
                command.Parameters.Add("@PEMAIL", SqlDbType.VarChar).Value = gmail;
                command.Parameters.Add("@PCELULAR", SqlDbType.VarChar).Value = celular;
                command.Parameters.Add("@PCONTRASENA", SqlDbType.VarChar).Value = contrasena;

                cnx.Open();
                RE = command.ExecuteNonQuery() == 1 ? true : false;

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

            return RE;
        }
    }
}
