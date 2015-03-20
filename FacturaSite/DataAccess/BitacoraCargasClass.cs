using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AdsertiVS2013ClassLibrary;
using FacturaSite.Models;

namespace FacturaSite.DataAccess
{
    public class BitacoraCargasClass
    {
        #region * Constructor generado por Adserti *

        #endregion

        #region * Enumeraciones declaradas por Adserti *

        #endregion

        #region * Variables declaradas por Adserti *

        //private static String CadenaDeConexion = AdsertiFunciones.DesencriptarTexto(ConfigurationManager.ConnectionStrings["ControlFacturacionConnectionString"].ConnectionString);
        private static String CadenaDeConexion = ConfigurationManager.ConnectionStrings["ControlFacturacionConnectionString"].ConnectionString;

        #endregion

        #region * Propiedades declaradas por Adserti *

        #endregion

        #region * Eventos generados por Adserti *

        #endregion

        #region * Métodos creados por Adserti *

        /// <summary>
        /// Agregar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Febrero 13 de 2015 </para>
        /// <para> Fecha de última modificación: Febrero 13 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Agregar(Models.BitacoraCargas bitacoraCargas, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;


            // Valida parámetros
            if (String.IsNullOrEmpty(bitacoraCargas.NombreArchivo))
                throw new ArgumentNullException("NombreArchivo");
            if (bitacoraCargas.UsuarioAltaId == 0)
                throw new ArgumentNullException("UsuarioAltaId");

            try
            {
                //Configura la sentencia por ejecutar
                sentenciaSql = "INSERT INTO [dbo].[BitacoraCargas] ( ";
                sentenciaSql += "	[NombreArchivo] ";
                sentenciaSql += "	,[Extension] ";
                sentenciaSql += "	,[UsuarioAltaId] ";
                sentenciaSql += "	) ";
                sentenciaSql += "VALUES ( ";
                sentenciaSql += "	@NombreArchivo ";
                sentenciaSql += "	,@Extension ";
                sentenciaSql += "	,@UsuarioAltaId ";
                sentenciaSql += "	); ";


                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@NombreArchivo", bitacoraCargas.NombreArchivo),
                    new SqlParameter("@Extension", bitacoraCargas.Extension),
                    new SqlParameter("@UsuarioAltaId", bitacoraCargas.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";
                bitacoraCargas.BitacoraCargaId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));

                return Convert.ToInt32(bitacoraCargas.BitacoraCargaId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Agregar(Models.Personas Personas, AdsertiSqlDataAccess adsertiDataAccess)

        /// <summary>
        /// Cargar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Febrero 16 de 2015 </para>
        /// <para> Fecha de última modificación: Febrero 16 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public BitacoraCargas Cargar(string nombreArchivo, BitacoraCargas.ExtensionArchivo extensionArchivo, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable bitacoraCargaDataTable;
            SqlParameter[] listaParametros;
            Models.BitacoraCargas bitacoraCargas = null;

            // Valida que los parámetros enviados sean correctos
            if (String.IsNullOrEmpty(nombreArchivo))
                throw new ArgumentNullException("nombreArchivo");
            try
            {
                sentenciaSql = "SELECT TOP 1";
                sentenciaSql += "	[BitacoraCargaId], ";
                sentenciaSql += "	[NombreArchivo], ";
                sentenciaSql += "	[Extension], ";
                sentenciaSql += "	[Activo], ";
                sentenciaSql += "    FORMAT([FechaAlta],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaAlta, ";
                sentenciaSql += "	[UsuarioAltaId], ";
                sentenciaSql += "    FORMAT([FechaCambio],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaCambio, ";
                sentenciaSql += "	[UsuarioCambioId] ";
                sentenciaSql += "FROM ";
                sentenciaSql += "	[dbo].[BitacoraCargas] ";
                sentenciaSql += "WHERE ";
                sentenciaSql += "	NombreArchivo = @NombreArchivo ";
                sentenciaSql += "	AND Extension = @Extension ";
                sentenciaSql += "	AND Activo = 1 ";
                sentenciaSql += "ORDER BY FechaAlta DESC ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@NombreArchivo", nombreArchivo),
                    new SqlParameter("@Extension", (extensionArchivo == BitacoraCargas.ExtensionArchivo.Pdf) ? ".pdf" : ".xml")
                };

                var bitacoraCargaIdDevuelto = adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros);
                if (bitacoraCargaIdDevuelto != null)
                {
                    Int32 bitacoraCargaId = Convert.ToInt32(bitacoraCargaIdDevuelto);
                    return this.Cargar(bitacoraCargaId, adsertiDataAccess);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        }

        /// <summary>
        /// Cargar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Febrero 16 de 2015 </para>
        /// <para> Fecha de última modificación: Febrero 16 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public BitacoraCargas Cargar(Int32 bitacoraId, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable bitacoraCargaDataTable;
            SqlParameter[] listaParametros;
            BitacoraCargas bitacoraCargas = null;

            if (bitacoraId == 0)
                throw new ArgumentNullException("bitacoraId");
            try
            {

                sentenciaSql = "SELECT ";
                sentenciaSql += "	[BitacoraCargaId], ";
                sentenciaSql += "	[NombreArchivo], ";
                sentenciaSql += "	[Extension], ";
                sentenciaSql += "	[Activo], ";
                sentenciaSql += "    FORMAT([FechaAlta],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaAlta, ";
                sentenciaSql += "	[UsuarioAltaId], ";
                sentenciaSql += "    FORMAT([FechaCambio],'" + AdsertiValidaciones.FormatoFechaHora + "') AS FechaCambio, ";
                sentenciaSql += "	[UsuarioCambioId] ";
                sentenciaSql += "FROM ";
                sentenciaSql += "	[dbo].[BitacoraCargas] ";
                sentenciaSql += "WHERE ";
                sentenciaSql += "	BitacoraCargaId = @BitacoraCargaId ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@BitacoraCargaId", bitacoraId)
                };

                bitacoraCargaDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.Text, sentenciaSql, listaParametros);

                if (bitacoraCargaDataTable.Rows.Count > 0)
                {
                    bitacoraCargas = new BitacoraCargas();

                    bitacoraCargas.BitacoraCargaId = Convert.ToInt32(bitacoraCargaDataTable.Rows[0]["BitacoraCargaId"]);
                    bitacoraCargas.NombreArchivo = (bitacoraCargaDataTable.Rows[0]["NombreArchivo"]).ToString();
                    bitacoraCargas.Extension = (bitacoraCargaDataTable.Rows[0]["Extension"]).ToString();
                    bitacoraCargas.Activo = Convert.ToBoolean(bitacoraCargaDataTable.Rows[0]["Activo"]);
                    bitacoraCargas.FechaAlta = Convert.ToDateTime((bitacoraCargaDataTable.Rows[0]["FechaAlta"]));
                    bitacoraCargas.UsuarioAltaId = Convert.ToInt32((bitacoraCargaDataTable.Rows[0]["UsuarioAltaId"]));

                    if (bitacoraCargaDataTable.Rows[0]["FechaCambio"] == DBNull.Value)
                    {
                        bitacoraCargas.FechaCambio = null;
                    }
                    else
                    {
                        bitacoraCargas.FechaCambio = Convert.ToDateTime(bitacoraCargaDataTable.Rows[0]["FechaCambio"]);
                    }

                    if (bitacoraCargaDataTable.Rows[0]["UsuarioCambioId"] == DBNull.Value)
                    {
                        bitacoraCargas.UsuarioCambioId = null;
                    }
                    else
                    {
                        bitacoraCargas.UsuarioCambioId = Convert.ToInt32(bitacoraCargaDataTable.Rows[0]["UsuarioCambioId"]);
                    }

                } // if (bitacoraCargaDataTable.Rows.Count > 0)

                return bitacoraCargas;
            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        }

        /// <summary>
        /// PDFSinFactura()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Marzo 03 de 2015 </para>
        /// <para> Fecha de última modificación: Marzo 03 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public BitacoraCargas PDFSinFactura(String nombreArchivo, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql = String.Empty;
            DataTable bitacoraCargaDataTable;
            SqlParameter[] listaParametros;
            Models.BitacoraCargas bitacoraCargas = null;

            // Valida que los parámetros enviados sean correctos
            if (String.IsNullOrEmpty(nombreArchivo))
                throw new ArgumentNullException("nombreArchivo");
            try
            {
                sentenciaSql = "SELECT TOP 1 ";
                sentenciaSql += "	[BitacoraCargas].[BitacoraCargaId] ";
                sentenciaSql += "FROM ";
                sentenciaSql += "	[dbo].[BitacoraCargas] LEFT JOIN [dbo].[Comprobantes] ";
                sentenciaSql += "		ON  ";
                sentenciaSql += "			Comprobantes.BitacoraCargaIdPDF = BitacoraCargas.BitacoraCargaId ";
                sentenciaSql += "WHERE ";
                sentenciaSql += "	BitacoraCargas.Extension = '.pdf' ";
                sentenciaSql += "	AND BitacoraCargas.Activo = 1 ";
                sentenciaSql += "	AND NombreArchivo = @NombreArchivo ";
                sentenciaSql += "	AND Comprobantes.BitacoraCargaIdPDF IS NULL ";
                sentenciaSql += "ORDER BY BitacoraCargas.FechaAlta DESC ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@NombreArchivo", nombreArchivo)
                };

                var bitacoraCargaIdDevuelto = adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros);

                if (bitacoraCargaIdDevuelto != null & bitacoraCargaIdDevuelto != DBNull.Value)
                {
                    Int32 bitacoraCargaId = Convert.ToInt32(bitacoraCargaIdDevuelto);
                    return this.Cargar(bitacoraCargaId, adsertiDataAccess);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        }

        /// <summary>
        /// Eliminar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Marzo 03 de 2015 </para>
        /// <para> Fecha de última modificación: Marzo 03 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Eliminar(Models.BitacoraCargas bitacoraCargas, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;


            // Valida parámetros
            if (bitacoraCargas.BitacoraCargaId == 0)
                throw new ArgumentNullException("BitacoraCargaId");
            if (bitacoraCargas.UsuarioCambioId == 0)
                throw new ArgumentNullException("UsuarioCambioId");

            try
            {
                //Configura la sentencia por ejecutar
                sentenciaSql = "UPDATE  ";
                sentenciaSql += "	[dbo].[BitacoraCargas]  ";
                sentenciaSql += "SET  ";
                sentenciaSql += "	FechaCambio = getdate(), ";
                sentenciaSql += "	UsuarioCambioId = @UsuarioCambioId, ";
                sentenciaSql += "	Activo =  0  ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	BitacoraCargaId = @BitacoraCargaId ";


                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@BitacoraCargaId", bitacoraCargas.BitacoraCargaId),
                    new SqlParameter("@UsuarioCambioId", bitacoraCargas.UsuarioCambioId)
                };

                return Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Agregar(Models.Personas Personas, AdsertiSqlDataAccess adsertiDataAccess)

        /// <summary>
        /// CargasSinClasificar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Marzo 03 de 2015 </para>
        /// <para> Fecha de última modificación: Marzo 03 de 2015 </para>
        /// <para> Personas de última modificación: Arturo Hernandez</para>
        /// </summary>

        public List<BitacoraCargas> CargasSinClasificar(AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            DataTable cargasSinClasificarDataTable;

            try
            {
                sentenciaSql = "SELECT  ";
                sentenciaSql += "	BitacoraCargaId, ";
                sentenciaSql += "	NombreArchivo, ";
                sentenciaSql += "	Extension, ";
                sentenciaSql += "	Activo, ";
                sentenciaSql += "	FechaAlta, ";
                sentenciaSql += "	UsuarioAltaId, ";
                sentenciaSql += "	FechaCambio, ";
                sentenciaSql += "	UsuarioCambioId ";
                sentenciaSql += "FROM  ";
                sentenciaSql += "	[dbo].[BitacoraCargas]  ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	BitacoraCargaId NOT IN( ";
                sentenciaSql += "		SELECT 	BitacoraCargaIdXML BitacoraCargaIdAsignado FROM [dbo].[Comprobantes] WHERE Activo = 1 AND BitacoraCargaIdXML IS NOT NULL ";
                sentenciaSql += "		UNION ALL  ";
                sentenciaSql += "		SELECT 	BitacoraCargaIdPDF FROM [dbo].[Comprobantes] WHERE Activo = 1 AND BitacoraCargaIdPDF IS NOT NULL ";
                sentenciaSql += "		UNION ALL  ";
                sentenciaSql += "		SELECT 	BitacoraCargaId FROM [dbo].[Evidencias] WHERE Activo = 1 AND BitacoraCargaId IS NOT NULL) ";
                sentenciaSql += "	AND	Activo = 1 ";

                cargasSinClasificarDataTable = adsertiDataAccess.ObtenerDataTable(CommandType.Text, sentenciaSql, null);

                if (cargasSinClasificarDataTable.Rows.Count > 0)
                {
                    List<BitacoraCargas> cargasSinClasificar = new List<BitacoraCargas>();


                    foreach (DataRow cargaBitacoraRow in cargasSinClasificarDataTable.Rows)
                    {
                        BitacoraCargas bitacoraCargas = new BitacoraCargas();

                        bitacoraCargas.BitacoraCargaId = Convert.ToInt32(cargaBitacoraRow["BitacoraCargaId"]);
                        bitacoraCargas.NombreArchivo = cargaBitacoraRow["NombreArchivo"].ToString();
                        bitacoraCargas.Extension = cargaBitacoraRow["Extension"].ToString();
                        bitacoraCargas.Activo = Convert.ToBoolean(cargaBitacoraRow["Activo"]);
                        bitacoraCargas.FechaAlta = Convert.ToDateTime((cargaBitacoraRow["FechaAlta"]));
                        bitacoraCargas.UsuarioAltaId = Convert.ToInt32((cargaBitacoraRow["UsuarioAltaId"]));

                        if (cargaBitacoraRow["FechaCambio"] == DBNull.Value)
                        {
                            bitacoraCargas.FechaCambio = null;
                        }
                        else
                        {
                            bitacoraCargas.FechaCambio = Convert.ToDateTime(cargaBitacoraRow["FechaCambio"]);
                        }

                        if (cargaBitacoraRow["UsuarioCambioId"] == DBNull.Value)
                        {
                            bitacoraCargas.UsuarioCambioId = null;
                        }
                        else
                        {
                            bitacoraCargas.UsuarioCambioId = Convert.ToInt32(cargaBitacoraRow["UsuarioCambioId"]);
                        }

                        cargasSinClasificar.Add(bitacoraCargas);
                    }

                    return cargasSinClasificar;
                }
                else
                {
                    return null;
                }

            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public List<BitacoraCargas> CargasSinClasificar(AdsertiSqlDataAccess adsertiDataAccess)

        #endregion
    }
}