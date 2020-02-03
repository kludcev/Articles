using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using Articles.Core.Services.Interfaces;
using Articles.Shared.Dto;

namespace Articles.Controllers
{

    [RoutePrefix("articles")]
    public class ArticlesController : BaseApiController
    {
        private readonly IArticlesService _articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            _articlesService = articlesService ?? throw new ArgumentNullException(nameof(articlesService));
        }

        [HttpPost]
        public ArticleDto Create([FromBody] ArticleCreateDto article)
        {
           return _articlesService.CreateArticle(article);
        }

        [HttpGet]
        public ICollection<ArticleDto> Get([FromUri]PageQueryDto query)
        {
            return _articlesService.GetArticles(query.PageSize.Value, query.Offset.Value);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            if (Guid.Empty == id)
            {
                throw new ValidationException(Resources.Articles_Delete_Validation_EmptyId_Error);
            }
            _articlesService.DeleteArticle(id);
        }
    }
}
