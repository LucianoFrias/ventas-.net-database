using MySql.Data.MySqlClient;
using System.Configuration;
using VentasDatabase.src.controllers;
using VentasDatabase.src.database;
using VentasDatabase.src.entities;
using VentasDatabase.src.repositories;
using VentasDatabase.src.utils;

DatabaseConnection databaseConnection = new DatabaseConnection();
MySqlConnection connection = databaseConnection.connect();

ClientController clientController = new(new ClientRepository(connection));
ProductController productController = new(new ProductRepository(connection)); 
VentaController ventaController = new(new VentaRepository(connection));
VentaItemController ventaItemController = new(new VentaItemRepository(connection));


Console.WriteLine("Clientes: ");
foreach (var client in clientController.getAllClients())
{
    Console.WriteLine(client);
}

Console.WriteLine("Productos: ");

foreach (var product in productController.getAllProducts())
{
    Console.WriteLine(product);
}

Console.WriteLine("Productos filtrados por categoria Mate: ");

foreach (var product in productController.getProductsByCategory("Mate"))
{
    Console.WriteLine(product);
}

Console.WriteLine("Productos filtrados por nombre: ");

foreach (var product in productController.getProductsByName("Termo"))
{
    Console.WriteLine(product);
}

Console.WriteLine("Ventas: ");

foreach (var venta in ventaController.getAllVentas())
{
    Console.WriteLine(venta);
}


Console.WriteLine("Ventas filtradas por ID Cliente: ");

foreach (var venta in ventaController.getAllVentasByClientId(2))
{
    Console.WriteLine(venta);
}


Console.WriteLine("Clientes filtrados por nombre: ");
foreach (var cliente in clientController.getClientsByName("Juan"))
{
    Console.WriteLine(cliente);
}

Console.WriteLine("Venta Items: ");
foreach (var ventaItem in ventaItemController.getAllVentaItems())
{
    Console.WriteLine(ventaItem);
}

Console.WriteLine("Venta Items filtrados por ID 2: ");
foreach (var ventaItem in ventaItemController.getVentaItemsByVentaId(2))
{
    Console.WriteLine(ventaItem);
}

ventaItemController.printAllData();

