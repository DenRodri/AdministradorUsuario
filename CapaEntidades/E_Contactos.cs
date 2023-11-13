using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Contactos
    {
        private int _IdContacto;
        private string _Descripcion;
        private string _Telefono;
        private int _Creado_por;

        public int IdContacto { get => _IdContacto; set => _IdContacto = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public int Creado_por { get => _Creado_por; set => _Creado_por = value; }
    }
}
