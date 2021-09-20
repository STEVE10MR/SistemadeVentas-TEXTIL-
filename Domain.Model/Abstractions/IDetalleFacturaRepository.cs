using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Abstractions
{
    public interface IDetalleFacturaRepository
    {
        bool REGISTRAR_DetalleFactura(int nrofactura, int seriefactura, int materialID, int cantidad, double preciounit, double subtotal);
        List<DetalleFactura> BuscarDetalleFactura(int busqueda);
    }
}