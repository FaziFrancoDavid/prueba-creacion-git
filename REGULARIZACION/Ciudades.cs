using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REGULARIZACION
{
    internal class Ciudades
    {
        //PROPIEDADES
        private int id_ciudad;
        private string nombre;

        //CONTRUCTORES
        public Ciudades()
        {

        }

        public Ciudades(int id, string nombre)
        {
            this.Id_Ciudad = id;
            this.Nombre = nombre;
        }

        //METODOS DE PROPIEDADES
        public int Id_Ciudad
        {
            get { return this.id_ciudad; }
            set { this.id_ciudad = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
    }
}
