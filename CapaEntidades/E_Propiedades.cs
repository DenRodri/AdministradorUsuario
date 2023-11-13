using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Propiedades
    {
        private int _idPropiedad;
        private string _Calle;
        private string _Sector;
        private string _Municipio;
        private string _Provincia;
        private int _creado_por;
        private int _CantBathroom;
        private int _CantRooms;
        private int _NumeroParqueo;
        private decimal _Costo_Noche;
        private int _Oferta;
        private DateTime _Fecha_Compra;
        private decimal _Compro_Costo;
        private string _TipoCasa;
        private Boolean _Disponible;

        public int IdPropiedad { get => _idPropiedad; set => _idPropiedad = value; }
        public string Calle { get => _Calle; set => _Calle = value; }
        public string Sector { get => _Sector; set => _Sector = value; }
        public string Municipio { get => _Municipio; set => _Municipio = value; }
        public string Provincia { get => _Provincia; set => _Provincia = value; }
        public int Creado_por { get => _creado_por; set => _creado_por = value; }
        public int CantBathroom { get => _CantBathroom; set => _CantBathroom = value; }
        public int CantRooms { get => _CantRooms; set => _CantRooms = value; }
        public int NumeroParqueo { get => _NumeroParqueo; set => _NumeroParqueo = value; }
        public decimal Costo_Noche { get => _Costo_Noche; set => _Costo_Noche = value; }
        public int Oferta { get => _Oferta; set => _Oferta = value; }
        public DateTime Fecha_Compra { get => _Fecha_Compra; set => _Fecha_Compra = value; }
        public decimal Compro_Costo { get => _Compro_Costo; set => _Compro_Costo = value; }
        public string TipoCasa { get => _TipoCasa; set => _TipoCasa = value; }
        public bool Disponible { get => _Disponible; set => _Disponible = value; }
    }
}
