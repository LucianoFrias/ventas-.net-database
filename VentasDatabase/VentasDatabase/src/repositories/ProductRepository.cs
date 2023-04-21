using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasDatabase.src.entities;

namespace VentasDatabase.src.repositories
{
    internal class ProductRepository
    {
        public MySqlConnection Connection { get; set; }
        public MySqlCommand currentCommand { get; set; }
        public ProductRepository(MySqlConnection connection)
        {
            this.Connection = connection;
            this.currentCommand = new MySqlCommand();
            currentCommand.Connection = connection;
        }

        public List<Product> getAllProducts()
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "select * from productos";

            MySqlDataReader reader = currentCommand.ExecuteReader();

            List<Product> products = new();

            while (reader.Read())
            {
                Product product = new(reader.GetInt32("id"), reader.GetString("nombre"), reader.GetInt32("precio"), reader.GetString("categoria"));
                products.Add(product);
            }

            reader.Close();

            return products;
        }

        public Product getProductById(int id)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "select * from productos where productos.id = @id";

            currentCommand.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = currentCommand.ExecuteReader();

            Product? product = null;

            while (reader.Read())
            {
                product = new(reader.GetInt32("id"), reader.GetString("nombre"), reader.GetInt32("precio"), reader.GetString("categoria"));
            }

            reader.Close();

            return product;

        }

        public List<Product> getProductsByName(string name)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "select * from productos where @nombre = nombre";

            currentCommand.Parameters.AddWithValue("@nombre", name);

            MySqlDataReader reader = currentCommand.ExecuteReader();

            List<Product> products = new();

            while (reader.Read())
            {
                Product product = new(reader.GetInt32("id"), reader.GetString("nombre"), reader.GetInt32("precio"), reader.GetString("categoria"));
                products.Add(product);
            }

            reader.Close();

            return products;
        }

        public List<Product> getProductsByCategory(string categoryName)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "select * from productos where @categoria = categoria";

            currentCommand.Parameters.AddWithValue("@categoria", categoryName);

            MySqlDataReader reader = currentCommand.ExecuteReader();   

            List<Product> products = new();

            while (reader.Read())
            {
                Product product = new(reader.GetInt32("id"), reader.GetString("nombre"), reader.GetInt32("precio"), reader.GetString("categoria"));
                products.Add(product);
            }

            reader.Close();

            return products;
        }

        public void addProduct(Product product)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "insert into productos(nombre, precio, categoria) VALUES (@nombre, @precio, @categoria)";

            currentCommand.Parameters.AddWithValue("@nombre", product.Nombre);
            currentCommand.Parameters.AddWithValue("@precio", product.Precio);
            currentCommand.Parameters.AddWithValue("@categoria", product.Categoria);

            currentCommand.ExecuteNonQuery();

        }

        public void updateProduct(Product product)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "update productos set nombre = @nombre, precio = @precio, categoria = @categoria where productos.id = @id";

            currentCommand.Parameters.AddWithValue("@id", product.Id);
            currentCommand.Parameters.AddWithValue("@nombre", product.Nombre);
            currentCommand.Parameters.AddWithValue("@precio", product.Precio);
            currentCommand.Parameters.AddWithValue("@categoria", product.Categoria);

            currentCommand.ExecuteNonQuery();

        }

        public void deleteProductById(int id)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "delete from productos where productos.id = @id";
            currentCommand.Parameters.AddWithValue("@id", id);

            currentCommand.ExecuteNonQuery();

        }

    }
}
