using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaSite.Models
{
    public class RegimenFiscal
    {
        public int RegimenFiscalId { get; set; }
        public string RegimenFiscalDescripcion { get; set; }
        public DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
    }
}
