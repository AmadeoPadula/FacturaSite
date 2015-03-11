using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaSite.Models
{
    public class BitacoraCarga
    {
        public enum ExtensionArchivo
        {
            Pdf = 1,
            Xml
        }

        public int BitacoraCargaId { get; set; }
        public string NombreArchivo { get; set; }
        public string Extension { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
    }
}