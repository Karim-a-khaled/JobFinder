using JobFinder.Data;
using JobFinder.Service;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<AccountService>();
            services.AddScoped<ApplicationService>();
            services.AddScoped<JobSeekerService>();
            services.AddScoped<CompanyService>();
            services.AddScoped<JobService>();
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddCors(options => options.AddPolicy(name: "NgOrigins",policy => {
                policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            }));

            return services;
        }
    }
}
