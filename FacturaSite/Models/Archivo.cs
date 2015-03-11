using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaSite.Models
{
    public class Archivo
    {
        public string NombreArchivo { get; set; }
        public Boolean Correcto { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
    }
}