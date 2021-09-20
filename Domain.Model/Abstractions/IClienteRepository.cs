using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Abstractions
{
    public interface IClienteRepository
    {
<<<<<<< HEAD
<<<<<<< HEAD
        bool RegistrarCliente(int ID_Usuario);
=======
        bool RegistrarCliente(string DNI, string nombres, string apellidos, string direccion, string gmail, string celular, string contrasena);
>>>>>>> cf719af9bcac3974e4049fdf55b4490f0c20f0f8
=======
        bool RegistrarCliente(string DNI, string nombres, string apellidos, string direccion, string gmail, string celular, string contrasena);
>>>>>>> cf719af9bcac3974e4049fdf55b4490f0c20f0f8

        DataTable ListarCliente(String Busqueda);

        bool ActualizarCliente(int ID_CLIENTE, string gmail, string celular);


    }
}
