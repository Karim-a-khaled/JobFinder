using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Service
{
    public class UserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IServiceProvider serviceProvider)
        {
            _httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
        }

        public int? GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.Items["userId"];
            return Convert.ToInt32(userId);
        }
    }
}
