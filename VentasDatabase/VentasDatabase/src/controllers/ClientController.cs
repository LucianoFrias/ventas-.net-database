using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasDatabase.src.entities;
using VentasDatabase.src.repositories;

namespace VentasDatabase.src.controllers
{
    internal class ClientController
    {
        public ClientRepository ClientRepository { get; set; }

        public ClientController(ClientRepository repository)
        {  ClientRepository = repository; }

        public List<Client> getAllClients()
        {
            return ClientRepository.getAllClients();
        }

        public Client getClientById(int id)
        {
            return ClientRepository.getClientById(id);
        }

        public List<Client> getClientsByName(string name)
        {
            return ClientRepository.getClientsByName(name);
        }

        public void addClient(Client client)
        { 
            ClientRepository.addClient(client);
        }

        public void updateClient(Client client) 
        {
            ClientRepository.updateClient(client);
        }

        public void deleteClientById(int id)
        {
            ClientRepository.deleteClientById(id);
        }
    }
}
