using Microsoft.AspNetCore.Cors;

namespace QuestionAndChalleger.Api.Configurations
{
    public static class CorsConfiguration
    {
        public static void UseCorsConfiguration(this IApplicationBuilder app)
        {
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());
        }
    }
}
