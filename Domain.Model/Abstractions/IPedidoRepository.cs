using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Abstractions
{
    public interface IPedidoRepository
    {
        bool RegistrarPedido(int ClienteID, bool EsPedidoGrande, DateTime FechaEstimada, double TotalEstimado);

        List<Pedido> ListarPedidos();

        bool AprobarPedido(int ID_PEDIDO);

        bool CancelarPedido(int ID_PEDIDO);

        bool CrearPedido(int ClienteID, int EstadoPedidoID, bool EsPedidoGrande, DateTime FechaEstimada, double TotalEstimado);

        void ComprobarLimitePedido();

        bool NotificarCancelacionPedido(int ID_Pedido);

        bool AgregarDetallePedido(int ID_Pedido, int Cantidad);

        bool VerificarEstadoPedido(string valor);
    }
}
