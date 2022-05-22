using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private IArticleService _articleService;
        private IArticleCategoryService _articleCategoryService;

        public ArticleController(IArticleService articleService, IArticleCategoryService articleCategoryService)
        {
            _articleService = articleService;
            _articleCategoryService = articleCategoryService;
        }

        [HttpGet("GetArticle")]
        public IActionResult GetArticle()
        {
            var result = _articleService.GetListArticle();

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpGet("GetArticleByTitle")]
        public IActionResult GetArticleByTitle(string title)
        {
            var result = _articleService.GetListArticleByFilter(x => x.Article.Title.Contains(title));

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpGet("GetArticleByCategory")]
        public IActionResult GetArticleByCategory(string category)
        {
            var result = _articleService.GetListArticleByFilter(x => x.Categories.Any(y => y.Name.Contains(category)));

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpGet("GetArticleById")]
        public IActionResult GetArticleById(int articleId)
        {
            var result = _articleService.GetArticleById(articleId);

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpPost("AddArticle")]
        public IActionResult AddArticle(ArticleAddDto model)
        {
            var article = _articleService.Add(model.Article);

            if (!article.Success)
                return BadRequest(article.Message);

            //Kategori varsa id'lerini güncelle ve kaydet.
            if (model.Categories.Count() > 0)
            {
                model.Categories.ForEach(x => x.ArticleId = article.Data.Id);

                var categories = _articleCategoryService.AddRange(model.Categories);

                model.Article = article.Data;
                model.Categories = categories.Data;

            }

            return Ok(model);
        }
    }
}
