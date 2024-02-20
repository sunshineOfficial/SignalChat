using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SignalChat.Api.Hubs;
using SignalChat.Api.Middlewares;
using SignalChat.DataAccess.Migrations;
using SignalChat.Models.Auth;
using SignalChat.Models.Auth.Interfaces;
using SignalChat.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("signalChat", new OpenApiInfo { Title = "SignalChat API", Version = "v1" });
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\""
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.MigrateDatabase(builder.Configuration);
builder.Services.AddDapper();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddSingleton<IAuthSettings, AuthSettings>();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var authSettings = builder.Configuration.GetSection("Auth");
        options.ClaimsIssuer = authSettings["Issuer"];
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // указывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = true,
            // строка, представляющая издателя
            ValidIssuer = authSettings["Issuer"],
            // будет ли валидироваться потребитель токена
            ValidateAudience = true,
            // установка потребителя токена
            ValidAudience = authSettings["Audience"],
            // будет ли валидироваться время существования
            ValidateLifetime = true,
            // установка ключа безопасности
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings["Key"])),
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Append("Token-Expired", "true");
                }

                return Task.CompletedTask;
            },
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
                
                // если запрос идет в хаб
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/chathub"))
                {
                    // читаем токен из строки запроса
                    context.Token = accessToken;
                }
                
                return Task.CompletedTask;
            }
        };
    });

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