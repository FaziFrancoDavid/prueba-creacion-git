using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REGULARIZACION
{
    internal class Ventas : Clientes
    {
        //PROPIEDADES

        private string fechacompra;
        private string fechaentrega;
        private double descuento;
        private double precio;
        private int id_vehiculo;
        private string patente;
        private string marca;
        private string modelo;
        private int año;
        private string color;


        //CONTRUCTORES
        public Ventas()
        {

        }
        public Ventas(string apellido, string nombre, long dni, string fechacompra, string fechaentrega, double desc, double precio) : base(apellido, nombre, dni)
        {
            this.FechaCompra = fechacompra;
            this.FechaEntrega = fechaentrega;
            this.Descuento = desc;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Precio = precio;
        }
        public Ventas(string apellido, string nombre, long dni, string fechacompra, string fechaentrega, double desc, double precio, string marc, string mod, string pat, int año, string col) : base(apellido, nombre, dni)
        {
            this.FechaCompra = fechacompra;
            this.FechaEntrega = fechaentrega;
            this.Descuento = desc;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Precio = precio;
            this.MARCA = marc;
            this.MODELO = mod;
            this.PATENTE = pat;
            this.AÑO = año;
            this.COLOR = col;

        }
        //METODOS DE PROPIEDADES

        public string FechaCompra
        {
            get { return this.fechacompra; }
            set { this.fechacompra = value; }
        }
        public string FechaEntrega
        {
            get { return this.fechaentrega; }
            set { this.fechaentrega = value; }
        }
        public double Iva
        {
            get
            {
                double calculo = (this.Precio * 1.21) - this.Precio;
                return calculo;
            }
        }
        public double Descuento
        {
            get
            {
                double calculo = this.Precio * (this.descuento / 100);
                return calculo;
            }
            set { this.descuento = value; }
        }
        public double Total
        {
            get
            {
                double calculototal = (this.Precio + this.Iva) - this.Descuento;
                return calculototal;
            }

        }
        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        //OTROS
        public int ID_VEHICULO_VENTA
        {
            get { return this.id_vehiculo; }
            set { this.id_vehiculo = value; }
        }
        public string PATENTE
        {
            get { return this.patente; }
            set { this.patente = value; }
        }
        public string MARCA
        {
            get { return this.marca; }
            set { this.marca = value; }
        }
        public string MODELO
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }
        public int AÑO
        {
            get { return this.año; }
            set { this.año = value; }
        }
        public string COLOR
        {
            get { return this.color; }
            set { this.color = value; }
        }
    }
}
