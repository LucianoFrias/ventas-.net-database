using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasDatabase.src.entities;

namespace VentasDatabase.src.repositories
{
    internal class VentaItemRepository
    {
        public MySqlConnection Connection { get; set; }
        public MySqlCommand currentCommand { get; set; }
        public VentaItemRepository(MySqlConnection connection)
        {
            this.Connection = connection;
            this.currentCommand = new MySqlCommand();
            currentCommand.Connection = connection;
        }

        public List<VentaItem> getAllVentaItems()
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "select * from ventas_items";

            MySqlDataReader reader = currentCommand.ExecuteReader();

            List<VentaItem> ventaItems = new();

            while (reader.Read())
            {
                VentaItem ventaItem = new(reader.GetInt32("id"), reader.GetInt32("id_venta"), reader.GetInt32("id_producto"), reader.GetInt32("precio_unitario"), reader.GetInt32("cantidad"), reader.GetInt32("precio_total"));
                ventaItems.Add(ventaItem);
            }

            reader.Close();

            return ventaItems;
        }

        public VentaItem getVentaItemById(int id)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "select * from ventas_items where venta_items.id = @id";

            currentCommand.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = currentCommand.ExecuteReader();

            VentaItem? ventaItem = null;

            while (reader.Read())
            {
                ventaItem = new(reader.GetInt32("id"), reader.GetInt32("id_venta"), reader.GetInt32("id_producto"), reader.GetInt32("precio_unitario"), reader.GetInt32("cantidad"), reader.GetInt32("precio_total"));
            }

            reader.Close();

            return ventaItem;

        }

        public List<VentaItem> getVentaItemsByVentaId(int id_venta)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "select * from ventas_items where id_venta = @id";

            currentCommand.Parameters.AddWithValue("@id", id_venta);

            MySqlDataReader reader = currentCommand.ExecuteReader();

            List<VentaItem> ventasItems = new();

            while (reader.Read())
            {
                VentaItem ventaItem = new(reader.GetInt32("id"), reader.GetInt32("id_venta"), reader.GetInt32("id_producto"), reader.GetInt32("precio_unitario"), reader.GetInt32("cantidad"), reader.GetInt32("precio_total"));
                ventasItems.Add(ventaItem);
            }

            reader.Close();

            return ventasItems;
        }

        public List<VentaItem> getVentaItemsByProductId(int id_producto)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "select * from ventas_items where id_producto = @id";

            currentCommand.Parameters.AddWithValue("@id", id_producto);

            MySqlDataReader reader = currentCommand.ExecuteReader();

            List<VentaItem> ventasItems = new();

            while (reader.Read())
            {
                VentaItem ventaItem = new(reader.GetInt32("id"), reader.GetInt32("id_venta"), reader.GetInt32("id_producto"), reader.GetInt32("precio_unitario"), reader.GetInt32("cantidad"), reader.GetInt32("precio_total"));
                ventasItems.Add(ventaItem);
            }

            reader.Close();

            return ventasItems;
        }

        public void addVentaItem(VentaItem ventaItem)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "insert into ventas_items(id_venta, id_producto, precio_unitario, cantidad, precio_total) VALUES (@id_venta, @id_producto, @precio_unitario, @cantidad, @precio_total)";

            currentCommand.Parameters.AddWithValue("@id_venta", ventaItem.IdVenta);
            currentCommand.Parameters.AddWithValue("@id_producto", ventaItem.IdProducto);
            currentCommand.Parameters.AddWithValue("@precio_unitario", ventaItem.PrecioUnitario);
            currentCommand.Parameters.AddWithValue("@cantidad", ventaItem.Cantidad);
            currentCommand.Parameters.AddWithValue("@precio_total", ventaItem.PrecioTotal);

            currentCommand.ExecuteNonQuery();

        }

        public void updateVentaItem(VentaItem ventaItem)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "update ventas_items set id_venta = @id_venta, id_producto = @id_producto, precio_unitario = @precio_unitario, cantidad = @cantidad, precio_total = @precio_total where ventas_items.id = @id";

            currentCommand.Parameters.AddWithValue("@id", ventaItem.Id);
            currentCommand.Parameters.AddWithValue("@id_venta", ventaItem.IdVenta);
            currentCommand.Parameters.AddWithValue("@id_producto", ventaItem.IdProducto);
            currentCommand.Parameters.AddWithValue("@precio_unitario", ventaItem.PrecioUnitario);
            currentCommand.Parameters.AddWithValue("@cantidad", ventaItem.Cantidad);
            currentCommand.Parameters.AddWithValue("@precio_total", ventaItem.PrecioTotal);

            currentCommand.ExecuteNonQuery();

        }

        public void deleteVentaItemById(int id)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "delete from ventas_items where ventas_items.id = @id";
            currentCommand.Parameters.AddWithValue("@id", id);

            currentCommand.ExecuteNonQuery();

        }

        public void printAllData() 
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "select * from ventas_items inner join ventas on ventas_items.id_venta = ventas.id inner join clientes on ventas.id_cliente = clientes.id inner join productos on ventas_items.id_producto = productos.id";

            MySqlDataReader reader = currentCommand.ExecuteReader();

            

            while (reader.Read())
            {
                Console.WriteLine("ID VentaItem: " + reader.GetInt32("id") + " Precio Unitario: " + reader.GetInt32("precio_unitario") + " Cantidad: " + reader.GetInt32("cantidad") + " Precio Total: " + reader.GetInt32("precio_total") + " Nombre de cliente: " + reader.GetString("cliente") + " Telefono: " + reader.GetString("telefono") + " Nombre de producto: " + reader.GetString("nombre"));
            }
        }

    }
}
