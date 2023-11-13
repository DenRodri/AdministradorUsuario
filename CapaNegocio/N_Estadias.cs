using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Estadias
    {
        D_Estadias objDato = new D_Estadias();

        public List<E_Estadias> ListandoEstadias(string buscar)
        {
            return objDato.ListarEstadias(buscar);
        }

        public void InsertandoEstadias(E_Estadias Estadias)
        {
            objDato.InsertarEstadias(Estadias);
        }

        public void EditandoEstadias(E_Estadias Estadias)
        {
            objDato.EditarEstadias(Estadias);
        }

        public void EliminandoEstadias(E_Estadias Estadias)
        {
            objDato.EliminarEstadias(Estadias);
        }


    }
}
