using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasDatabase.src.entities
{
    internal class Product
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public string Categoria { get; set; }

        public Product(string nombre, int precio, string categoria) {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Categoria = categoria;
        }

        public Product(int id, string nombre, int precio, string categoria)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Categoria = categoria;
        }

        public override string ToString()
        {
            return "Product = {" + " id: " + Id
                + ", nombre: " + Nombre
                + ", precio: " + Precio
                + ", categoria: " + Categoria + " }";
        }
    }
}
