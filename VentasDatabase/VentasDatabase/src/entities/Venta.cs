using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasDatabase.src.entities
{
    internal class Venta
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Fecha { get; set; }
        public int Total { get; set; }

        public Venta(int clientId, string fecha, int total)
        {
            ClientId = clientId;
            Fecha = fecha;
            Total = total;
        }

        public Venta(int id, int clientId, string fecha, int total)
        {
            Id = id;
            ClientId = clientId;
            Fecha = fecha;
            Total = total;
        }

        public override string ToString()
        {
            return "Venta = {" + " id: " + Id
                + ", cliente_id: " + ClientId
                + ", fecha: " + Fecha
                + ", total: " + Total + " }";
        }
    }
}
