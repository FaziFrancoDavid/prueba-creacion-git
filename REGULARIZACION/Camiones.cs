using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REGULARIZACION
{
    internal class Camiones:Vehiculos
    {
        //PROPIEDADES
        private string caja_carga;
        private int dimension_caja;
        private int carga_max;

        //CONTRUCTORES
        public Camiones()
        {

        }
        public Camiones(int idv, string pat, int km, int año, string idm, string mod, string idseg, string idcom, int preven, string obs, string col, string tipo, string caja, int dimen, int carmax) : base(idv, pat, km, año, idm, mod, idseg, idcom, preven, obs, col, tipo)
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
            this.Caja_Carga = caja;
            this.Dimensiones_Caja = dimen;
            this.Carga_Max = carmax;
        }

        //METODOS DE PROPIEDADES
        public string Caja_Carga
        {
            get { return this.caja_carga; }
            set { this.caja_carga = value; }
        }
        public int Dimensiones_Caja
        {
            get { return this.dimension_caja; }
            set { this.dimension_caja = value; }
        }
        public int Carga_Max
        {
            get { return this.carga_max; }
            set { this.carga_max = value; }
        }
    }
}
