using LootManagerApi;
using LootManagerApi.Repositories;
using LootManagerApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LootManagerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LootManagerDbCS"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IElementRepository, ElementRepository>();

builder.Services.AddScoped<IInfoSheetRepository, InfoSheetRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
