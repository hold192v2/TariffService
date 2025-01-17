using TariffService.Infrastructure;
using TariffService.Application.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TariffService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using TariffService.Services;
using MassTransit;
using TariffService.Application.RabbitMq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigurePresistanceApp(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:5173")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});
builder.Services.ConfigureApplicationApp();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();
    x.AddConsumer<UserCartConsumer>();
    x.AddConsumer<UserTarifConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("amqps://akmeanzg:TMOCQxQAEWZjfE0Y7wH5v0TN_XTQ9Xfv@mouse.rmq5.cloudamqp.com/akmeanzg");
        cfg.ReceiveEndpoint("Cart", x =>
        {
            x.ConfigureConsumer<UserCartConsumer>(context);
            x.Bind("exchange-name-cart");
            //Если не будет работать, то смотреть в эту сторону
        });
        cfg.ReceiveEndpoint("Tariff", x =>
        {
            x.ConfigureConsumer<UserTarifConsumer>(context);
            x.Bind("exchange-name-tarif");
            //Если не будет работать, то смотреть в эту сторону
        });


        cfg.ClearSerialization();
        cfg.UseRawJsonSerializer();

    });

});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });

    options.CustomSchemaIds(type => type.ToString());
});

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ce8a25b97b7ad21fdb76c70f163f1e43")),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

CreateDatabase(app);

app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
static void CreateDatabase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    dataContext?.Database.EnsureCreated();
    if (!dataContext.DynamicTariffs.Any())
    {
        var tariffs = DynamicTariffGenerate.GenerateTariffs(); // Генерация всех тарифов
        dataContext.DynamicTariffs.AddRange(tariffs); // Добавление тарифов в DbContext
        dataContext.SaveChanges(); // Сохранение изменений в базе данных
    }
}
