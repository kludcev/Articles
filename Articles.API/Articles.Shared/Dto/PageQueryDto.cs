using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Articles.Shared;

namespace Articles.Shared.Dto
{
    public class PageQueryDto
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.PageSize_Validation_Error))]
        public int? pS { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Offset_Validation_Error))]
        public int? o { get; set; }

        public int? PageSize => pS;
        public int? Offset => o;
    }
}
