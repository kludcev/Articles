using System;
using System.ComponentModel.DataAnnotations;


namespace Articles.Shared.Dto
{
    public class ArticleCreateDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
        public DateTimeOffset CreatedDate => DateTimeOffset.UtcNow;
    }
}
