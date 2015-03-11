using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ControlFacturas.Model;
using Newtonsoft.Json;

namespace ControlFacturas.Controller
{
    public class MemberController : ApiController
    {
      Repository _repository = new Repository();

        [HttpGet]
        [ActionName("GetMembers")]
        public string GetMembers()
        {
            List<Member> memebers = _repository.GetMembers();
            return JsonConvert.SerializeObject(memebers);
        }
    }
}