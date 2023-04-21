using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasDatabase.src.entities
{
    internal class Client
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public Client(string nombre, string telefono, string correo) {
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Correo = correo;
        }

        public Client(int id, string nombre, string telefono, string correo) {
            this.Id = id;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Correo = correo;
        }

        public override string ToString()
        {
            return "Client = {" + " id: " + Id
                + ", nombre: " + Nombre
                + ", telefono: " + Telefono
                + ", correo: " + Correo + " }"; 
        }
    }
}
