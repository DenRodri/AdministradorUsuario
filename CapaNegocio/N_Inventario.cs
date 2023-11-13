using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Inventario
    {
        D_Inventario objDato = new D_Inventario();

        public List<E_Inventario> ListandoInventario(string buscar)
        {
            return objDato.ListarInventario(buscar);
        }

        public void InsertandoInventario(E_Inventario Inventario)
        {
            objDato.InsertarInventario(Inventario);
        }

        public void EditandoInventario(E_Inventario Inventario)
        {
            objDato.EditarInventario(Inventario);
        }

        public void EliminandoInventario(E_Inventario Inventario)
        {
            objDato.EliminarInventario(Inventario);
        }


    }
}
