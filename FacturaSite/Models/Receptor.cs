using System;

namespace FacturaSite.Models
{
    public class Receptor
    {
        public Receptor()
        {
            Persona = new Persona();
            Domicilio = new Domicilio();
        }

        public int ReceptorId { get; set; }
        public Persona Persona { get; set; }
        public Domicilio Domicilio { get; set; }
        public DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
    }
}
