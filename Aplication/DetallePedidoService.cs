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
    public class DetallePedidoService
    {
        readonly IDetallePedidoRepository DetallePedidoRepository;
        public DetallePedidoService()
        {
            DetallePedidoRepository = new DetallePedidoRepository();
        }
        public List<DetallePedido> BuscarDetallePedido(int ID_CLIENTE)
        {
            return new DetallePedidoRepository().BuscarDetallePedido(ID_CLIENTE);
        }

        public bool RegistrarDetallePedido(string DNI, string nombres, string apellidos, string direccion, string gmail, string celular, string contrasena)
        {
            return new DetallePedidoRepository().RegistrarDetallePedido(DNI, nombres, apellidos, direccion, gmail, celular, contrasena);
        }
    }
}
