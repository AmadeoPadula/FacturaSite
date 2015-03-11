﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdsertiVS2013ClassLibrary;

namespace ModelosEF.DAL
{
    public class DomiciliosClass
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
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Persona de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Agregar(Models.Domicilio domicilio, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (String.IsNullOrEmpty(domicilio.Pais))
                throw new ArgumentNullException("Pais");
            if (domicilio.UsuarioAltaId == 0)
                throw new ArgumentNullException("UsuarioAltaId");

            try
            {
                sentenciaSql = "INSERT INTO [DBO].[DOMICILIOS] ( ";
                sentenciaSql += "	[Calle] ";
                sentenciaSql += "	,[CodigoPostal] ";
                sentenciaSql += "	,[Colonia] ";
                sentenciaSql += "	,[Estado] ";
                sentenciaSql += "	,[Localidad] ";
                sentenciaSql += "	,[Municipio] ";
                sentenciaSql += "	,[NoExterior] ";
                sentenciaSql += "	,[NoInterior] ";
                sentenciaSql += "	,[Pais] ";
                sentenciaSql += "	,[Referencia] ";
                sentenciaSql += "	,[UsuarioAltaId] ";
                sentenciaSql += "	) ";
                sentenciaSql += "VALUES ( ";
                sentenciaSql += "	@Calle ";
                sentenciaSql += "	,@CodigoPostal ";
                sentenciaSql += "	,@Colonia ";
                sentenciaSql += "	,@Estado ";
                sentenciaSql += "	,@Localidad ";
                sentenciaSql += "	,@Municipio ";
                sentenciaSql += "	,@NoExterior ";
                sentenciaSql += "	,@NoInterior ";
                sentenciaSql += "	,@Pais ";
                sentenciaSql += "	,@Referencia ";
                sentenciaSql += "	,@UsuarioAltaId ";
                sentenciaSql += "	); ";


                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@Calle", domicilio.Calle),
                    new SqlParameter("@CodigoPostal", domicilio.CodigoPostal),
                    new SqlParameter("@Colonia", domicilio.Colonia),
                    new SqlParameter("@Estado", domicilio.Estado),
                    new SqlParameter("@Localidad", domicilio.Localidad),
                    new SqlParameter("@Municipio", domicilio.Municipio),
                    new SqlParameter("@NoExterior", domicilio.NoExterior),
                    new SqlParameter("@NoInterior", domicilio.NoInterior),
                    new SqlParameter("@Pais", domicilio.Pais),
                    new SqlParameter("@Referencia", domicilio.Referencia),
                    new SqlParameter("@UsuarioAltaId", domicilio.UsuarioAltaId)
                };

                sentenciaSql += "select SCOPE_IDENTITY()";

                domicilio.DomicilioId = Convert.ToInt32(adsertiDataAccess.EjecutarEscalar(CommandType.Text, sentenciaSql, listaParametros));
                
                return Convert.ToInt32(domicilio.DomicilioId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Agregar(Models.Domicilio domicilio, AdsertiSqlDataAccess adsertiDataAccess)

        /// <summary>
        /// Actualizar()
        /// <para> Adserti </para>
        /// <para> Este método fue creado por Arturo Hernandez </para>
        /// <para> Fecha de creación: Enero 19 de 2015 </para>
        /// <para> Fecha de última modificación: Enero 19 de 2015 </para>
        /// <para> Persona de última modificación: Arturo Hernandez</para>
        /// </summary>
        public Int32 Actualizar(Models.Domicilio domicilio, AdsertiSqlDataAccess adsertiDataAccess)
        {
            String sentenciaSql;
            SqlParameter[] listaParametros;

            // Valida parámetros
            if (String.IsNullOrEmpty(domicilio.Pais))
                throw new ArgumentNullException("Pais");
            if (domicilio.UsuarioCambioId == 0)
                throw new ArgumentNullException("UsuarioCambioId");
            
            try
            {
                sentenciaSql = "UPDATE  ";
                sentenciaSql += "	[DBO].[DOMICILIOS] ";
                sentenciaSql += "SET  ";
                sentenciaSql += "	[Calle] = @Calle ";
                sentenciaSql += "	,[CodigoPostal] = @CodigoPostal ";
                sentenciaSql += "	,[Colonia] = @Colonia ";
                sentenciaSql += "	,[Estado] = @Estado ";
                sentenciaSql += "	,[Localidad] = @Localidad ";
                sentenciaSql += "	,[Municipio] = @Municipio ";
                sentenciaSql += "	,[NoExterior] = @NoExterior ";
                sentenciaSql += "	,[NoInterior] = @NoInterior ";
                sentenciaSql += "	,[Pais] = @Pais ";
                sentenciaSql += "	,[Referencia] = @Referencia ";
                sentenciaSql += "	,[FechaCambio] = getdate() ";
                sentenciaSql += "	,[UsuarioCambioId] = @UsuarioCambioId ";
                sentenciaSql += "WHERE  ";
                sentenciaSql += "	[DomicilioId] = @DomicilioId ";

                //se configuran los parametros
                listaParametros = new SqlParameter[]
                {
                    new SqlParameter("@DomicilioId", domicilio.DomicilioId),
                    new SqlParameter("@Calle", domicilio.Calle),
                    new SqlParameter("@CodigoPostal", domicilio.CodigoPostal),
                    new SqlParameter("@Colonia", domicilio.Colonia),
                    new SqlParameter("@Estado", domicilio.Estado),
                    new SqlParameter("@Localidad", domicilio.Localidad),
                    new SqlParameter("@Municipio", domicilio.Municipio),
                    new SqlParameter("@NoExterior", domicilio.NoExterior),
                    new SqlParameter("@NoInterior", domicilio.NoInterior),
                    new SqlParameter("@Pais", domicilio.Pais),
                    new SqlParameter("@Referencia", domicilio.Referencia),
                    new SqlParameter("@UsuarioAltaId", domicilio.UsuarioCambioId)
                };

                adsertiDataAccess.EjecutarComando(CommandType.Text, sentenciaSql, listaParametros);

                return Convert.ToInt32(domicilio.DomicilioId);
            } //try
            catch (Exception ex)
            {
                throw ex;
            } //catch (Exception ex)
        } // public Int32 Actualizar(Models.Persona persona)

        #endregion
    }
}
