using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaSite.Models
{
    public class Comprobantes
    {

        public Comprobantes()
        {
           this.Conceptos = new List<Conceptos>();
           this.ComprobantesImpuestos = new List<ComprobanteImpuesto>();
        }

        public int ComprobanteId { get; set; }
        public Emisores Emisores { get; set; }
        public Receptores Receptores { get; set; }
        public TimbresFiscalesDigitales TimbresFiscalesDigitales { get; set; }
        public Nullable<decimal> TotalImpuestosRetenidos { get; set; }
        public Nullable<decimal> TotalImpuestosTrasladados { get; set; }
        public string Certificado { get; set; }
        public string CondicionesPago { get; set; }
        public decimal Descuento { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<System.DateTime> FechaFolioFiscalOrig { get; set; }
        public string Folio { get; set; }
        public string FormaPago { get; set; }
        public string LugarExpedicion { get; set; }
        public string MetodoPago { get; set; }
        public string Moneda { get; set; }
        public Nullable<decimal> MontoFolioFiscalOrig { get; set; }
        public string MotivoDescuento { get; set; }
        public string NoCertificado { get; set; }
        public string NumCtaPago { get; set; }
        public string Sello { get; set; }
        public string Serie { get; set; }
        public string SerieFolioFiscalOrig { get; set; }
        public decimal SubTotal { get; set; }
        public string TipoCambio { get; set; }
        public string TipoComprobante { get; set; }
        public decimal Total { get; set; }
        public string Version { get; set; }

        public int BitacoraCargaIdXML { get; set; }
        public Nullable<int> BitacoraCargaIdPDF { get; set; }

        public Boolean Activo { get; set; }
        public DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
        public string FolioFiscalOrig { get; set; }
        public List<Models.Conceptos> Conceptos { get; set; }
        public List<Models.ComprobanteImpuesto> ComprobantesImpuestos { get; set; }

        public BitacoraCargas BitacoraCargasPdf { get; set; }
        public BitacoraCargas BitacoraCargasXml { get; set; }
    }
}
