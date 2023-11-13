using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Transferencia
    {
        private int _IdTransferencia;
        private int _IdProducto;
        private int _IdPropiedad;
        private int _Cantidad;
        private DateTime _Fecha;
        private int _Movido_Por;

        public int IdTransferencia { get => _IdTransferencia; set => _IdTransferencia = value; }
        public int IdProducto { get => _IdProducto; set => _IdProducto = value; }
        public int IdPropiedad { get => _IdPropiedad; set => _IdPropiedad = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public int Movido_Por { get => _Movido_Por; set => _Movido_Por = value; }
    }
}
