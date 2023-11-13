using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Clientes
    {
        D_Clientes objDato = new D_Clientes();

        public List<E_Clientes> ListandoClientes(string buscar)
        {
            return objDato.ListarClientes(buscar);
        }

        public void InsertandoClientes(E_Clientes Clientes)
        {
            objDato.InsertarClientes(Clientes);
        }

        public void EditandoClientes(E_Clientes Clientes)
        {
            objDato.EditarClientes(Clientes);
        }

        public void EliminandoClientes(E_Clientes Clientes)
        {
            objDato.EliminarClientes(Clientes);
        }


    }
}
