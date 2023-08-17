using QuestionAndChalleger.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);
var origin = "*";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.UseDependecyInjectionConfiguration();
builder.Services.UseCorsConfiguration(origin);

var app = builder.Build();

app.UseCors(origin);
app.UseSwaggerConfiguration();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseDatabaseConfiguration();
app.MapControllers();
app.Run();