using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaSite.Models
{
    public class Evidencias
    {
        public int EvidenciaId { get; set; }
        //public int EmpresaId { get; set; }
        //public Nullable<int> BancoId { get; set; }
        //public int TipoTransaccionId { get; set; }
        public string NumeroTransferencia { get; set; }
        public System.DateTime FechaPago { get; set; }
        public decimal MontoPago { get; set; }
        //public string NoFacturaPagada { get; set; }
        public string ClaveEvidencia { get; set; }
        public int BitacoraCargaId { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<System.DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }

        //public Nullable<Int32> ComprobanteId { get; set; }
        
        public Empresas Empresa { get; set; }
        public TiposTransacciones TipoTransaccion { get; set; }
        public Bancos Banco { get; set; }

        public Comprobantes Comprobante { get; set; }

    }
}