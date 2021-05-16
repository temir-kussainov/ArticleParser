using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ParsersController : ControllerBase
    {
        private readonly IParsersConfigsService _parsersConfigsService;
        private readonly IParsersService _parsersService;
        private readonly IArticlesService _articlesService;

        public ParsersController(IParsersConfigsService parsersConfigsService, IParsersService parsersService, IArticlesService articlesService)
        {
            _parsersConfigsService = parsersConfigsService;
            _parsersService = parsersService;
            _articlesService = articlesService;
        }

        [HttpPost("StartByConfigurationId")]
        public async Task<IActionResult> ParseByConfigurationAsync([Required] int id)
        {
            var parserConfig = _parsersConfigsService.GetParserConfigById(id);

            if (parserConfig is null)
                return BadRequest("Parsing configuration with this id does not exist");

            var parsedArticles = await _parsersService.ParseByConfigurationAsync(parserConfig);
            
            _articlesService.AddArticles(parsedArticles);

            return Ok(parsedArticles);

        }
    }
}
