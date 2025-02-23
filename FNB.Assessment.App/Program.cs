using FNB.Assessment.Data;
using FNB.Assessment.Services;
using FNB.Assessment.Services.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICoinStockWriter, CoinStockWriter>();
builder.Services.AddScoped<ICoinStockReader, CoinStockReader>();
builder.Services.AddScoped<ICoinReader, CoinReader>();
builder.Services.AddScoped<ICoinDispenserService, CoinDispenserService>();
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
