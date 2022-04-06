using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Repository;
using BLL.Services.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Services.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            if(!resultContext.HttpContext.User.Identity.IsAuthenticated) return;

            var userId = resultContext.HttpContext.User.GetUserId();

            var repo = resultContext.HttpContext.RequestServices.GetService<IUserRepository>();


            var user = await repo.GetUserByIdAsync(userId);

            user.LastActive = DateTime.Now;
            await repo.SaveAllAsync();
        }
    }
}