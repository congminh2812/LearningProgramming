using Binance.Net.Clients;
using CryptoExchange.Net.Authentication;
using LearningProgramming.API.Middlewares;
using LearningProgramming.Application;
using LearningProgramming.Application.Hubs;
using LearningProgramming.Application.Workers;
using LearningProgramming.Identity;
using LearningProgramming.Infrastructure;
using LearningProgramming.Persistence;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddHostedService<TradeWorker>();

builder.Services.AddSignalR();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder => builder.WithOrigins("http://localhost:3000")
    .AllowCredentials()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((c) =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Learnning Programming API", Version = "v1" });

    // Configure Swagger to include JWT bearer token
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
});

builder.Logging.AddFilter("Microsoft.AspNetCore.SignalR", LogLevel.Trace);
builder.Logging.AddFilter("Microsoft.AspNetCore.Http.Connections", LogLevel.Trace);
builder.Services.AddBinance();

BinanceRestClient.SetDefaultOptions(options =>
{
    options.ApiCredentials = new ApiCredentials("nFOd9ip3Gwp4WkbI6r7XK2fLVsuZ3q1ehCEaGKWCUM9fc89qVgvYzWLqqmVFS1OA", "KEdgyIpvQTC15cXgFAnxQWDWAURYLlM2vJXgnKYgKBG1wagrnCLh0EzJNcROaXUS");
});
BinanceSocketClient.SetDefaultOptions(options =>
{
    options.ApiCredentials = new ApiCredentials("nFOd9ip3Gwp4WkbI6r7XK2fLVsuZ3q1ehCEaGKWCUM9fc89qVgvYzWLqqmVFS1OA", "KEdgyIpvQTC15cXgFAnxQWDWAURYLlM2vJXgnKYgKBG1wagrnCLh0EzJNcROaXUS");
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHub<ChatHub>("/hub/chatHub");
app.MapHub<BinanceHub>("/hub/binanceHub");

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
