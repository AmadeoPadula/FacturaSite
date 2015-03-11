using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaSite.Models
{
    public class Emisor
    {
        public Emisor()
        {
            Persona = new Persona();
            DomicilioFiscal = new Domicilio();
            DomicilioExpedicion = new Domicilio();
            RegimenesFiscales =  new List<RegimenFiscal>();
        }

        public int EmisorId { get; set; }
        public Persona Persona { get; set; }
        public Domicilio DomicilioFiscal { get; set; }
        public Domicilio DomicilioExpedicion { get; set; }
        public List<RegimenFiscal> RegimenesFiscales { get; set; }
        public DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
    }
}
