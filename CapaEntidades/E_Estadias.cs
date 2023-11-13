using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Estadias
    {
        private int _IdCliente;
        private int _IdPropiedad;
        private int _IdEmpleado;
        private int _CantNoches;
        private DateTime _Fecha;
        private Boolean _Cancelacion;
        private decimal _Reembolso;

        public int IdCliente { get => _IdCliente; set => _IdCliente = value; }
        public int IdPropiedad { get => _IdPropiedad; set => _IdPropiedad = value; }
        public int IdEmpleado { get => _IdEmpleado; set => _IdEmpleado = value; }
        public int CantNoches { get => _CantNoches; set => _CantNoches = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public bool Cancelacion { get => _Cancelacion; set => _Cancelacion = value; }
        public decimal Reembolso { get => _Reembolso; set => _Reembolso = value; }
    }
}
