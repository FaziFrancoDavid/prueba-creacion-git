using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REGULARIZACION
{
    internal class Autos : Vehiculos
    {
        //CONTRUCTORES

        public Autos()
        {

        }
        public Autos(int idv, string pat, int km, int año, string idm, string mod, string idseg, string idcom, int preven, string obs, string col, string tipo) : base(idv, pat, km, año, idm, mod, idseg, idcom, preven, obs, col, tipo)
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
    }
}
