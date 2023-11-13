using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Productos
    {
        private int _IdProducto;
        private string _Descripcion;
        private decimal _Costo;
        private int _Cantidad;
        private DateTime _Fecha_Compra;


        public int IdProducto { get => _IdProducto; set => _IdProducto = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public decimal Costo { get => _Costo; set => _Costo = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public DateTime Fecha_Compra { get => _Fecha_Compra; set => _Fecha_Compra = value; }

    }
}
