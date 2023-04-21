using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasDatabase.src.entities
{
    internal class VentaItem
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int PrecioTotal { get; set; }

        public VentaItem(int idVenta, int idProducto, int precioUnitario, int cantidad, int precioTotal)
        {
            IdVenta = idVenta;
            IdProducto = idProducto;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
            PrecioTotal = precioTotal;
        }

        public VentaItem(int id, int idVenta, int idProducto, int precioUnitario, int cantidad, int precioTotal)
        {
            Id = id;
            IdVenta = idVenta;
            IdProducto = idProducto;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
            PrecioTotal = precioTotal;
        }
        public override string ToString()
        {
            return "VentaItem = {" + " id: " + Id
                + ", id_venta: " + IdVenta
                + ", id_producto: " + IdProducto
                + ", precio_unitario: " + PrecioUnitario 
                + ", cantidad: " + Cantidad
                + ", precio_total: " + PrecioTotal +
                " }";
        }
    }
}
