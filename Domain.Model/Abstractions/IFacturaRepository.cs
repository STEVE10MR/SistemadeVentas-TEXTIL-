using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Abstractions
{
    public interface IFacturaRepository
    {
        bool GenerarProducto(int Nrofactura, DateTime Fecha, double SubTotal, double Descuento, double igv, double CostoTotal);
    }
}
