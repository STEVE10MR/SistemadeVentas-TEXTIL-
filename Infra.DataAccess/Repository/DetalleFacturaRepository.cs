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
    public class DetalleFacturaRepository : ConectionSql, IDetalleFacturaRepository
    {
        public bool REGISTRAR_DetalleFactura(int nrofactura, int seriefactura, int materialID, int cantidad, double preciounit, double subtotal)
        {
            bool retornar = false;
            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("C_INSERT", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PNROFACTURA", SqlDbType.SmallInt).Value = nrofactura;
                command.Parameters.Add("@PSERIEFACTURA", SqlDbType.Int).Value = seriefactura;
                command.Parameters.Add("@IDMATERIAL", SqlDbType.Int).Value = materialID;
                command.Parameters.Add("@PCANTIDAD", SqlDbType.SmallInt).Value = cantidad;
                command.Parameters.Add("@PPRECIOUNIT", SqlDbType.Decimal).Value = preciounit;
                command.Parameters.Add("@PSUBTOTAL", SqlDbType.Decimal).Value = subtotal;

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

        public List<DetalleFactura> BuscarDetalleFactura(int busqueda)
        {
            SqlDataReader DR;
            SqlConnection SQLCNX = new SqlConnection();
            try
            {
                SQLCNX = ConectionSql.Objet().Connection();
                SqlCommand COMMAND = new SqlCommand("DF_BUSCAR", SQLCNX);
                COMMAND.CommandType = CommandType.StoredProcedure;
                COMMAND.Parameters.Add("@PBUSQUEDA", SqlDbType.SmallInt).Value = busqueda;
                SQLCNX.Open();
                DR = COMMAND.ExecuteReader();

                List<DetalleFactura> ListarDetalleFactura = new List<DetalleFactura>();
                while (DR.Read())
                {
                    ListarDetalleFactura.Add(new DetalleFactura
                    {
                        Factura = new Factura { NroFactura = DR.GetInt32(0), SerieFactura = DR.GetInt32(1) },
                        Material = new Material { ID_Material = DR.GetInt32(2) },
                        Cantidad = DR.GetInt32(3),
                        PrecioUnit = DR.GetDouble(4),
                        SubTotal = DR.GetDouble(5)
                    });
                }
                return ListarDetalleFactura;
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
