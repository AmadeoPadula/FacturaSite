using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaSite.Models
{
    public class Bancos
    {
        public int BancoId { get; set; }
        public string Identificador { get; set; }
        public string Banco { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public int UsuarioAltaId { get; set; }
        public Nullable<System.DateTime> FechaCambio { get; set; }
        public Nullable<int> UsuarioCambioId { get; set; }
    }
}