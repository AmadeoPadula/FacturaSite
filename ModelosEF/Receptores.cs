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
    
    public partial class Receptores
    {
        public Receptores()
        {
            this.Comprobantes = new HashSet<Comprobantes>();
        }
    
        public int ReceptorId { get; set; }
        public int PersonaId { get; set; }
        public int DomicilioId { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<System.DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
    
        public virtual ICollection<Comprobantes> Comprobantes { get; set; }
        public virtual Domicilios Domicilios { get; set; }
        public virtual Personas Personas { get; set; }
    }
}
