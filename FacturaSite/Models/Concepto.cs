using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaSite.Models
{
    public class Concepto
    {
        public int ConceptoId { get; set; }
        public int ComprobanteId { get; set; }
        public string NoIdentificacion { get; set; }
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Importe { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<System.DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
    }
}
