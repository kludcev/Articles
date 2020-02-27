using System;
using System.ComponentModel.DataAnnotations;

namespace Articles.Shared.Dto
{
    public class ArticlePatchDto
    {
        [Required]
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
    }
}
