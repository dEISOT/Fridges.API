using FridgesCore.Interfaces;
using FridgesCore.Mapping.Profiles;
using FridgesCore.Services;
using FridgesData.Contexts;
using FridgesData.Interfaces;
using FridgesData.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFridgeService, FridgeService>();
builder.Services.AddScoped<IFridgeRepository, FridgeRepository>();
builder.Services.AddScoped<IFridgeProductService, FridgeProductService>();
builder.Services.AddScoped<IFridgeProductRepository, FridgeProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddAutoMapper(typeof(FridgeProfile), typeof(AuthenticationProfile), typeof(ProductProfile), typeof(FridgeProductProfile));

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
