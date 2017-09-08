using System.Collections.Generic;
using ApiCore1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ApiCore1.Controllers
{
    public class HopsController : Controller
    {

        private readonly IngredientsContext _context;
        private ILogger<HopsController> _logger;

        public HopsController(IngredientsContext ctx, ILogger<HopsController> logger)
        {
            _logger = logger;
            _context = ctx;
        }

        [HttpGet]
        [Route("api/myhops")]
        public async Task<IEnumerable<Hop>> GetAll()
        {
            _logger.LogInformation("GETTING HOPS....");
            return await _context.Hops.ToListAsync();
        }
    }
}