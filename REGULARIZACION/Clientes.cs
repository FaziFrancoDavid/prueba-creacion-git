using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REGULARIZACION
{
    internal class Clientes
    {
        //PROPIEDADES
        private int id_cliente;
        private string apellido;
        private string nombre;
        private long dni;
        private string correo;
        private string provincia;
        private string ciudad;


        //CONTRUCTORES

        public Clientes()
        {

        }
        public Clientes(int id, string apellido, string nombre, long dni, string correo, string provincia, string ciudad)
        {
            this.Id_Cliente = id;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Dni = dni;
            this.Correo = correo;
            this.Provincia = provincia;
            this.Ciudad = ciudad;
        }
        public Clientes(string apellido, string nombre, long dni)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Dni = dni;
        }

        //METODOS DE PROPIEDADES

        public int Id_Cliente
        {
            get { return this.id_cliente; }
            set { this.id_cliente = value; }
        }
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public long Dni
        {
            get { return this.dni; }
            set { this.dni = value; }
        }
        public string Correo
        {
            get { return this.correo; }
            set { this.correo = value; }
        }
        public string Provincia
        {
            get { return this.provincia; }
            set { this.provincia = value; }
        }
        public string Ciudad
        {
            get { return this.ciudad; }
            set { this.ciudad = value; }
        }
    }
}
