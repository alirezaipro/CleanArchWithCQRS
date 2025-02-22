using System.Data;
using Domain.Abstraction;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(Application.AssemblyReference).Assembly);
});

builder.Services.AddDbContext<EshopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Eshop"));
});


builder.Services.AddScoped<IUnitOfWork>(factory =>
    factory.GetRequiredService<EshopDbContext>());

builder.Services.AddScoped<IDbConnection>(factory =>
    factory.GetRequiredService<EshopDbContext>().Database.GetDbConnection());

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();