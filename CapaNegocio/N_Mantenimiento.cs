using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Mantenimiento
    {
        D_Mantenimiento objDato = new D_Mantenimiento();

        public List<E_Mantenimiento> ListandoMantenimiento1(string buscar)
        {
            return objDato.ListarMantenimiento1(buscar);
        }
        public List<E_Mantenimiento> ListandoMantenimiento2(string buscar)
        {
            return objDato.ListarMantenimiento2(buscar);
        }

        public void InsertandoMantenimiento(E_Mantenimiento Mantenimiento)
        {
            objDato.InsertarMantenimiento(Mantenimiento);
        }

        public void EditandoMantenimiento(E_Mantenimiento Mantenimiento)
        {
            objDato.EditarMantenimiento(Mantenimiento);
        }

        public void EliminandoMantenimiento(E_Mantenimiento Mantenimiento)
        {
            objDato.EliminarMantenimiento(Mantenimiento);
        }


    }
}
