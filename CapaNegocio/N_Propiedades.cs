using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Propiedades
    {
        D_Propiedades objDato = new D_Propiedades();

        public List<E_Propiedades> ListandoPropiedades(string buscar)
        {
            return objDato.ListarPropiedades(buscar);
        }

        public void InsertandoPropiedades(E_Propiedades Propiedades)
        {
            objDato.InsertarPropiedades(Propiedades);
        }

        public void EditandoPropiedades(E_Propiedades Propiedades)
        {
            objDato.EditarPropiedades(Propiedades);
        }

        public void EliminandoPropiedades(E_Propiedades Propiedades)
        {
            objDato.EliminarPropiedades(Propiedades);
        }


    }
}
