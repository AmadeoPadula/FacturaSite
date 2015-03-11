using System.Collections;
using System.Web.Http;
using Newtonsoft.Json;

namespace ControlFacturas.Controller
{
    public class ProductController : ApiController
    {
        [HttpGet]
        [ActionName("GetHelloWorld")]
        public string GetHelloWorld()
        {
            ArrayList al = new ArrayList {"Hello", "World", "From", "Sample", "Application"};
            return JsonConvert.SerializeObject(al);
        }
    }
}