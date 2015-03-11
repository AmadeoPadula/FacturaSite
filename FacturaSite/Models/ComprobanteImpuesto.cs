using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaSite.Models
{
    public class ComprobanteImpuesto
    {

        public enum TiposImpuesto
        {
            Retencion = 1,
            Traslado
        }

        public int ComprobanteImpuestoId { get; set; }
        public int ComprobanteId { get; set; }
        public TiposImpuesto TipoImpuesto { get; set; }
        public Nullable<decimal> Importe { get; set; }
        public string Impuesto { get; set; }
        public Nullable<decimal> Tasa { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<System.DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
    }
}
