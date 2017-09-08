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

        private HopRepository _hopRepo;

        public HopsController(IngredientsContext ctx, ILogger<HopsController> logger, HopRepository hopRepo)
        {
            _logger = logger;
            _context = ctx;

            _hopRepo = hopRepo;
        }

        [HttpGet]
        [Route("api/hops")]
        public async Task<IEnumerable<Hop>> GetAll()
        {
            _logger.LogInformation("GETTING HOPS....");
            return await _context.Hops.ToListAsync();
        }

        [HttpGet("api/hops/{id:int}")]
        public async Task<Hop> GetHop(int id)
        {
            _logger.LogInformation($"GETTING HOP ID {id}");

            return await _hopRepo.Load(id);
            
        }
    }
}