using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BChat.Data.Model;
using BChat.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace BChatServer.Controllers
{
    /// <summary>
    /// Controller to handle the API requests, It doesn't use authentication.
    /// </summary>
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            var list = Repository.GetMessages();
            return JsonConvert.SerializeObject(list);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new Message());
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Message value)
        {
            Repository.AddMessage(value);
        }

    }
}
