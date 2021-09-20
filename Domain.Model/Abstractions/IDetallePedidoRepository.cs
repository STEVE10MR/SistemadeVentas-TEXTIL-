using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Abstractions
{
    public interface IDetallePedidoRepository
    {
        bool RegistrarDetallePedido(string DNI, string nombres, string apellidos, string direccion, string gmail, string celular, string contrasena);

        List<DetallePedido> BuscarDetallePedido(int ID_CLIENTE);
    }
}
