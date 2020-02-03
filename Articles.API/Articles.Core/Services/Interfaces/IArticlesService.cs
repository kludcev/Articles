using System;
using System.Collections.Generic;
using Articles.Shared.Dto;


namespace Articles.Core.Services.Interfaces
{
    public interface IArticlesService
    {
        ICollection<ArticleDto> GetArticles(int pageSize, int offset);
        ArticleDto CreateArticle(ArticleCreateDto articleDto);
        void DeleteArticle(Guid id);
    }
}
