using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Contactos
    {
        D_Contactos objDato = new D_Contactos();

        public List<E_Contactos> ListandoContactos(string buscar)
        {
            return objDato.ListarContactos(buscar);
        }

        public void InsertandoContactos(E_Contactos Contactos)
        {
            objDato.InsertarContactos(Contactos);
        }

        public void EditandoContactos(E_Contactos Contactos)
        {
            objDato.EditarContactos(Contactos);
        }

        public void EliminandoContactos(E_Contactos Contactos)
        {
            objDato.EliminarContactos(Contactos);
        }


    }
}
