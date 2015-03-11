using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using AdsertiVS2013ClassLibrary;
using FacturaSite.BusinessLogic;

namespace FacturaSite.Models
{
    public static class Utilidades
    {
        
        public static Comprobantes IdentificaEmisorYDocumento(string path)
        {
            XDocument xdoc = XDocument.Load(path);
            XNamespace nsCfdi = XNamespace.Get("http://www.sat.gob.mx/cfd/3");
            XNamespace nsTfd = XNamespace.Get("http://www.sat.gob.mx/TimbreFiscalDigital");

            var emisorPersona = (from domFiscal in xdoc.Descendants(nsCfdi + "Emisor")
                select new Models.Personas
                {
                    Rfc = AdsertiFunciones.FormatearTexto(domFiscal.Attribute("rfc").Value),
                    Nombre = AdsertiFunciones.FormatearTexto(domFiscal.Attribute("nombre").Value),
                }).ToList<Models.Personas>().FirstOrDefault();

            Emisores emisores = new Emisores();
            emisores.Personas = emisorPersona;


            //COMPROBANTE------------------------------
            var comprobante = (from comp in xdoc.Descendants(nsCfdi + "Comprobante")
                               select new Models.Comprobantes
                               {
                                   Folio = (comp.Attribute("folio") == null) ? string.Empty : comp.Attribute("folio").Value,
                                   Serie = (comp.Attribute("serie") == null) ? string.Empty : comp.Attribute("serie").Value,
                               }).ToList<Models.Comprobantes>().FirstOrDefault();

            comprobante.Emisores = emisores;

            return comprobante;
        } // public static Comprobantes IdentificaEmisorYDocumento(string path)


        public static void ParseXmlToFactura(string path, Int32 bitacoraCargaIdXml)
        {
            int usuarioAltaId = 1;

            XDocument xdoc = XDocument.Load(path);
            XNamespace nsCfdi = XNamespace.Get("http://www.sat.gob.mx/cfd/3");
            XNamespace nsTfd = XNamespace.Get("http://www.sat.gob.mx/TimbreFiscalDigital");

            //EMISOR
            var domicilioFiscal = (from domFiscal in xdoc.Root.Descendants(nsCfdi + "Emisor").Descendants(nsCfdi + "DomicilioFiscal")
                select new Models.Domicilios
                {
                    Calle = AdsertiFunciones.FormatearTexto(domFiscal.Attribute("calle").Value),
                    CodigoPostal = domFiscal.Attribute("codigoPostal").Value,
                    Colonia = (domFiscal.Attribute("colonia") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(domFiscal.Attribute("colonia").Value),
                    Estado = AdsertiFunciones.FormatearTexto(domFiscal.Attribute("estado").Value),
                    Localidad = (domFiscal.Attribute("localidad") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(domFiscal.Attribute("localidad").Value),
                    Municipio = AdsertiFunciones.FormatearTexto(domFiscal.Attribute("municipio").Value),
                    NoExterior = (domFiscal.Attribute("noExterior") == null) ? string.Empty : domFiscal.Attribute("noExterior").Value,
                    NoInterior = (domFiscal.Attribute("noInterior") == null) ? string.Empty : domFiscal.Attribute("noInterior").Value,
                    Pais = AdsertiFunciones.FormatearTexto(domFiscal.Attribute("pais").Value),
                    Referencia = (domFiscal.Attribute("referencia") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(domFiscal.Attribute("referencia").Value),
                    UsuarioAltaId = usuarioAltaId
                }).ToList<Models.Domicilios>().FirstOrDefault();


            var domicilioExpedicion = (from domFiscal in xdoc.Root.Descendants(nsCfdi + "Emisor").Descendants(nsCfdi + "ExpedidoEn")
                select new Models.Domicilios
                {
                    Calle = (domFiscal.Attribute("calle") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(domFiscal.Attribute("calle").Value),
                    CodigoPostal = (domFiscal.Attribute("codigoPostal") == null) ? string.Empty : domFiscal.Attribute("codigoPostal").Value,
                    Colonia = (domFiscal.Attribute("colonia") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(domFiscal.Attribute("colonia").Value),
                    Estado = (domFiscal.Attribute("estado") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(domFiscal.Attribute("estado").Value),
                    Localidad = (domFiscal.Attribute("localidad") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(domFiscal.Attribute("localidad").Value),
                    Municipio = (domFiscal.Attribute("municipio") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(domFiscal.Attribute("municipio").Value),
                    NoExterior = (domFiscal.Attribute("noExterior") == null) ? string.Empty : domFiscal.Attribute("noExterior").Value,
                    NoInterior = (domFiscal.Attribute("noInterior") == null) ? string.Empty : domFiscal.Attribute("noInterior").Value,
                    Pais = AdsertiFunciones.FormatearTexto(domFiscal.Attribute("pais").Value),
                    Referencia = (domFiscal.Attribute("referencia") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(domFiscal.Attribute("referencia").Value),
                    UsuarioAltaId = usuarioAltaId
                }).ToList<Models.Domicilios>().FirstOrDefault();


            var emisorPersona = (from domFiscal in xdoc.Descendants(nsCfdi + "Emisor")
                select new Models.Personas
                {
                    Rfc = AdsertiFunciones.FormatearTexto(domFiscal.Attribute("rfc").Value),
                    Nombre = AdsertiFunciones.FormatearTexto(domFiscal.Attribute("nombre").Value),
                    UsuarioAltaId = usuarioAltaId
                }).ToList<Models.Personas>().FirstOrDefault();

            //REGIMENES FISCALES
            var regimenesFiscalesEmisor = (from regFis in xdoc.Descendants(nsCfdi + "RegimenFiscal")
                select new Models.RegimenesFiscales()
                {
                    RegimenFiscal = AdsertiFunciones.FormatearTexto(regFis.Attribute("Regimen").Value),
                    UsuarioAltaId = usuarioAltaId
                }).ToList<Models.RegimenesFiscales>();

            Models.Emisores emisores = new Models.Emisores();
            emisores.DomiciliosFiscal = domicilioFiscal;
            emisores.DomiciliosExpedicion = domicilioExpedicion;
            emisores.Personas = emisorPersona;

            //TODO: Revisar la estructura de los XML para saber como se reciben multiples Regimenes
            emisores.RegimenesFiscales = regimenesFiscalesEmisor;

            emisores.UsuarioAltaId = usuarioAltaId;

            //RECEPTOR
            var domicilioReceptor = (from domFiscal in xdoc.Descendants(nsCfdi + "Receptor").Descendants(nsCfdi + "Domicilio")
                select new Models.Domicilios
                {
                    Calle = (domFiscal.Attribute("calle") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(domFiscal.Attribute("calle").Value),
                    CodigoPostal = (domFiscal.Attribute("codigoPostal") == null) ? string.Empty : domFiscal.Attribute("codigoPostal").Value,
                    Colonia = (domFiscal.Attribute("colonia") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(domFiscal.Attribute("colonia").Value),
                    Estado = (domFiscal.Attribute("estado") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(domFiscal.Attribute("estado").Value),
                    Localidad = (domFiscal.Attribute("localidad") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(domFiscal.Attribute("localidad").Value),
                    Municipio = (domFiscal.Attribute("municipio") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(domFiscal.Attribute("municipio").Value),
                    NoExterior = (domFiscal.Attribute("noExterior") == null) ? string.Empty : domFiscal.Attribute("noExterior").Value,
                    NoInterior = (domFiscal.Attribute("noInterior") == null) ? string.Empty : domFiscal.Attribute("noInterior").Value,
                    Pais = AdsertiFunciones.FormatearTexto(domFiscal.Attribute("pais").Value),
                    Referencia = (domFiscal.Attribute("referencia") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(domFiscal.Attribute("referencia").Value),
                    UsuarioAltaId = usuarioAltaId
                }).ToList<Models.Domicilios>().FirstOrDefault();

            var receptorPersona = (from domFiscal in xdoc.Descendants(nsCfdi + "Receptor")
                select new Models.Personas
                {
                    Rfc = AdsertiFunciones.FormatearTexto(domFiscal.Attribute("rfc").Value),
                    Nombre = AdsertiFunciones.FormatearTexto(domFiscal.Attribute("nombre").Value),
                    UsuarioAltaId = usuarioAltaId
                }).ToList<Models.Personas>().FirstOrDefault();

            Receptores receptores = new Receptores();
            receptores.Personas = receptorPersona;
            receptores.Domicilios = domicilioReceptor;
            receptores.UsuarioAltaId = usuarioAltaId;

            //COMPROBANTE------------------------------
            var comprobante = (from comp in xdoc.Descendants(nsCfdi + "Comprobante")
                select new Models.Comprobantes
                {
                    FechaFolioFiscalOrig = (comp.Attribute("FechaFolioFiscalOrig") == null) ? (DateTime?) null : DateTime.Parse(comp.Attribute("FechaFolioFiscalOrig").Value),
                    FolioFiscalOrig = (comp.Attribute("FolioFiscalOrig") == null) ? string.Empty : comp.Attribute("FolioFiscalOrig").Value,
                    LugarExpedicion = AdsertiFunciones.FormatearTexto(comp.Attribute("LugarExpedicion").Value),
                    Moneda = (comp.Attribute("Moneda") == null) ? string.Empty : comp.Attribute("Moneda").Value,
                    MontoFolioFiscalOrig = (comp.Attribute("MontoFolioFiscalOrig") == null) ? 0M : Convert.ToDecimal(comp.Attribute("MontoFolioFiscalOrig").Value),
                    NumCtaPago = (comp.Attribute("NumCtaPago") == null) ? string.Empty : comp.Attribute("NumCtaPago").Value,
                    SerieFolioFiscalOrig = (comp.Attribute("SerieFolioFiscalOrig") == null) ? string.Empty : comp.Attribute("SerieFolioFiscalOrig").Value,
                    TipoCambio = (comp.Attribute("TipoCambio") == null) ? string.Empty : comp.Attribute("TipoCambio").Value,
                    Certificado = comp.Attribute("certificado").Value,
                    CondicionesPago = (comp.Attribute("condicionesDePago") == null) ? string.Empty : comp.Attribute("condicionesDePago").Value,
                    Descuento = (comp.Attribute("descuento") == null) ? 0M : Convert.ToDecimal(comp.Attribute("descuento").Value),
                    Fecha = DateTime.Parse(comp.Attribute("fecha").Value),
                    Folio = (comp.Attribute("folio") == null) ? string.Empty : comp.Attribute("folio").Value,
                    FormaPago = AdsertiFunciones.FormatearTexto(comp.Attribute("formaDePago").Value),
                    MetodoPago = AdsertiFunciones.FormatearTexto(comp.Attribute("metodoDePago").Value),
                    MotivoDescuento = (comp.Attribute("motivoDescuento") == null) ? string.Empty : AdsertiFunciones.FormatearTexto(comp.Attribute("motivoDescuento").Value),
                    NoCertificado = comp.Attribute("noCertificado").Value,
                    Sello = comp.Attribute("sello").Value,
                    Serie = (comp.Attribute("serie") == null) ? string.Empty : comp.Attribute("serie").Value,
                    SubTotal = Convert.ToDecimal(comp.Attribute("subTotal").Value),
                    TipoComprobante = comp.Attribute("tipoDeComprobante").Value,
                    Total = Convert.ToDecimal(comp.Attribute("total").Value),
                    Version = comp.Attribute("version").Value,
                    UsuarioAltaId = usuarioAltaId
                }).ToList<Models.Comprobantes>().FirstOrDefault();

            //IMPUESTOS SUMA
            var impuestosSuma = (from impuesto in xdoc.Descendants(nsCfdi + "Impuestos")
                select new
                {
                    TotalImpuestosRetenidos = (impuesto.Attribute("totalImpuestosRetenidos") == null) ? 0M : Convert.ToDecimal(impuesto.Attribute("totalImpuestosRetenidos").Value),
                    TotalImpuestosTrasladados = (impuesto.Attribute("totalImpuestosTrasladados") == null) ? 0M : Convert.ToDecimal(impuesto.Attribute("totalImpuestosTrasladados").Value)
                }).ToList().FirstOrDefault();

            comprobante.TotalImpuestosRetenidos = impuestosSuma.TotalImpuestosRetenidos;
            comprobante.TotalImpuestosTrasladados = impuestosSuma.TotalImpuestosTrasladados;

            comprobante.Emisores = emisores;
            comprobante.Receptores = receptores;

            comprobante.BitacoraCargaIdXML = bitacoraCargaIdXml;

            //CONCEPTOS
            var conceptos = (from concepto in xdoc.Descendants(nsCfdi + "Concepto")
                select new Models.Conceptos
                {
                    Cantidad = Convert.ToDecimal(concepto.Attribute("cantidad").Value),
                    Descripcion = AdsertiFunciones.FormatearTexto(concepto.Attribute("descripcion").Value),
                    Importe = Convert.ToDecimal(concepto.Attribute("importe").Value),
                    NoIdentificacion = (concepto.Attribute("noIdentificacion") == null) ? string.Empty : concepto.Attribute("noIdentificacion").Value,
                    Unidad = AdsertiFunciones.FormatearTexto(concepto.Attribute("unidad").Value),
                    ValorUnitario = Convert.ToDecimal(concepto.Attribute("valorUnitario").Value),
                    UsuarioAltaId = usuarioAltaId
                }).ToList<Models.Conceptos>();

            comprobante.Conceptos = conceptos;

            //IMPUESTOS TRASLADADOS
            if (xdoc.Descendants(nsCfdi + "Traslados") != null)
            {
                var comprobantesImpuestosTrasladados = (from comprobanteImpuesto in xdoc.Descendants(nsCfdi + "Traslado")
                    select new Models.ComprobanteImpuesto
                    {
                        TipoImpuesto = Models.ComprobanteImpuesto.TiposImpuesto.Traslado,
                        Importe = Convert.ToDecimal(comprobanteImpuesto.Attribute("importe").Value),
                        Impuesto = AdsertiFunciones.FormatearTexto(comprobanteImpuesto.Attribute("impuesto").Value),
                        Tasa = Convert.ToDecimal(comprobanteImpuesto.Attribute("tasa").Value),
                        UsuarioAltaId = usuarioAltaId
                    }).ToList<Models.ComprobanteImpuesto>();

                //Agregar al comprobante
                foreach (Models.ComprobanteImpuesto item in comprobantesImpuestosTrasladados)
                {
                    comprobante.ComprobantesImpuestos.Add(item);
                }
            }

            //IMPUESTOS RETENIDOS
            if (xdoc.Descendants(nsCfdi + "Retenciones") != null)
            {
                var comprobantesImpuestosRetenidos = (from comprobanteImpuesto in xdoc.Descendants(nsCfdi + "Retenciones")
                    select new Models.ComprobanteImpuesto
                    {
                        TipoImpuesto = Models.ComprobanteImpuesto.TiposImpuesto.Retencion,
                        Importe = Convert.ToDecimal(comprobanteImpuesto.Attribute("importe").Value),
                        Impuesto = AdsertiFunciones.FormatearTexto(comprobanteImpuesto.Attribute("impuesto").Value),
                        Tasa = Convert.ToDecimal(comprobanteImpuesto.Attribute("tasa").Value),
                        UsuarioAltaId = usuarioAltaId
                    }).ToList<Models.ComprobanteImpuesto>();

                //Agregar al comprobante
                foreach (Models.ComprobanteImpuesto item in comprobantesImpuestosRetenidos)
                {
                    comprobante.ComprobantesImpuestos.Add(item);
                }
            }

            //TIMBRES FISCALES
            var timbreFiscalDigital = (from timbreFiscalDigitalItem in xdoc.Descendants(nsCfdi + "Complemento").Descendants(nsTfd + "TimbreFiscalDigital")
                select new TimbresFiscalesDigitales
                {
                    FechaTimbrado = Convert.ToDateTime(timbreFiscalDigitalItem.Attribute("FechaTimbrado").Value),
                    NoCertificadoSAT = timbreFiscalDigitalItem.Attribute("noCertificadoSAT").Value,
                    SelloCFD = timbreFiscalDigitalItem.Attribute("selloCFD").Value,
                    SelloSAT = timbreFiscalDigitalItem.Attribute("selloSAT").Value,
                    UUID = timbreFiscalDigitalItem.Attribute("UUID").Value,
                    Version = timbreFiscalDigitalItem.Attribute("version").Value,
                    UsuarioAltaId = usuarioAltaId
                }).ToList<TimbresFiscalesDigitales>().FirstOrDefault();

            comprobante.TimbresFiscalesDigitales = timbreFiscalDigital;

            BusinessLogic.ComprobantesBusiness comprobantesBusinessLogic = new ComprobantesBusiness();
            comprobantesBusinessLogic.Agregar(comprobante);

        } // public static void ParseXmlToFactura(string path)

    } // public static class Utilidades

} // namespace FacturaSite.Models