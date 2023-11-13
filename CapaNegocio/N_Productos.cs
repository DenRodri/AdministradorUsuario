using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class N_Productos
    {
        D_Productos objDato = new D_Productos();

        public List<E_Productos> ListandoProductos(string buscar)
        {
            return objDato.ListarProductos(buscar);
        }

        public void InsertandoProductos(E_Productos Productos)
        {
            objDato.InsertarProductos(Productos);
        }

        public void EditandoProductos(E_Productos Productos)
        {
            objDato.EditarProductos(Productos);
        }

        public void EliminandoProductos(E_Productos Productos)
        {
            objDato.EliminarProductos(Productos);
        }
    }
}
