using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_PropiedadResidenciales
    {
        D_PropiedadResidenciales objDato = new D_PropiedadResidenciales();

        public List<E_PropiedadResidenciales> ListandoPropiedadResidenciales(string buscar)
        {
            return objDato.ListarPropiedadResidenciales(buscar);
        }

        public void InsertandoPropiedadResidenciales(E_PropiedadResidenciales PropiedadResidenciales)
        {
            objDato.InsertarPropiedadResidenciales(PropiedadResidenciales);
        }

        public void EditandoPropiedadResidenciales(E_PropiedadResidenciales PropiedadResidenciales)
        {
            objDato.EditarPropiedadResidenciales(PropiedadResidenciales);
        }

        public void EliminandoPropiedadResidenciales(E_PropiedadResidenciales PropiedadResidenciales)
        {
            objDato.EliminarPropiedadResidenciales(PropiedadResidenciales);
        }


    }
}
