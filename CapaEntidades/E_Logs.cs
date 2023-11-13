using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Logs
    {
        private int _idUsuario;
        private DateTime _loginTime;
        private DateTime _logoutTime;

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public DateTime LoginTime { get => _loginTime; set => _loginTime = value; }
        public DateTime LogoutTime { get => _logoutTime; set => _logoutTime = value; }
    }
}
