using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Clientes
    {
        private int _idCliente;
        private string _Nombre;
        private string _Apellido;
        private string _Nacionalidad;
        private string _Sexo;
        private int _Creado_Por;

        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Nacionalidad { get => _Nacionalidad; set => _Nacionalidad = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public int Creado_Por { get => _Creado_Por; set => _Creado_Por = value; }
        
    }
}
