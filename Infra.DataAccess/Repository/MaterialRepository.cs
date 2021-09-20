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
    public class MaterialRepository : ConectionSql, IMaterialsRepository
    {
        public bool ActualizarMaterial(LimiteVenta OBJLimiteventa, double preciounit, int ID_Material)
        {
            bool RE;

            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("M_ACTUALIZAR_MATERIAL", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PID_MATERIAL", SqlDbType.Int).Value = ID_Material;
                command.Parameters.Add("@PPORCENTAJE", SqlDbType.Decimal).Value = OBJLimiteventa.Porcentaje;
                command.Parameters.Add("@PDESCPORCENTAJE", SqlDbType.Decimal).Value = OBJLimiteventa.DescPorcentaje;
                command.Parameters.Add("@PPRECIOUNIT", SqlDbType.Decimal).Value = preciounit;
                command.Parameters.Add("@PFECHAULTIMOCAMBIO", SqlDbType.DateTime).Value = OBJLimiteventa.FechaUltimoCambio;
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

        public bool AumentarStock(int ID_Material, int cantidad)
        {
            bool retornar = false;

            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("M_AUMENTAR_STOCK", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PID_MATERIAL", SqlDbType.Int).Value = ID_Material;
                command.Parameters.Add("@PCANTIDAD", SqlDbType.Int).Value = cantidad;
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

        public List<Material> BuscarMaterial(string Buscar)
        {
            SqlDataReader DR;
            SqlConnection SQLCNX = new SqlConnection();
            try
            {
                SQLCNX = ConectionSql.Objet().Connection();
                SqlCommand COMMAND = new SqlCommand("M_BUSCAR", SQLCNX);
                COMMAND.Parameters.Add("@PBUSCADO", SqlDbType.VarChar).Value = Buscar;
                SQLCNX.Open();
                DR = COMMAND.ExecuteReader();
                List<Material> ListarMaterial = new List<Material>();
                while (DR.Read()) 
                {
                    ListarMaterial.Add(new Material
                    {
                        ID_Material= DR.GetInt32(0),
                        Nombre=DR.GetString(1),
                        Descripcion = DR.GetString(2),
                        PrecioUnit = DR.GetDouble(3),
                        Unidad = DR.GetString(4),
                        Stock = DR.GetInt32(5)
                    });
                }
                return ListarMaterial;
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

        public bool RegistrarMaterial(Material OBJMaterial)
        {
            bool retornar = false;

            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("M_REGISTRAR", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PNOMBRE", SqlDbType.VarChar).Value = OBJMaterial.Nombre;
                command.Parameters.Add("@PDESCRIPCION", SqlDbType.VarChar).Value = OBJMaterial.Descripcion;
                command.Parameters.Add("@PPRECIOUNIT", SqlDbType.Decimal).Value = OBJMaterial.PrecioUnit;
                command.Parameters.Add("@PUNIDAD", SqlDbType.VarChar).Value = OBJMaterial.Unidad;
                command.Parameters.Add("@PSTOCK", SqlDbType.Int).Value = OBJMaterial.Stock;
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

        public bool ReservarMaterial(int cantidad, int ID_Material)
        {
            bool retornar = false;

            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("M_RESERVAR_MATERIAL", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PID_MATERIAL", SqlDbType.Int).Value = ID_Material;
                command.Parameters.Add("@PCANTIDAD", SqlDbType.Int).Value = cantidad;

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
    }
}
