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
    public class EstadoPedidoService
    {
        readonly IEstadoPedidoRepository EstadoPedidoRepository;
        public EstadoPedidoService()
        {
            EstadoPedidoRepository = new EstadoPedidoRepository();
        }
        public List<EstadoPedido> BuscarEstadoPedido()
        {
            return new EstadoPedidoRepository().BuscarEstadoPedido();
        }
    }
}