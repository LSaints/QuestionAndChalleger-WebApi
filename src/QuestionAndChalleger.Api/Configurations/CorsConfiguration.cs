using Microsoft.AspNetCore.Cors;

namespace QuestionAndChalleger.Api.Configurations
{
    public static class CorsConfiguration
    {
        public static void UseCorsConfiguration(this IServiceCollection services, string origin)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: origin,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();
                                  });
            });
        }
    }
}
