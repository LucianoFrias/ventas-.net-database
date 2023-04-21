using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasDatabase.src.entities;
using VentasDatabase.src.repositories;

namespace VentasDatabase.src.controllers
{
    internal class VentaController
    {
        public VentaRepository VentaRepository { get; set; }
        public VentaController(VentaRepository ventaRepository)
        { VentaRepository = ventaRepository; }

        public List<Venta> getAllVentas()
        {
            return VentaRepository.getAllVentas();
        }

        public Venta getVentaById(int id)
        {
            return VentaRepository.getVentaById(id);
        }

        public List<Venta> getAllVentasByClientId(int clientId)
        {
            return VentaRepository.getAllVentasByClientId(clientId);
        }

        public void addVenta(Venta venta)
        {
            VentaRepository.addVenta(venta);
        }

        public void updateVenta(Venta venta)
        {
            VentaRepository.updateVenta(venta);
        }

        public void deleteVentaById(int id)
        {
            VentaRepository.deleteVentaById(id);
        }
    }
}
