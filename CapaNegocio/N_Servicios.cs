using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Servicios
    {
        D_Servicios objDato = new D_Servicios();

        public List<E_Servicios> ListandoServicios(string buscar)
        {
            return objDato.ListarServicios(buscar);
        }

        public void InsertandoServicios(E_Servicios Servicios)
        {
            objDato.InsertarServicios(Servicios);
        }

        public void EditandoServicios(E_Servicios Servicios)
        {
            objDato.EditarServicios(Servicios);
        }

        public void EliminandoServicios(E_Servicios Servicios)
        {
            objDato.EliminarServicios(Servicios);
        }


    }
}
