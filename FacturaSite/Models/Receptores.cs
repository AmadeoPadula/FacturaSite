using System;

namespace FacturaSite.Models
{
    public class Receptores
    {
        public Receptores()
        {
            Personas = new Personas();
            Domicilios = new Domicilios();
        }

        public int ReceptorId { get; set; }
        public Personas Personas { get; set; }
        public Domicilios Domicilios { get; set; }
        public DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
    }
}
