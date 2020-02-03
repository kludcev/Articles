using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Articles.Core.Entities;
using Articles.Core.Exceptions;
using Articles.Core.Services.Interfaces;
using Articles.Shared.Dto;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Articles.Core.Services
{
    public class ArticlesService : BaseService, IArticlesService
    {
        private readonly ArticlesContext _articlesContext;

        public ArticlesService(ArticlesContext articlesContext, IMapper mapper) : base(mapper)
        {
            _articlesContext = articlesContext ?? throw new ArgumentNullException(nameof(articlesContext));
        }

        public ICollection<ArticleDto> GetArticles(int pageSize, int offset)
        {
            return _articlesContext.Articles
                .OrderByDescending(x => x.CreatedDate)
                .Skip(offset * pageSize)
                .Take(pageSize)
                .ProjectTo<ArticleDto>(_mapper.ConfigurationProvider)
                .ToList();

        }

        public ArticleDto CreateArticle(ArticleCreateDto articleDto)
        {
            var entity = _mapper.Map<Article>(articleDto);
            _articlesContext.Articles.Add(entity);
            _articlesContext.SaveChanges();
            return _mapper.Map<Article, ArticleDto>(entity);
        }

        public void DeleteArticle(Guid id)
        {
            var entity = _articlesContext.Articles.FirstOrDefault(p => p.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Entity with {id} is not found in Article table");
            }
            _articlesContext.Entry(entity).State = EntityState.Deleted;
            _articlesContext.SaveChanges();
        }
    }
}
