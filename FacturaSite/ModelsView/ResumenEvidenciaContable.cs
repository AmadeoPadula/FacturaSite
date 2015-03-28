using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaSite.ModelsView
{
    public class ResumenEvidenciaContable
    {
        public int? OperacionId { get; set; }
        public string TipoTransaccion { get; set; }
        public decimal Total { get; set; }
    }
}