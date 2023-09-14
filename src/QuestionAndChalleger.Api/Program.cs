using QuestionAndChalleger.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.UseAuthConfiguration(builder.Configuration);
builder.Services.AddCorsConfiguration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.UseDependecyInjectionConfiguration();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseCorsConfiguration();
app.UseSwaggerConfiguration();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseDatabaseConfiguration();
app.MapControllers();
app.Run();
