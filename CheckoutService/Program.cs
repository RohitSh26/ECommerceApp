#region References
using ECommerceApp.CatalogueService.Data;
using ECommerceApp.CatalogueService.Interfaces;
using Microsoft.EntityFrameworkCore;
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CatalogueDbContext>(options =>
    options.UseInMemoryDatabase("WatchCatalogueDB"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed initial data
// we will use this data for fuctional testing
var dataSeeder = app.Services.GetService<ICatalogueDataSeeder>();
dataSeeder?.SeedData(app.Services);

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
