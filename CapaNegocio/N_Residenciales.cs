using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Residenciales
    {
        D_Residenciales objDato = new D_Residenciales();

        public List<E_Residenciales> ListandoResidenciales(string buscar)
        {
            return objDato.ListarResidenciales(buscar);
        }

        public void InsertandoResidenciales(E_Residenciales Residenciales)
        {
            objDato.InsertarResidenciales(Residenciales);
        }

        public void EditandoResidenciales(E_Residenciales Residenciales)
        {
            objDato.EditarResidenciales(Residenciales);
        }

        public void EliminandoResidenciales(E_Residenciales Residenciales)
        {
            objDato.EliminarResidenciales(Residenciales);
        }


    }
}
