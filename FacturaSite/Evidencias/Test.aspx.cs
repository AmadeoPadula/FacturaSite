using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaSite.BusinessLogic;
using FacturaSite.Models;

namespace FacturaSite.Evidencias
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Comentario Load  agregado desde casa
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)] 
        public static List<Comprobantes> AutoArrayList()
        {
            ComprobantesBusiness comprobantes = new ComprobantesBusiness();

            return comprobantes.ComprobantesSinEvidencia();
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
    }
}