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
    public class DetalleFacturaService
    {
        readonly IDetalleFacturaRepository DetalleFacturaRepository;
        public DetalleFacturaService()
        {
            DetalleFacturaRepository = new DetalleFacturaRepository();
        }
        public bool REGISTRAR_DetalleFactura(int nrofactura, int seriefactura, int materialID, int cantidad, double preciounit, double subtotal)
        {
            return new DetalleFacturaRepository().REGISTRAR_DetalleFactura(nrofactura, seriefactura, materialID, cantidad, preciounit, subtotal);
        }

        public List<DetalleFactura> BuscarDetalleFactura(int busqueda)
        {
            return new DetalleFacturaRepository().BuscarDetalleFactura(busqueda);
        }
    }
}
