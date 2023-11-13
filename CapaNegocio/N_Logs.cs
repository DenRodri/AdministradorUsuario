using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Logs
    {
        D_Logs objDato = new D_Logs();

        public List<E_Logs> ListandoLogs(string buscar)
        {
            return objDato.ListarLogs(buscar);
        }

        public void InsertandoLogs(E_Logs Logs)
        {
            objDato.InsertarLogs(Logs);
        }

        public void EditandoLogs(E_Logs Logs)
        {
            objDato.EditarLogs(Logs);
        }

        public void EliminandoLogs(E_Logs Logs)
        {
            objDato.EliminarLogs(Logs);
        }


    }
}
