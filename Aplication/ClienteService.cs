using Domain.Model.Abstractions;
using Domain.Model.Entities;
using Infra.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class ClienteService
    {
        readonly IClienteRepository ClienteRepository;
        public ClienteService() 
        {
            ClienteRepository = new ClienteRepository();
        }
        public bool RegistrarCliente(string DNI, string Nombre, string Apellido, string Direccion, String Email, String Telefono, String Contrasenia)
        {
            UsuarioService UsuarioS = new UsuarioService();
            Usuario Usuario = UsuarioS.RegistrarUsuario(DNI, Nombre, Apellido, Direccion, Email, Telefono, Contrasenia);
            if (Usuario != null)
            {
                return ClienteRepository.RegistrarCliente(Usuario.UsuarioID);
            }
            else return false;
        }
        public DataTable BuscarCliente(String buscar) 
        {
            return ClienteRepository.ListarCliente(buscar);
        }
        public bool ActualizarCliente(int ID_CLIENTE, string gmail, string celular) 
        {
            return ClienteRepository.ActualizarCliente(ID_CLIENTE, gmail, celular);
        }
    }
}
