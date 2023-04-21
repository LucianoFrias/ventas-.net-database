using MySql.Data.MySqlClient;
using System.Data;
using VentasDatabase.src.entities;

namespace VentasDatabase.src.repositories
{
    internal class ClientRepository
    {
        public MySqlConnection Connection { get; set; }
        public MySqlCommand currentCommand { get; set; }
        public ClientRepository(MySqlConnection connection) {
            this.Connection = connection;    
            this.currentCommand = new MySqlCommand();
            currentCommand.Connection = connection;
        }

        public List<Client> getAllClients()
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "select * from clientes";

            MySqlDataReader reader = currentCommand.ExecuteReader();

            List<Client> clients = new();

            while (reader.Read())
            {
                Client client = new(reader.GetInt32("id"), reader.GetString("cliente"), reader.GetString("telefono"), reader.GetString("correo"));
                clients.Add(client);
            }

            reader.Close();

            return clients;
        }

        public Client getClientById(int id)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "select * from clientes where clientes.id = @id";

            currentCommand.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = currentCommand.ExecuteReader();

            Client? client = null;

            while (reader.Read()) {

                client = new(reader.GetInt32("id"), reader.GetString("cliente"), reader.GetString("telefono"), reader.GetString("correo"));
            }

            reader.Close();

            return client;
            
        }

        public List<Client> getClientsByName(string name)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "select * from clientes where clientes.cliente = @nombre";

            currentCommand.Parameters.AddWithValue("@nombre", name);

            MySqlDataReader reader = currentCommand.ExecuteReader();

            List<Client> clients = new();

           while (reader.Read())
           {
                Client client = new(reader.GetInt32("id"), reader.GetString("cliente"), reader.GetString("telefono"), reader.GetString("correo"));
                clients.Add(client);
           }

           reader.Close();

            return clients;

        }

        public void addClient(Client client)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "insert into clientes(cliente, correo, telefono) VALUES (@cliente, @correo, @telefono)";

            currentCommand.Parameters.AddWithValue("@cliente", client.Nombre);
            currentCommand.Parameters.AddWithValue("@correo", client.Correo);
            currentCommand.Parameters.AddWithValue("@telefono", client.Telefono);

            currentCommand.ExecuteNonQuery();

        }

       public void updateClient(Client client)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "update clientes set cliente = @nombre, telefono = @telefono, correo = @correo where clientes.id = @id";

            currentCommand.Parameters.AddWithValue("@id", client.Id);
            currentCommand.Parameters.AddWithValue("@nombre", client.Nombre);
            currentCommand.Parameters.AddWithValue("@telefono", client.Telefono);
            currentCommand.Parameters.AddWithValue("@correo", client.Correo);

            currentCommand.ExecuteNonQuery();

        }

       public void deleteClientById(int id)
        {
            currentCommand.Parameters.Clear();
            currentCommand.CommandText = "delete from clientes where clientes.id = @id";
            currentCommand.Parameters.AddWithValue("@id", id);

            currentCommand.ExecuteNonQuery();

        }


    }
}
