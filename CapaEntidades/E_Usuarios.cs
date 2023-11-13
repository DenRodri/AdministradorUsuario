using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Usuarios
    {
        private int _IdUsuario;
        private string _Username;
        private string _Passwrd;
        private string _Nombre;
        private string _Apellido;
        private string _Email;
        private string _Telefono;
        private string _Sexo;
        private DateTime _Fecha_Nacimiento;
        private DateTime _Fecha_Contrato;
        private DateTime _Fecha_Creacion_Cuenta;
        private Boolean _Activo;
        private Boolean _Estado;
        private int _Rol;
        private int _Creado_Por;

        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public string Username { get => _Username; set => _Username = value; }
        public string Passwrd { get => _Passwrd; set => _Passwrd = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Fecha_Nacimiento { get => _Fecha_Nacimiento; set => _Fecha_Nacimiento = value; }
        public DateTime Fecha_Contrato { get => _Fecha_Contrato; set => _Fecha_Contrato = value; }
        public DateTime Fecha_Creacion_Cuenta { get => _Fecha_Creacion_Cuenta; set => _Fecha_Creacion_Cuenta = value; }
        public bool Activo { get => _Activo; set => _Activo = value; }
        public bool Estado { get => _Estado; set => _Estado = value; }
        public int Rol { get => _Rol; set => _Rol = value; }
        public int Creado_Por { get => _Creado_Por; set => _Creado_Por = value; }
     
    }
}
