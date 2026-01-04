using Kolyya.Api.Data;
using Kolyya.Api.Consumers;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// =======================
// Services
// =======================

// Controllers (API)
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =======================
// Database (PostgreSQL)
// =======================
var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONN");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// =======================
// MassTransit + RabbitMQ
// =======================

// Lecture des variables d'environnement
var rabbitHost = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "rabbitmq";
var rabbitVHost = Environment.GetEnvironmentVariable("RABBITMQ_VHOST") ?? "/";
var rabbitUser = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest";
var rabbitPassword = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";

builder.Services.AddMassTransit(x =>
{
    // 🔹 Enregistrement du consumer
    x.AddConsumer<TouristicCardOrderedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(rabbitHost, rabbitVHost, h =>
        {
            h.Username(rabbitUser);
            h.Password(rabbitPassword);
        });

        // 🔹 Déclaration explicite de la queue
        cfg.ReceiveEndpoint("touristic-card-orders", e =>
        {
            e.ConfigureConsumer<TouristicCardOrderedConsumer>(context);
        });
    });
});

// 🔥 OBLIGATOIRE : démarre MassTransit (sinon blocage au Publish)
builder.Services.AddMassTransitHostedService();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// =======================
// App
// =======================

var app = builder.Build();

// Swagger uniquement en dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Bienvenue sur l’API Kolyya !");

app.Run();
