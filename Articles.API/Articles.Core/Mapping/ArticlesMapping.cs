using Articles.Core.Entities;
using Articles.Shared.Dto;
using AutoMapper;

namespace Articles.Core.Mapping
{
    public class ArticlesMapping : Profile
    {
        public ArticlesMapping()
        {
            CreateMap<ArticleCreateDto, Article>()
                .ForMember(d => d.Id, m => m.Ignore())
                .ForMember(d => d.CreatedDate, m => m.MapFrom(s => s.CreatedDate))
                .ForMember(d => d.Title, m => m.MapFrom(s => s.Title))
                .ForMember(d => d.Description, m => m.MapFrom(d => d.Description));

            CreateMap<Article, ArticleDto>()
                .ForMember(d => d.Id, m => m.MapFrom(d => d.Id))
                .ForMember(d => d.Title, m => m.MapFrom(s => s.Title))
                .ForMember(d => d.Description, m => m.MapFrom(s => s.Description))
                .ForMember(d => d.CreatedDate, m => m.MapFrom(s => s.CreatedDate));

            CreateMap<ArticlePatchDto, Article>()
                .ForMember(d => d.Id, m => m.Ignore())
                .ForMember(d => d.Title, m => m.Condition(d => !string.IsNullOrEmpty(d.Title)))
                .ForMember(d => d.Description, m => m.Condition(s => !string.IsNullOrEmpty(s.Description)))
                .ForMember(d => d.CreatedDate, m => m.Condition(s => s.CreatedDate != null));
        }
    }
}
