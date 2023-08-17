using Microsoft.EntityFrameworkCore;
using QuestionAndChalleger.Data;

namespace QuestionAndChalleger.Api.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QuestionAndChallegerContext>(options
                => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void UseDatabaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<QuestionAndChallegerContext>();
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}
