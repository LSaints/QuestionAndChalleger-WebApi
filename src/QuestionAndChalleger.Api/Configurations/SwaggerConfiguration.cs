using System.Reflection.PortableExecutable;

namespace QuestionAndChalleger.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void UseSwaggerConfiguration(this IApplicationBuilder appBuilder)
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                appBuilder.UseSwagger();
                appBuilder.UseSwaggerUI();
            }
        }
    }
}
