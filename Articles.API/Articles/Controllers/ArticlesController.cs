using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
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
        public async Task<ArticleDto> Create([FromBody] ArticleCreateDto article)
        {
           return await _articlesService.CreateArticle(article);
        }

        [HttpGet]
        public async Task<ICollection<ArticleDto>> Get([FromUri]PageQueryDto query)
        {
            return await _articlesService.GetArticles(query.PageSize.Value, query.Offset.Value);
        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            if (Guid.Empty == id)
            {
                throw new ValidationException(Resources.Articles_Delete_Validation_EmptyId_Error);
            }
           await _articlesService.DeleteArticle(id);
        }

        [HttpPatch]
        public async Task Patch(ArticlePatchDto patch)
        {
            await _articlesService.PatchArticle(patch);
        }
    }
}
