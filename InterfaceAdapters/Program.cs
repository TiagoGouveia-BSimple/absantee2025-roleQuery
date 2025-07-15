using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastructure;
using Application.IService;
using Application.Service;
using Domain.IRepository;
using Infrastructure.Repository;
using Domain.IFactory;
using Domain.Factory;
using Infrastructure.Resolver;
using Domain.Model;
using Application.DTO;
using MassTransit;
using InterfaceAdapters.Consumer;
using Domain.Message;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<RoleContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

// Services
builder.Services.AddScoped<IRoleService, RoleService>();

// Repositories
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

// Factories
builder.Services.AddScoped<IRoleFactory, RoleFactory>();

// Mappers
builder.Services.AddTransient<RoleDataModelConverter>();
builder.Services.AddAutoMapper(cfg =>
{
    // DataModels
    cfg.AddProfile<DataModelMappingProfile>();

    // DTO
    cfg.CreateMap<Role, RoleDTO>();
});

// MassTransit
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<RoleCreatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        var instance = InstanceInfo.InstanceId;
        cfg.ReceiveEndpoint($"roleQuery-{instance}", conf =>
        {
            conf.ConfigureConsumer<RoleCreatedConsumer>(context);
        });
    });
});

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }

