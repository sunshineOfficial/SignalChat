using SignalChat.Api.Extensions;
using SignalChat.Api.Hubs;
using SignalChat.Api.Middlewares;
using SignalChat.DataAccess.Extensions;
using SignalChat.Models.Auth;
using SignalChat.Models.Auth.Interfaces;
using SignalChat.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithAuth();
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.MigrateDatabase(builder.Configuration);
builder.Services.AddDapper();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddSingleton<IAuthSettings, AuthSettings>();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddJwtAuth(builder.Configuration);

var app = builder.Build();

app.UseCors(cors =>
{
    cors.AllowAnyHeader();
    cors.AllowAnyMethod();
    cors.AllowAnyOrigin();
});
app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/signalChat/swagger.json", "SignalChat API v1"));
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.MapHub<ChatHub>("/chathub");

app.Run();