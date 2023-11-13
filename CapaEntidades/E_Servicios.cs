using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Servicios
    {
        private int _idServicio;
        private int _IdPropiedad;
        private decimal _Internet;
        private decimal _Luz;

        public int IdServicio { get => _idServicio; set => _idServicio = value; }
        public int IdPropiedad { get => _IdPropiedad; set => _IdPropiedad = value; }
        public decimal Internet { get => _Internet; set => _Internet = value; }
        public decimal Luz { get => _Luz; set => _Luz = value; }
    }
}
