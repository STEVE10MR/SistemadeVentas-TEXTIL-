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
    public class MaterialService
    {
        readonly IMaterialsRepository MaterialRepository;
        public MaterialService()
        {
            MaterialRepository = new MaterialRepository();
        }
        public bool ActualizarMaterial(double Porcentaje,double DescPorcentaje, double preciounit, int ID_Material)
        {
            LimiteVenta OBJLimiteventa = new LimiteVenta();
            OBJLimiteventa.DescPorcentaje = Porcentaje;
            OBJLimiteventa.Porcentaje = DescPorcentaje;
            OBJLimiteventa.FechaUltimoCambio = DateTime.Today;
            return MaterialRepository.ActualizarMaterial(OBJLimiteventa,preciounit,ID_Material);
        }

        public bool AumentarStock(int ID_Material, int cantidad)
        {
            return MaterialRepository.AumentarStock(ID_Material,cantidad);
        }

        public List<Material> BuscarMaterial(string Buscar)
        {
            return MaterialRepository.BuscarMaterial(Buscar);
        }

        public bool RegistrarMaterial(string nombre, string descripcion, double preciounit, string unidad, int stock)
        {
            Material OBJMaterial = new Material();
            OBJMaterial.Nombre = nombre;
            OBJMaterial.Descripcion = descripcion;
            OBJMaterial.PrecioUnit = preciounit;
            OBJMaterial.Unidad = unidad;
            OBJMaterial.Stock = stock;
            return MaterialRepository.RegistrarMaterial(OBJMaterial);
        }

        public bool ReservarMaterial(int cantidad, int ID_Material)
        {
            return MaterialRepository.ReservarMaterial(cantidad,ID_Material);
        }
    }
}
