using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Abstractions
{
    public interface IUsuarioRepository
    {
        Usuario RegistroUsuario(Usuario usuario);
        bool CambiarContrasena(int ID_buscar, string contrasena, byte tp);
    }
}
