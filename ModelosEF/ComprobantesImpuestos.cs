//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelosEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ComprobantesImpuestos
    {
        public int ComprobanteImpuestoId { get; set; }
        public int ComprobanteId { get; set; }
        public int TipoImpuestoId { get; set; }
        public decimal Importe { get; set; }
        public string Impuesto { get; set; }
        public decimal Tasa { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<System.DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
    
        public virtual Comprobantes Comprobantes { get; set; }
        public virtual TiposImpuesto TiposImpuesto { get; set; }
    }
}