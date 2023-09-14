using Microsoft.AspNetCore.Cors;

namespace QuestionAndChalleger.Api.Configurations
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "*",
                    policy =>
                    {
                        policy.WithOrigins("*");
                    });
            });
        }

        public static void UseCorsConfiguration(this IApplicationBuilder app)
        {
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());
        }
    }
}
