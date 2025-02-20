using Application.DI;
using Application.Interfaces;
using Application.Services;
using Infrastructure.DI;
using Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ApplicationLayerDI();
builder.Services.InfrastructureDI();
builder.Services.CoreDI();
builder.Services.WriteHeartApiDi();
// Register Shayri services and repositories
//builder.Services.AddScoped<IShayriRepository, ShayriRepository>();
//builder.Services.AddScoped<IUserContentService, ShayriService>();

// Add database connection string
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var app = builder.Build();

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
