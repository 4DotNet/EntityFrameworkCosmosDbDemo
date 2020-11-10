using System.Threading.Tasks;
using Dotnet.CosmosDB.Demo.Data;
using Dotnet.CosmosDB.Demo.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dotnet.CosmosDB.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IConfiguration _config;

        public DeveloperController(IConfiguration config)
        {
            _config = config;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using var context = new CosmosDbContext(_config);
            await context.Database.EnsureCreatedAsync();

            var developers = await context.Developers.ToListAsync();
            return Ok(developers);
        }


        [HttpPost]
        public async Task<bool> Post(Developer dev)
        {
            using var context = new CosmosDbContext(_config);
            await context.Database.EnsureCreatedAsync();

            context.Add(dev);
            await context.SaveChangesAsync();

            return true;
        }

    }
}
