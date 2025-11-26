using Microsoft.EntityFrameworkCore;
using OnlinePricingCalculator.Application.Interfaces;
using OnlinePricingCalculator.Application.Services;
using OnlinePricingCalculator.Domain.Interfaces;
using OnlinePricingCalculator.Infrastructure.Persistence;
using OnlinePricingCalculator.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactAppPolicy",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<PricingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPriceCalculatorService, PriceCalculatorService>();

builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ReactAppPolicy");
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
