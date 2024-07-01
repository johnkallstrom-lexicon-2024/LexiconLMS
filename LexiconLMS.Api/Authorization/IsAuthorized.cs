using LexiconLMS.Core.Models.User;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LexiconLMS.Api.Authorization
{
    public class IsAuthorized : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["User"] as UserTrimModel;
            if (user is null)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
