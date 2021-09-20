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
    class PedidoService
    {
        readonly IPedidoRepository PedidoRepository;
        public PedidoService()
        {
            PedidoRepository = new PedidoRepository();
        }
        public bool RegistrarPedido(int ClienteID, bool EsPedidoGrande, DateTime FechaEstimada, double TotalEstimado)
        {
            return new PedidoRepository().RegistrarPedido(ClienteID, EsPedidoGrande, FechaEstimada, TotalEstimado);
        }
        public List<Pedido> ListarPedidos()
        {
            return new PedidoRepository().ListarPedidos();

        }
        public bool AprobarPedido(int ID_PEDIDO)
        {
            return new PedidoRepository().AprobarPedido(ID_PEDIDO);
        }
        public bool CancelarPedido(int ID_PEDIDO)
        {
            return new PedidoRepository().CancelarPedido(ID_PEDIDO);
        }

        public bool CrearPedido(int ClienteID, int EstadoPedidoID, bool EsPedidoGrande, DateTime FechaEstimada, double TotalEstimado)
        {
            return new PedidoRepository().CrearPedido(ClienteID, EstadoPedidoID, EsPedidoGrande, FechaEstimada, TotalEstimado);
        }

        public void ComprobarLimitePedido()
        {
            /*
            f
            */
        }

        public bool NotificarCancelacionPedido(int ID_Pedido)
        {
            return new PedidoRepository().NotificarCancelacionPedido(ID_Pedido);
        }
        public bool AgregarDetallePedido(int ID_Pedido, int Cantidad)
        {
            return new PedidoRepository().AgregarDetallePedido(ID_Pedido, Cantidad);
        }
        public bool VerificarEstadoPedido(string valor)
        {
            return new PedidoRepository().VerificarEstadoPedido(valor);
        }
    }
}
