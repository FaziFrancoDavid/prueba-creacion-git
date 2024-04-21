using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REGULARIZACION
{
    internal class Motos : Vehiculos
    {
        //PROPIEDADES
        private int cilindrada;

        //CONTRCUTORES
        public Motos()
        {

        }
        public Motos(int idv, string pat, int km, int año, string idm, string mod, string idseg, string idcom, int preven, string obs, string col, string tipo, int cilindrada) : base(idv, pat, km, año, idm, mod, idseg, idcom, preven, obs, col, tipo)
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
            this.Cilindrada = cilindrada;
        }

        //METODOS DE PROPIEDADES

        public int Cilindrada
        {
            get { return this.cilindrada; }
            set { this.cilindrada = value; }
        }
    }
}
