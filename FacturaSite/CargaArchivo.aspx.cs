using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace FacturaSite
{
    public partial class CargaArchivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CargaArchivoAjaxFileUpload_OnUploadComplete(object sender, AjaxFileUploadEventArgs e)
        {
            try
            {
                // Generate file path
                string filePath = Server.MapPath(@"~\Upload\") + e.FileName;

                // Save upload file to the file system
                CargaArchivoAjaxFileUpload.SaveAs(filePath);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}