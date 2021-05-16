using Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
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
    public class ArticlesController : ControllerBase
    {
        private readonly IArticlesService _articlesService;
        public ArticlesController(IArticlesService articleService)
        {
            _articlesService = articleService;
        }

        [Authorize]
        [HttpPost("Create")]
        public IActionResult AddArticle(ArticleModel model)
        {
            _articlesService.AddArticle(model.ToDomain());

            return Ok();
        }

        [Authorize]
        [HttpGet("Read")]
        public IActionResult GetArticleById([Required] int id)
        {
            var article = _articlesService.GetArticleById(id);

            return Ok(article);
        }

        [Authorize]
        [HttpPut("Update")]
        public IActionResult UpdateArticle([Required] int id, [FromBody] ArticleModel model)
        {
            _articlesService.UpdateArticle(id, model.ToDomain());

            return NoContent();
        }

        [Authorize]
        [HttpDelete("Delete")]
        public IActionResult DeleteArticleById([Required] int id)
        {
            _articlesService.DeleteArticleById(id);

            return NoContent();
        }

        /// <summary>
        /// /api/posts?from=&to  Вернуть список новостей с фильтром по дате и времени from - to
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        [HttpGet("Posts")]
        public async Task<IActionResult> GetArticlesAsync([Required] DateTime from, [Required] DateTime to)
        {

            var articles = await _articlesService.GetArticlesAsync(from, to);

            return Ok(articles);
        }

        /// <summary>
        /// /api/search?text=asd Вернуть новости в которых встречается текст(Поиск)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpGet("Search")]
        public async Task<IActionResult> GetArticlesAsync([Required] string text)
        {

            var articles = await _articlesService.GetArticlesAsync(text);

            return Ok(articles);

        }

        /// <summary>
        /// /api/topten/  Вернуть 10 самых часто используемых слов в новостях(тексте новости)
        /// </summary>
        /// <returns></returns>
        [HttpGet("TopTen")]
        public async Task<IActionResult> GetArticlesTopWordsAsync()
        {

            int count = 10;

            var articles = await _articlesService.GetArticlesTopWordsAsync(count);

            return Ok(articles);

        }
    }
}
