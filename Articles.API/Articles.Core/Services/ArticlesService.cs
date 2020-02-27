using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ICollection<ArticleDto>> GetArticles(int pageSize, int offset)
        {
            return await _articlesContext.Articles
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedDate)
                .Skip(offset * pageSize)
                .Take(pageSize)
                .ProjectTo<ArticleDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

        }

        public async Task<ArticleDto> CreateArticle(ArticleCreateDto articleDto)
        {
            var entity = _mapper.Map<Article>(articleDto);
            _articlesContext.Articles.Add(entity);
            await _articlesContext.SaveChangesAsync();
            return _mapper.Map<Article, ArticleDto>(entity);
        }

        public async Task DeleteArticle(Guid id)
        {
            var entity = _articlesContext.Articles.FirstOrDefault(p => p.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Entity with {id} is not found in Article table");
            }
            _articlesContext.Articles.Remove(entity);
            await _articlesContext.SaveChangesAsync();
        }

        public async Task PatchArticle(ArticlePatchDto articlePatch)
        {
            var entity = _articlesContext.Articles.FirstOrDefault(p => p.Id == articlePatch.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Entity with {articlePatch.Id} is not found in Article table");
            }
            _mapper.Map(articlePatch, entity);
            await _articlesContext.SaveChangesAsync();
        }
    }
}
