using System.Collections.Generic;

namespace Framework.Application
{
    public interface ICurrentUserService
    {
        int? UserId { get; set; }
        string UserName { get; set; }
        int OrganizationId { get; set; }
        string Ip { get; set; }
        IEnumerable<int> Roles { get; set; }
        bool IsSuperAdmin { get; set; }
        bool IsAccessToLocalApi { get; set; }
    }
}
