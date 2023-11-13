using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Mantenimiento
    {
        private int _IdMantenimiento;
        private int _IdPropiedad;
        private string _Descripcion;
        private decimal _Costo;
        private int _Creado_por;

        public int IdMantenimiento { get => _IdMantenimiento; set => _IdMantenimiento = value; }
        public int IdPropiedad { get => _IdPropiedad; set => _IdPropiedad = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public decimal Costo { get => _Costo; set => _Costo = value; }
        public int Creado_por { get => _Creado_por; set => _Creado_por = value; }
    }
}
