using Domain.Model.Abstractions;
using Domain.Model.Entities;
using Infra.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class UsuarioService
    {
        readonly IUsuarioRepository UsuarioRepository;
        public UsuarioService()
        {
            UsuarioRepository = new UsuarioRepository();
        }
        public Usuario RegistrarUsuario(string DNI, string Nombre, string Apellido,string Direccion,String Email,String Telefono,String Contrasenia)
        {
            Usuario ObjUsuario = new Usuario();
            ObjUsuario.DNI = DNI;
            ObjUsuario.Nombres = Nombre;
            ObjUsuario.Apellidos = Apellido;
            ObjUsuario.Dirección = Direccion;
            ObjUsuario.EMAIL = Email;
            ObjUsuario.Celular = Telefono;
            ObjUsuario.Contrasena = Contrasenia;

            return UsuarioRepository.RegistroUsuario(ObjUsuario);
        }
    }
}
