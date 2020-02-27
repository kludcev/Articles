using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Articles.Shared.Dto;


namespace Articles.Core.Services.Interfaces
{
    public interface IArticlesService
    {
        Task<ICollection<ArticleDto>> GetArticles(int pageSize, int offset);
        Task<ArticleDto> CreateArticle(ArticleCreateDto articleDto);
        Task DeleteArticle(Guid id);
        Task PatchArticle(ArticlePatchDto articlePatch);
    }
}
