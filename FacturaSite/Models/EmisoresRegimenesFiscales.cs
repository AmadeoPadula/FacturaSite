using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaSite.Models
{
    public class EmisoresRegimenesFiscales
    {
        public int EmisorId { get; set; }
        public int RegimenFiscalId { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<System.DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
    }
}
