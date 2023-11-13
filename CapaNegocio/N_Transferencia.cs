using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Transferencia
    {
        D_Transferencia objDato = new D_Transferencia();

        public List<E_Transferencia> ListandoTransferencia1(string buscar)
        {
            return objDato.ListarTransferencia1(buscar);
        }

        public List<E_Transferencia> ListandoTransferencia2(string buscar)
        {
            return objDato.ListarTransferencia2(buscar);
        }

        public List<E_Transferencia> ListandoTransferencia3(string buscar1, string buscar2)
        {
            return objDato.ListarTransferencia3(buscar1, buscar2);
        }

        public void InsertandoTransferencia(E_Transferencia Transferencia)
        {
            objDato.InsertarTransferencia(Transferencia);
        }

        public void EditandoTransferencia(E_Transferencia Transferencia)
        {
            objDato.EditarTransferencia(Transferencia);
        }

        public void EliminandoTransferencia(E_Transferencia Transferencia)
        {
            objDato.EliminarTransferencia(Transferencia);
        }


    }
}
