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
    class FacturaService
    {
        readonly IFacturaRepository FacturaRepository;
        public FacturaService()
        {
            FacturaRepository = new FacturaRepository();
        }
        public bool AgregarDetalleFactura(DetalleFactura DetalleFactura)
        {
            return false;
        }

        public bool AgregarDetallesPedidoAFactura(Pedido pedido)
        {
            return false;
        }

        public bool CrearFactura(Cliente Cliente, Empleado Empleado)
        {
            return false;
        }

        public bool GenerarProducto(int Nrofactura, DateTime Fecha, double SubTotal, double Descuento, double igv, double CostoTotal)
        {
            return new FacturaRepository().GenerarProducto(Nrofactura, Fecha, SubTotal, Descuento, igv, CostoTotal);
        }
    }
}
