using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Residenciales
    {
        private int _idResidencial;
        private string _Nombre;
        private string _Calle;
        private string _Sector;
        private string _Municipio;
        private string _Provincia;
        private string _Num_Contacto;
        private int _Creado_Por;

        public int IdResidencial { get => _idResidencial; set => _idResidencial = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Calle { get => _Calle; set => _Calle = value; }
        public string Sector { get => _Sector; set => _Sector = value; }
        public string Municipio { get => _Municipio; set => _Municipio = value; }
        public string Provincia { get => _Provincia; set => _Provincia = value; }
        public string Num_Contacto { get => _Num_Contacto; set => _Num_Contacto = value; }
        public int Creado_Por { get => _Creado_Por; set => _Creado_Por = value; }
    }
}
