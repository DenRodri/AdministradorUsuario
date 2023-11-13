using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_PropiedadResidenciales
    {
        private int _idPropiedad;
        private int? _idResidencial;

        public int IdPropiedad { get => _idPropiedad; set => _idPropiedad = value; }
        public int? IdResidencial { get => _idResidencial; set => _idResidencial = value; }
    }
}
