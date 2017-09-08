using System.Collections.Generic;
using ApiCore1.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore1.Controllers
{
    [Route("api/[controller]")]
    public class HopsController : Controller
    {
        [HttpGet]
        public IEnumerable<Hop> GetAll()
        {
            var hops = new Hop[] {
                 new Hop() { Id = 1, Name="Azacca", Description="sample hop 1"},
                 new Hop() { Id = 2, Name="Citra", Description="sample hop 2"}
            };
                 
            return hops;
        }
    }
}