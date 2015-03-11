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
    
    public partial class Domicilios
    {
        public Domicilios()
        {
            this.Emisores = new HashSet<Emisores>();
            this.Emisores1 = new HashSet<Emisores>();
            this.Receptores = new HashSet<Receptores>();
        }
    
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
        public System.DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<System.DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
    
        public virtual ICollection<Emisores> Emisores { get; set; }
        public virtual ICollection<Emisores> Emisores1 { get; set; }
        public virtual ICollection<Receptores> Receptores { get; set; }
    }
}
