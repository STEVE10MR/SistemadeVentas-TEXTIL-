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
    public class EmpleadoService
    {
        readonly IEmpleadosRepository EmpleadoRepository;
        public EmpleadoService()
        {
            EmpleadoRepository = new EmpleadoRepository();
        }
        public bool RegistrarEmpleado(string Cargo, string Area, string DNI, string Nombre, string Apellido, string Direccion, String Email, String Telefono, String Contrasenia)
        {
            UsuarioService UsuarioS = new UsuarioService();
            Usuario Usuario = UsuarioS.RegistrarUsuario(DNI, Nombre, Apellido, Direccion, Email, Telefono, Contrasenia);
            if (Usuario != null)
            {
                return EmpleadoRepository.RegistrarEmpleado(new Empleado {area= Area ,cargo= Area},Usuario);
            }
            else return false;
        }
        public DataTable BuscarEmpleado(string Buscar) 
        {
            return EmpleadoRepository.BuscarEmpleado(Buscar);
        }
        public bool DesactivarEmpleado(int ID_Empleado)
        {
            return EmpleadoRepository.DesactivarEmpleado(ID_Empleado);
        }
        public bool ActivarEmpleado(int ID_Empleado)
        {
            return EmpleadoRepository.ActivarEmpleado(ID_Empleado);
        }
    }
}
