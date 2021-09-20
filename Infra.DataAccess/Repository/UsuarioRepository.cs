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
    public class UsuarioRepository : ConectionSql, IUsuarioRepository
    {
        public bool CambiarContrasena(int ID_buscar, string contrasena, byte tp)
        {
            throw new NotImplementedException();
        }

        public Usuario RegistroUsuario(Usuario usuario)
        {
            SqlDataReader RD;
            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("C_INSERT", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PDNI", SqlDbType.VarChar).Value = usuario.DNI;
                command.Parameters.Add("@PNOMBRES", SqlDbType.VarChar).Value = usuario.Nombres;
                command.Parameters.Add("@PAPELLIDOS", SqlDbType.VarChar).Value = usuario.Apellidos;
                command.Parameters.Add("@PDIRECCION", SqlDbType.VarChar).Value = usuario.Dirección;
                command.Parameters.Add("@PEMAIL", SqlDbType.VarChar).Value = usuario.EMAIL;
                command.Parameters.Add("@PCELULAR", SqlDbType.VarChar).Value = usuario.Celular;
                command.Parameters.Add("@PCONTRASENA", SqlDbType.VarChar).Value = usuario.Contrasena;

                RD = command.ExecuteReader();

                Usuario RUsuario=null;

                while (RD.Read()) 
                {
                    new Usuario {UsuarioID=RD.GetInt32(0)};
                }
                return RUsuario;
            }
            catch (Exception EX)
            {
                throw EX;
                return null;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }
    }
}
