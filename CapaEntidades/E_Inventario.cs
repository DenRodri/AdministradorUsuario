using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Inventario
    {
        private int _IdInventario;
        private int _IdProducto;
        private int _Comprado_por;
        private int _Cantidad;
        private DateTime _Fecha;

        public int IdInventario { get => _IdInventario; set => _IdInventario = value; }
        public int IdProducto { get => _IdProducto; set => _IdProducto = value; }
        public int Comprado_por { get => _Comprado_por; set => _Comprado_por = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
    }
}
