using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaSite.Models
{
     public class Domicilios
    {
        public int DomicilioId { get; set; }
        public string Calle { get; set; }
        public string CodigoPostal { get; set; }
        public string Colonia { get; set; }
        public string Estado { get; set; }
        public string Localidad { get; set; }
        public string Municipio { get; set; }
        public string NoExterior { get; set; }
        public string NoInterior { get; set; }
        public string Pais { get; set; }
        public string Referencia { get; set; }
        public DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<System.DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
    }
}
