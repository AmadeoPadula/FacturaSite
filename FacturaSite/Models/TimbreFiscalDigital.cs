using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaSite.Models
{
    public class TimbreFiscalDigital
    {
        public int TimbreFiscalDigitalId { get; set; }
        public int ComprobanteId { get; set; }
        public Nullable<System.DateTime> FechaTimbrado { get; set; }
        public string NoCertificadoSAT { get; set; }
        public string SelloCFD { get; set; }
        public string SelloSAT { get; set; }
        public string UUID { get; set; }
        public string Version { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<System.DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
    }
}
