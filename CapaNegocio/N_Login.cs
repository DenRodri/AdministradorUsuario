using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaNegocio
{
    public class N_Login
    {
        public E_Usuarios GetUsuario(string username, string password)
        {
            D_Usuarios loginDAO = new D_Usuarios();
            return loginDAO.GetUsuario(username, password);
        }
    }
}
