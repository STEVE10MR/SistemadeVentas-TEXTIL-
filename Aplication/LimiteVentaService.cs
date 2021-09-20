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
    public class LimiteVentaService
    {
        readonly ILimiteVentaRepository LimiteVentaRepository;
        public LimiteVentaService()
        {
            LimiteVentaRepository = new LimiteVentaRepository();
        }
        public LimiteVenta BuscarLimitesVenta(int ID_M) 
        {
            return LimiteVentaRepository.BuscarLimitesVenta(ID_M);
        }
        public bool ActualizarLimiteVenta(int ID_M, double DECPORC, double PORC, DateTime FECHA) 
        {
            return LimiteVentaRepository.ActualizarLimiteVenta(ID_M, DECPORC, PORC, FECHA);
        }
    }
}
