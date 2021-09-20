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
    public class PedidoRepository : ConectionSql, IPedidoRepository
    {
        public bool RegistrarPedido(int ClienteID, bool EsPedidoGrande, DateTime FechaEstimada, double TotalEstimado)
        {
            bool RE;
            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("P_REGISTRAR_PEDIDO", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PID_CLIENTE", SqlDbType.Int).Value = ClienteID;
                command.Parameters.Add("@PPEDIDOGRANDE", SqlDbType.Bit).Value = EsPedidoGrande;
                command.Parameters.Add("@PFECHAESTIMADA", SqlDbType.DateTime).Value = FechaEstimada;
                command.Parameters.Add("@PTOTALNUMERIC", SqlDbType.Decimal).Value = TotalEstimado;
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
        public List<Pedido> ListarPedidos()
        {
            SqlDataReader DR;
            SqlConnection SQLCNX = new SqlConnection();
            try
            {
                SQLCNX = ConectionSql.Objet().Connection();
                SqlCommand COMMAND = new SqlCommand("P_LISTAR_PEDIDOS", SQLCNX);
                SQLCNX.Open();
                DR = COMMAND.ExecuteReader();

                List<Pedido> ListarPedido= new List<Pedido>();
                while (DR.Read())
                {
                    ListarPedido.Add(new Pedido
                    {
                        ID_Pedido = DR.GetInt32(0),
                        Cliente = new Cliente (){ ID_Cliente = DR.GetInt32(1),Usuario = new Usuario {Nombres=DR.GetString(2),Apellidos = DR.GetString(3) ,
                            Dirección= DR.GetString(4),EMAIL = DR.GetString(5),Celular = DR.GetString(6)
                        } },
                        EstadoPedido = new EstadoPedido { Nombre = DR.GetString(9) },
                        FechaEstimada = DR.GetDateTime(7),
                        TotalEstimado = DR.GetDouble(8),
                        DetallePedido = null
                    });
                }
                return ListarPedido;
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
        public bool AprobarPedido(int ID_PEDIDO)
        {
            bool RE;
            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("P_APROBAR_PEDIDO_GRANDE", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PID_PEDIDO", SqlDbType.Int).Value = ID_PEDIDO;

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
        public bool CancelarPedido(int ID_PEDIDO)
        {
            bool RE;
            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("P_CANCELAR_PEDIDO_GRANDE", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PID_PEDIDO", SqlDbType.Int).Value = ID_PEDIDO;

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

        //------------------------------------------------------------
        public bool CrearPedido(int ClienteID, int EstadoPedidoID, bool EsPedidoGrande, DateTime FechaEstimada, double TotalEstimado)
        {
            bool RE;
            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("P_CREAR_PEDIDO", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PID_CLIENTE", SqlDbType.Int).Value = ClienteID;
                command.Parameters.Add("@PID_CLIENTE", SqlDbType.Int).Value = EstadoPedidoID;
                command.Parameters.Add("@PPEDIDOGRANDE", SqlDbType.Bit).Value = EsPedidoGrande;
                command.Parameters.Add("@PFECHAESTIMADA", SqlDbType.DateTime).Value = FechaEstimada;
                command.Parameters.Add("@PTOTALNUMERIC", SqlDbType.Decimal).Value = TotalEstimado;
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

        public void ComprobarLimitePedido()
        {

        }

        public bool NotificarCancelacionPedido(int ID_Pedido)
        {
            bool RE;
            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("P_NOTIFICAR_CANCELACION_PEDIDO", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PID_CLIENTE", SqlDbType.Int).Value = ID_Pedido;
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
        public bool AgregarDetallePedido(int ID_Pedido, int Cantidad)
        {
            bool RE;
            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("P_AGREGAR_DETALLE_PEDIDO", cnx);
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add("@PCANTIDAD", SqlDbType.Int).Value = Cantidad;
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
        public bool VerificarEstadoPedido(string valor)
        {
            bool retornar = false;
            string RE;
            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("P_VERIFICAR_ESTADO_PEDIDO", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PVALOR", SqlDbType.Int).Value = valor;
                SqlParameter ParExiste = new SqlParameter();
                ParExiste.ParameterName = "@pexiste";
                ParExiste.SqlDbType = SqlDbType.Int;
                ParExiste.Direction = ParameterDirection.Output;
                command.Parameters.Add(ParExiste);
                cnx.Open();
                RE = Convert.ToString(ParExiste.Value);
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
            if (RE.Equals("0"))
            {
                retornar = false;
            }
            if (RE.Equals("1"))
            {
                retornar = true;
            }
            return retornar;
        }
    }
}
