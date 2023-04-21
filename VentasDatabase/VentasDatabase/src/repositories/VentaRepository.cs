using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasDatabase.src.entities;

namespace VentasDatabase.src.repositories
{
    internal class VentaRepository
    {
        public MySqlConnection Connection { get; set; }
        public MySqlCommand currentCommand { get; set; }
        public VentaRepository(MySqlConnection connection)
        {
            this.Connection = connection;
            this.currentCommand = new MySqlCommand();
            currentCommand.Connection = connection;
        }

        public List<Venta> getAllVentas()
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "select * from ventas";

            MySqlDataReader reader = currentCommand.ExecuteReader();

            List<Venta> ventas = new();

            while (reader.Read())
            {
                Venta venta = new(reader.GetInt32("id"), reader.GetInt32("id_cliente"), reader.GetString("fecha"), reader.GetInt32("total"));
                ventas.Add(venta);
            }

            reader.Close();

            return ventas;
        }

        public Venta getVentaById(int id)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "select * from ventas where ventas.id = @id";

            currentCommand.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = currentCommand.ExecuteReader();

            Venta? venta = null;

            while (reader.Read())
            {
                venta = new(reader.GetInt32("id"), reader.GetInt32("client_id"), reader.GetString("fecha"), reader.GetInt32("total"));
            }

            reader.Close();

            return venta;

        }


        public List<Venta> getAllVentasByClientId(int clientId)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "select * from ventas where ventas.id_cliente = @id_cliente";

           currentCommand.Parameters.AddWithValue("@id_cliente", clientId);

            MySqlDataReader reader = currentCommand.ExecuteReader();

            List<Venta> ventas = new();

            while (reader.Read())
            {
                Venta venta = new(reader.GetInt32("id"), reader.GetInt32("id_cliente"), reader.GetString("fecha"), reader.GetInt32("total"));
                ventas.Add(venta);
            }

            reader.Close();

            return ventas;

        }

        public void addVenta(Venta venta)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "insert into ventas(id_cliente, fecha, total) VALUES (@id_cliente, @fecha, @total)";

            currentCommand.Parameters.AddWithValue("@id_cliente", venta.ClientId);
            currentCommand.Parameters.AddWithValue("@fecha", venta.Fecha);
            currentCommand.Parameters.AddWithValue("@total", venta.Total);

            currentCommand.ExecuteNonQuery();

        }

        public void updateVenta(Venta venta)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "update ventas set id_cliente = @id_cliente, fecha = @fecha, total = @total where ventas.id = @id";

            currentCommand.Parameters.AddWithValue("@id", venta.Id);
            currentCommand.Parameters.AddWithValue("@id_cliente", venta.ClientId);
            currentCommand.Parameters.AddWithValue("@fecha", venta.Fecha);
            currentCommand.Parameters.AddWithValue("@total", venta.Total);

            currentCommand.ExecuteNonQuery();

        }

        public void deleteVentaById(int id)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "delete from ventas where ventas.id = @id";
            currentCommand.Parameters.AddWithValue("@id", id);

            currentCommand.ExecuteNonQuery();

        }

    }

}
