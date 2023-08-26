using QuestionAndChalleger.Data.Repository;
using QuestionAndChalleger.Manager.Implementation;
using QuestionAndChalleger.Manager.Interfaces.Manager;
using QuestionAndChalleger.Manager.Interfaces.Repository;

namespace QuestionAndChalleger.Api.Configurations
{
    public static class DependecyInjectionConfiguration
    {
        public static void UseDependecyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionManager, QuestionManager>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserManager, UserManager>();
        }
    }
}
