using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REGULARIZACION
{
    internal class Vehiculos
    {
        //PROPIEDADES
        private int id_vehiculo;
        private string patente;
        private int kilometro;
        private int año;
        private string id_marca;
        private string modelo;
        private string id_segmento;
        private string id_combustible;
        private int precio_venta;
        private string observaciones;
        private string color;
        private string tipo;

        //CONTRUCTORES
        public Vehiculos()
        {

        }
        public Vehiculos(int idv, string pat, int km, int año, string idm, string mod, string idseg, string idcom, int preven, string obs, string col, string tipo)
        {
            this.Id_Vehiculo = idv;
            this.Patente = pat;
            this.Kilometro = km;
            this.Año = año;
            this.Id_Marca = idm;
            this.Modelo = mod;
            this.Id_Segmento = idseg;
            this.Id_Combustible = idcom;
            this.Precio_venta = preven;
            this.Observaciones = obs;
            this.Color = col;
            this.Tipo = tipo;
        }

        //METODOS DE PROPIEDADES
        public int Id_Vehiculo
        {
            get { return this.id_vehiculo; }
            set { this.id_vehiculo = value; }
        }
        public string Patente
        {
            get { return this.patente; }
            set { patente = value; }
        }
        public int Kilometro
        {
            get { return this.kilometro; }
            set { kilometro = value; }
        }
        public int Año
        {
            get { return this.año; }
            set { año = value; }
        }
        public string Id_Marca
        {
            get { return this.id_marca; }
            set { this.id_marca = value; }
        }
        public string Modelo
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }
        public string Id_Segmento
        {
            get { return this.id_segmento; }
            set { this.id_segmento = value; }
        }
        public string Id_Combustible
        {
            get { return this.id_combustible; }
            set { this.id_combustible = value; }
        }
        public int Precio_venta
        {
            get { return this.precio_venta; }
            set { this.precio_venta = value; }
        }
        public string Observaciones
        {
            get { return this.observaciones; }
            set { this.observaciones = value; }
        }
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public string Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }
        
    }
}
