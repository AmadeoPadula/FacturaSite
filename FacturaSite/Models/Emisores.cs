using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaSite.Models
{
    public class Emisores
    {
        public Emisores()
        {
            Personas = new Personas();
            DomiciliosFiscal = new Domicilios();
            DomiciliosExpedicion = new Domicilios();
            RegimenesFiscales =  new List<RegimenesFiscales>();
        }

        public int EmisorId { get; set; }
        public Personas Personas { get; set; }
        public Domicilios DomiciliosFiscal { get; set; }
        public Domicilios DomiciliosExpedicion { get; set; }
        public List<RegimenesFiscales> RegimenesFiscales { get; set; }
        public DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
    }
}
