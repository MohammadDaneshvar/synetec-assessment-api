using Framework.Domain.Resource;
using System.ComponentModel.DataAnnotations;

namespace Framework.Domain.Enum
{
    public enum StatusEnum
    {
        [Display(Name = nameof(UnkownError), ResourceType = typeof(Status))]
        UnkownError = 0,
        [Display(Name = nameof(Unauthorized), ResourceType = typeof(Status))]
        Unauthorized = 401,
        [Display(Name = nameof(InvalidModelState), ResourceType = typeof(Status))]
        InvalidModelState = 402,
        [Display(Name = nameof(Forbidden), ResourceType = typeof(Status))]
        Forbidden = 403,
        [Display(Name = nameof(NotFound), ResourceType = typeof(Status))]
        NotFound = 404,

    }
}
