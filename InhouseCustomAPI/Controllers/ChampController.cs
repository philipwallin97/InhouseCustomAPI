using InhouseCustomAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static InhouseCustomAPI.Models.GameDbContext;

namespace InhouseCustomAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChampController : Controller
    {
        private readonly GameDbContext database;

        public ChampController()
        {
            database = new GameDbContext();
        }

        [HttpGet]
        [Route("GetAllChamps")]
        public List<Champ> GetAllChamps()
        {
            return database.Champs.ToList();
        }
    }
}
