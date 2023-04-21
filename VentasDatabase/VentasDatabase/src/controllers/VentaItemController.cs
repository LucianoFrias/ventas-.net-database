using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasDatabase.src.entities;
using VentasDatabase.src.repositories;

namespace VentasDatabase.src.controllers
{
    internal class VentaItemController
    {
        public VentaItemRepository VentaItemRepository { get; set; }
        public VentaItemController(VentaItemRepository ventaItemRepository)
        {
            VentaItemRepository = ventaItemRepository;
        }


        public List<VentaItem> getAllVentaItems()
        {
            return VentaItemRepository.getAllVentaItems();
        }

        public VentaItem GetVentaItemById(int id)
        {
            return VentaItemRepository.getVentaItemById(id);
        }

        public List<VentaItem> getVentaItemsByVentaId(int id)
        {
            return VentaItemRepository.getVentaItemsByVentaId((int)id);
        }

        public void addVentaItem(VentaItem item)
        {
            VentaItemRepository.addVentaItem(item);
        }

        public void updateVentaItem(VentaItem item)
        {
            VentaItemRepository.updateVentaItem(item);
        }

        public void deleteVentaItemById(int id)
        {
            VentaItemRepository.deleteVentaItemById(id);
        }

        public void printAllData()
        {
            VentaItemRepository.printAllData();
        }
    }
}
