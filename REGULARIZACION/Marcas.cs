using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REGULARIZACION
{
    internal class Marcas
    {
        //PROPIEDADES
        private int id_marca;
        private string nombremarca;
        //CONTRUCTORES
        public Marcas()
        {

        }
        public Marcas(int id, string nombre)
        {
            this.Id_Marca = id;
            this.NombreMarca = nombre;
        }

        //METODOS DE PROPIEDADES 
        public int Id_Marca
        {
            get { return this.id_marca; }
            set { this.id_marca = value; }
        }

        public string NombreMarca
        {
            get { return this.nombremarca; }
            set { this.nombremarca = value; }
        }
    }
}
