using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Factura
    {
        public int NroFactura { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Empleado { get; set; }
        public virtual Cliente Cliente { get; private set; }
        public virtual Empleado Empleado { get; private set; }
        public int SerieFactura { get; set; }
        public DateTime Fechastatic { get; set; }
        public double Subtotal { get; set; }
        public double Descuento { get; set; }
        public double IGV { get; set; }
        public double CostoTotal { get; set; }
    }
}
